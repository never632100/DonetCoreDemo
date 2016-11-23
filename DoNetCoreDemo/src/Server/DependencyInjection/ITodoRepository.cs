using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model.DependencyInjection;

namespace Server.DependencyInjection
{
    public interface ITodoRepository
    {
        IEnumerable<TodoItem> AllItems { get; }
        void Add(TodoItem item);
        TodoItem GetById(int id);
        bool TryDelete(int id);
    }
}
