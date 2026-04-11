using CodeBrix.MarkupParse.Dom;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CodeBrix.MarkupParse.Io; //Was previously: namespace AngleSharp.Io

/// <summary>
/// Represents a download in progress.
/// </summary>
sealed class Download : IDownload
{
    #region Fields

    private readonly CancellationTokenSource _cts;
    private readonly Task<IResponse> _task;
    private readonly Url _target;
    private readonly object _source;

    #endregion

    #region ctor

    public Download(Task<IResponse> task, CancellationTokenSource cts, Url target, object source)
    {
        _task = task;
        _cts = cts;
        _target = target;
        _source = source;
    }

    #endregion

    #region Properties

    public object Source => _source;

    public Url Target => _target;

    public Task<IResponse> Task => _task;

    public bool IsRunning => _task.Status == TaskStatus.Running;

    public bool IsCompleted => _task.Status == TaskStatus.Faulted ||
        _task.Status == TaskStatus.RanToCompletion ||
        _task.Status == TaskStatus.Canceled;

    #endregion

    #region Methods

    public void Cancel() => _cts.Cancel();

    #endregion
}
