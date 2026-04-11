using CodeBrix.MarkupParse.Browser;
using CodeBrix.MarkupParse.Common;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CodeBrix.MarkupParse.Tests.Mocks; //Was previously: namespace AngleSharp.Core.Tests.Mocks

sealed class StandingEventLoop : IEventLoop
{
    public ICancellable Enqueue(Action<CancellationToken> action, TaskPriority priority)
    {
        var t = new StandingTask();
        Run(action, t);
        return t;
    }

    private static async void Run(Action<CancellationToken> action, StandingTask t)
    {
        await Task.Delay(10).ConfigureAwait(false);
        t.IsRunning = true;
        action.Invoke(default);
        t.IsRunning = false;
        t.IsCompleted = true;
    }

    public void Spin()
    {
    }

    public void CancelAll()
    {
    }

    class StandingTask : ICancellable
    {
        public bool IsCompleted { get; set; }

        public bool IsRunning { get; set; }

        public void Cancel()
        {
        }
    }
}
