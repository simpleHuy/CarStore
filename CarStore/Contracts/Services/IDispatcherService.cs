using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using Microsoft.UI.Dispatching;

namespace CarStore.Contracts.Services;
public interface IDispatcherService
{
    Task EnqueueAsync(Func<Task> action);
    void TryEnqueue(Action action);
    DispatcherQueueTimer CreateTimer();
}
