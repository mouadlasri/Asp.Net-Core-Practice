using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Models;

namespace Todo.Services
{
    public interface ITodoItemService
    {
        List<TodoItem> GetCompleteItems();

        bool AddNewItem(TodoItem newTodoItem);

        bool DeleteItem(Guid itemId);

        TodoItem SearchItem(Guid itemId);
    }
}
