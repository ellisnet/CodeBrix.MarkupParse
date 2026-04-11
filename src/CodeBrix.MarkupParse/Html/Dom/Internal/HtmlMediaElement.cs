using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Io;
using CodeBrix.MarkupParse.Io.Processors;
using CodeBrix.MarkupParse.Media;
using CodeBrix.MarkupParse.Media.Dom;
using System;

namespace CodeBrix.MarkupParse.Html.Dom; //Was previously: namespace AngleSharp.Html.Dom

/// <summary>
/// Represents the abstract base for HTML media (audio / video) elements.
/// </summary>
abstract class HtmlMediaElement<TResource> : HtmlElement, IHtmlMediaElement
    where TResource : class, IMediaInfo
{
    #region Fields

    private readonly MediaRequestProcessor<TResource> _request;
    private ITextTrackList _texts;

    #endregion

    #region ctor
    
    public HtmlMediaElement(Document owner, string name, string prefix)
        : base(owner, name, prefix)
    {
        _request = new MediaRequestProcessor<TResource>(owner.Context);
    }

    #endregion

    #region Properties

    public IDownload CurrentDownload => _request?.Download;

    public string Source
    {
        get => this.GetUrlAttribute(AttributeNames.Src);
        set => this.SetOwnAttribute(AttributeNames.Src, value);
    }

    public string CrossOrigin
    {
        get => this.GetOwnAttribute(AttributeNames.CrossOrigin);
        set => this.SetOwnAttribute(AttributeNames.CrossOrigin, value);
    }

    public string Preload
    {
        get => this.GetOwnAttribute(AttributeNames.Preload);
        set => this.SetOwnAttribute(AttributeNames.Preload, value);
    }

    public MediaNetworkState NetworkState => _request?.NetworkState ?? MediaNetworkState.Empty;

    public TResource Media => _request?.Resource;

    public MediaReadyState ReadyState
    {
        get 
        { 
            var controller = Controller; 
            return controller is null ? MediaReadyState.Nothing : controller.ReadyState; 
        }
    }

    public bool IsSeeking
    {
        get;
        protected set;
    }

    public string CurrentSource =>
            //TODO Check for Source elements
            Source;

    public double Duration => Controller?.Duration ?? 0.0;

    public double CurrentTime
    {
        get => Controller?.CurrentTime ?? 0.0;
        set
        {
            var controller = Controller;

            if (controller != null)
            {
                controller.CurrentTime = value;
            }

            //if (value < 0)
            //    _currentTime = 0;
            //else if (value > Duration)
            //    _currentTime = Duration;
            //else
            //    _currentTime = value;

            //var ev = new Event();
            //ev.Init(EventNames.DurationChange, true, true);
            //Dispatch(ev);
        }
    }

    public bool IsAutoplay
    {
        get => this.GetBoolAttribute(AttributeNames.Autoplay);
        set => this.SetBoolAttribute(AttributeNames.Autoplay, value);
    }

    public bool IsLoop
    {
        get => this.GetBoolAttribute(AttributeNames.Loop);
        set => this.SetBoolAttribute(AttributeNames.Loop, value);
    }

    public bool IsShowingControls
    {
        get => this.GetBoolAttribute(AttributeNames.Controls);
        set => this.SetBoolAttribute(AttributeNames.Controls, value);
    }

    public bool IsDefaultMuted
    {
        get => this.GetBoolAttribute(AttributeNames.Muted);
        set => this.SetBoolAttribute(AttributeNames.Muted, value);
    }

    public bool IsPaused => PlaybackState == MediaControllerPlaybackState.Waiting && ReadyState >= MediaReadyState.CurrentData;

    public bool IsEnded => PlaybackState == MediaControllerPlaybackState.Ended;

    public DateTime StartDate => DateTime.Today;

    public ITimeRanges BufferedTime => Controller?.BufferedTime;

    public ITimeRanges SeekableTime => Controller?.SeekableTime;

    public ITimeRanges PlayedTime => Controller?.PlayedTime;

    public string MediaGroup
    {
        get => this.GetOwnAttribute(AttributeNames.MediaGroup);
        set => this.SetOwnAttribute(AttributeNames.MediaGroup, value);
    }

    public double Volume
    {
        get => Controller?.Volume ?? 1.0;
        set
        {
            var controller = Controller;

            if (controller != null)
            {
                controller.Volume = value;
            }
        }
    }

    public bool IsMuted
    {
        get => Controller?.IsMuted ?? false;
        set
        {
            var controller = Controller;

            if (controller != null)
            {
                controller.IsMuted = value;
            }
        }
    }

    public IMediaController Controller => _request?.Resource?.Controller;

    public double DefaultPlaybackRate
    {
        get => Controller?.DefaultPlaybackRate ?? 1.0;
        set
        {
            var controller = Controller;

            if (controller != null)
            {
                controller.DefaultPlaybackRate = value;
            }
        }
    }

    public double PlaybackRate
    {
        get => Controller?.PlaybackRate ?? 1.0;
        set
        {
            var controller = Controller;

            if (controller != null)
            {
                controller.PlaybackRate = value;
            }
        }
    }

    public MediaControllerPlaybackState PlaybackState => Controller?.PlaybackState ?? MediaControllerPlaybackState.Waiting;

    public IMediaError MediaError
    {
        get;
        private set;
    }

    public virtual IAudioTrackList AudioTracks => null;

    public virtual IVideoTrackList VideoTracks => null;

    public ITextTrackList TextTracks
    {
        get => _texts;
        protected set => _texts = value;
    }

    #endregion

    #region Methods

    public void Load()
    {
        var source = CurrentSource;
        UpdateSource(source);
    }

    public void Play()
    {
        Controller?.Play();
    }

    public void Pause()
    {
        Controller?.Pause();
    }

    public string CanPlayType(string type)
    {
        var service = Context?.GetResourceService<TResource>(type);
        //Other option would be probably.
        return service != null ? "maybe" : string.Empty;
    }

    public ITextTrack AddTextTrack(string kind, string label = null, string language = null)
    {
        //TODO
        return null!;
    }

    #endregion

    #region Internal Methods

    internal override void SetupElement()
    {
        base.SetupElement();
        UpdateSource(this.GetOwnAttribute(AttributeNames.Src));
    }

    internal void UpdateSource(string value)
    {
        if (value != null)
        {
            var url = new Url(value);
            this.Process(_request, url);
        }
    }

    #endregion
}
