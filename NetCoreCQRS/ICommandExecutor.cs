﻿using System;
using System.Threading.Tasks;

namespace NetCoreCQRS
{
    public interface ICommandExecutor<out TCommand>
    {
        void Process(Action<TCommand> commandAction);
        TResult Process<TResult>(Func<TCommand, TResult> commandFunc);
        Task<TResult> Process<TResult>(Func<TCommand, Task<TResult>> commandFunc);

        void ProcessWithTransaction(Action<TCommand> action);
        TResult ProcessWithTransaction<TResult>(Func<TCommand, TResult> commandFunc);
        Task<TResult> ProcessWithTransaction<TResult>(Func<TCommand, Task<TResult>> commandFunc);
    }
}