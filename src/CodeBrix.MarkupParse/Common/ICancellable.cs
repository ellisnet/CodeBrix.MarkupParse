using System;
using System.Threading.Tasks;

namespace CodeBrix.MarkupParse.Common; //Was previously: namespace AngleSharp.Common

/// <summary>
/// Represents a cancellable task with result.
/// </summary>
public interface ICancellable<T> : ICancellable
{
    /// <summary>
    /// Gets the associated awaitable task.
    /// </summary>
    Task<T> Task { get; }
}

/// <summary>
/// Represents a cancellable task without result.
/// </summary>
public interface ICancellable
{
    /// <summary>
    /// Cancels the covered task.
    /// </summary>
    void Cancel();

    /// <summary>
    /// Gets if the task has already completed.
    /// </summary>
    bool IsCompleted { get; }

    /// <summary>
    /// Gets if the task is (still) running.
    /// </summary>
    bool IsRunning { get; }
}
