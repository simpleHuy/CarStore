using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Dispatching;
using CarStore.Contracts.Services;
using CommunityToolkit.WinUI;
using System.Windows.Threading;

namespace CarStore.Services;
public class DispatcherService : IDispatcherService
{
    public readonly DispatcherQueue _dispatcherQueue;

    public DispatcherService()
    {
        _dispatcherQueue = DispatcherQueue.GetForCurrentThread();
    }

    public DispatcherQueueTimer CreateTimer()
    {
        return _dispatcherQueue.CreateTimer();
    }

    public async Task EnqueueAsync(Func<Task> action)
    {
        bool enqueued = _dispatcherQueue.TryEnqueue(async () =>
        {
            await action();
        });

        if (!enqueued)
        {
            throw new InvalidOperationException("Failed to enqueue the action");
        }
    }

    public void TryEnqueue(Action action)
    {
        _dispatcherQueue.TryEnqueue(() => action());
    }
}
