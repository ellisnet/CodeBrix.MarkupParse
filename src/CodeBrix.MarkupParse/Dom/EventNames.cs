using System;

namespace CodeBrix.MarkupParse.Dom; //Was previously: namespace AngleSharp.Dom

/// <summary>
/// The collection of (known / used) event names.
/// </summary>
public static class EventNames
{
    /// <summary>
    /// The invalid event.
    /// </summary>
    public static readonly string Invalid = "invalid";

    /// <summary>
    /// The load event.
    /// </summary>
    public static readonly string Load = "load";

    /// <summary>
    /// The DOMContentLoaded event.
    /// </summary>
    public static readonly string DomContentLoaded = "DOMContentLoaded";

    /// <summary>
    /// The error event.
    /// </summary>
    public static readonly string Error = "error";

    /// <summary>
    /// The beforescriptexecute event.
    /// </summary>
    public static readonly string BeforeScriptExecute = "beforescriptexecute";

    /// <summary>
    /// The afterscriptexecute event.
    /// </summary>
    public static readonly string AfterScriptExecute = "afterscriptexecute";

    /// <summary>
    /// The readystatechanged event.
    /// </summary>
    public static readonly string ReadyStateChanged = "readystatechanged";

    /// <summary>
    /// The abort event.
    /// </summary>
    public static readonly string Abort = "abort";

    /// <summary>
    /// The blur event.
    /// </summary>
    public static readonly string Blur = "blur";

    /// <summary>
    /// The cancel event.
    /// </summary>
    public static readonly string Cancel = "cancel";

    /// <summary>
    /// The click event.
    /// </summary>
    public static readonly string Click = "click";

    /// <summary>
    /// The change event.
    /// </summary>
    public static readonly string Change = "change";

    /// <summary>
    /// The canplaythrough event.
    /// </summary>
    public static readonly string CanPlayThrough = "canplaythrough";

    /// <summary>
    /// The canplay event.
    /// </summary>
    public static readonly string CanPlay = "canplay";

    /// <summary>
    /// The cuechange event.
    /// </summary>
    public static readonly string CueChange = "cuechange";

    /// <summary>
    /// The dblclick event.
    /// </summary>
    public static readonly string DblClick = "dblclick";

    /// <summary>
    /// The drag event.
    /// </summary>
    public static readonly string Drag = "drag";

    /// <summary>
    /// The dragend event.
    /// </summary>
    public static readonly string DragEnd = "dragend";

    /// <summary>
    /// The dragenter event.
    /// </summary>
    public static readonly string DragEnter = "dragenter";

    /// <summary>
    /// The dragexit event.
    /// </summary>
    public static readonly string DragExit = "dragexit";

    /// <summary>
    /// The dragleave event.
    /// </summary>
    public static readonly string DragLeave = "dragleave";

    /// <summary>
    /// The dragover event.
    /// </summary>
    public static readonly string DragOver = "dragover";

    /// <summary>
    /// The dragstart event.
    /// </summary>
    public static readonly string DragStart = "dragstart";

    /// <summary>
    /// The drop event.
    /// </summary>
    public static readonly string Drop = "drop";

    /// <summary>
    /// The durationchange event.
    /// </summary>
    public static readonly string DurationChange = "durationchange";

    /// <summary>
    /// The emptied event.
    /// </summary>
    public static readonly string Emptied = "emptied";

    /// <summary>
    /// The focus event.
    /// </summary>
    public static readonly string Focus = "focus";

    /// <summary>
    /// The fullscreenchange event.
    /// </summary>
    public static readonly string FullscreenChange = "fullscreenchange";

    /// <summary>
    /// The fullscreenerror event.
    /// </summary>
    public static readonly string FullscreenError = "fullscreenerror";

    /// <summary>
    /// The hashchange event.
    /// </summary>
    public static readonly string HashChange = "hashchange";

    /// <summary>
    /// The input event.
    /// </summary>
    public static readonly string Input = "input";

    /// <summary>
    /// The message event.
    /// </summary>
    public static readonly string Message = "message";

    /// <summary>
    /// The keydown event.
    /// </summary>
    public static readonly string Keydown = "keydown";

    /// <summary>
    /// The keypress event.
    /// </summary>
    public static readonly string Keypress = "keypress";

    /// <summary>
    /// The keyup event.
    /// </summary>
    public static readonly string Keyup = "keyup";

    /// <summary>
    /// The ended event.
    /// </summary>
    public static readonly string Ended = "ended";

    /// <summary>
    /// The loadeddata event.
    /// </summary>
    public static readonly string LoadedData = "loadeddata";

    /// <summary>
    /// The loadedmetadata event.
    /// </summary>
    public static readonly string LoadedMetaData = "loadedmetadata";

    /// <summary>
    /// The loadend event.
    /// </summary>
    public static readonly string LoadEnd = "loadend";

    /// <summary>
    /// The loadstart event.
    /// </summary>
    public static readonly string LoadStart = "loadstart";

    /// <summary>
    /// The wheel event.
    /// </summary>
    public static readonly string Wheel = "wheel";

    /// <summary>
    /// The mouseup event.
    /// </summary>
    public static readonly string Mouseup = "mouseup";

    /// <summary>
    /// The mouseover event.
    /// </summary>
    public static readonly string Mouseover = "mouseover";

    /// <summary>
    /// The mouseout event.
    /// </summary>
    public static readonly string Mouseout = "mouseout";

    /// <summary>
    /// The mousemove event.
    /// </summary>
    public static readonly string Mousemove = "mousemove";

    /// <summary>
    /// The mouseleave event.
    /// </summary>
    public static readonly string Mouseleave = "mouseleave";

    /// <summary>
    /// The mouseenter event.
    /// </summary>
    public static readonly string Mouseenter = "mouseenter";

    /// <summary>
    /// The mousedown event.
    /// </summary>
    public static readonly string Mousedown = "mousedown";

    /// <summary>
    /// The pause event.
    /// </summary>
    public static readonly string Pause = "pause";

    /// <summary>
    /// The play event.
    /// </summary>
    public static readonly string Play = "play";

    /// <summary>
    /// The playing event.
    /// </summary>
    public static readonly string Playing = "playing";

    /// <summary>
    /// The progress event.
    /// </summary>
    public static readonly string Progress = "progress";

    /// <summary>
    /// The ratechange event.
    /// </summary>
    public static readonly string RateChange = "ratechange";

    /// <summary>
    /// The waiting event.
    /// </summary>
    public static readonly string Waiting = "waiting";

    /// <summary>
    /// The volumechange event.
    /// </summary>
    public static readonly string VolumeChange = "volumechange";

    /// <summary>
    /// The toggle event.
    /// </summary>
    public static readonly string Toggle = "toggle";

    /// <summary>
    /// The timeupdate event.
    /// </summary>
    public static readonly string TimeUpdate = "timeupdate";

    /// <summary>
    /// The suspend event.
    /// </summary>
    public static readonly string Suspend = "suspend";

    /// <summary>
    /// The submit event.
    /// </summary>
    public static readonly string Submit = "submit";

    /// <summary>
    /// The stalled event.
    /// </summary>
    public static readonly string Stalled = "stalled";

    /// <summary>
    /// The show event.
    /// </summary>
    public static readonly string Show = "show";

    /// <summary>
    /// The select event.
    /// </summary>
    public static readonly string Select = "select";

    /// <summary>
    /// The seeking event.
    /// </summary>
    public static readonly string Seeking = "seeking";

    /// <summary>
    /// The seeked event.
    /// </summary>
    public static readonly string Seeked = "seeked";

    /// <summary>
    /// The scroll event.
    /// </summary>
    public static readonly string Scroll = "scroll";

    /// <summary>
    /// The resize event.
    /// </summary>
    public static readonly string Resize = "resize";

    /// <summary>
    /// The reset event.
    /// </summary>
    public static readonly string Reset = "reset";

    /// <summary>
    /// The afterprint event.
    /// </summary>
    public static readonly string AfterPrint = "afterprint";

    /// <summary>
    /// The print event.
    /// </summary>
    public static readonly string Print = "print";

    /// <summary>
    /// The beforeprint event.
    /// </summary>
    public static readonly string BeforePrint = "beforeprint";

    /// <summary>
    /// The beforeunload event.
    /// </summary>
    public static readonly string BeforeUnload = "beforeunload";

    /// <summary>
    /// The unloading event.
    /// </summary>
    public static readonly string Unloading = "unloading";

    /// <summary>
    /// The offline event.
    /// </summary>
    public static readonly string Offline = "offline";

    /// <summary>
    /// The online event.
    /// </summary>
    public static readonly string Online = "online";

    /// <summary>
    /// The pagehide event.
    /// </summary>
    public static readonly string PageHide = "pagehide";

    /// <summary>
    /// The pageshow event.
    /// </summary>
    public static readonly string PageShow = "pageshow";

    /// <summary>
    /// The popstate event.
    /// </summary>
    public static readonly string PopState = "popstate";

    /// <summary>
    /// The unload event.
    /// </summary>
    public static readonly string Unload = "unload";

    /// <summary>
    /// The confirmUnload event.
    /// </summary>
    public static readonly string ConfirmUnload = "confirmUnload";

    /// <summary>
    /// The storage event.
    /// </summary>
    public static readonly string Storage = "storage";

    /// <summary>
    /// The parsing event.
    /// </summary>
    public static readonly string Parsing = "parsing";

    /// <summary>
    /// The parsed event.
    /// </summary>
    public static readonly string Parsed = "parsed";

    /// <summary>
    /// The requesting event.
    /// </summary>
    public static readonly string Requesting = "requesting";

    /// <summary>
    /// The requested event.
    /// </summary>
    public static readonly string Requested = "requested";
}
