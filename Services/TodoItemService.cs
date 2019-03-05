using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Models;

namespace Todo.Services
{
    public class TodoItemService : ITodoItemService
    {
        private readonly TodoDbContext _dbContext;

        public TodoItemService(TodoDbContext context)
        {
            this._dbContext = context;
        }

        public List<TodoItem> GetCompleteItems()
        {
            List<TodoItem> itemsList = new List<TodoItem>();

            itemsList = _dbContext.Todos.ToList();

            return itemsList;
        }

        public bool AddNewItem(TodoItem newTodoItem)
        {
            if (newTodoItem == null) return false;

            _dbContext.Todos.Add(newTodoItem);

            int recordsAdded = _dbContext.SaveChanges();

            // if record was added
            if (recordsAdded > 0) return true;

            return false;
        }

        public bool DeleteItem(Guid todoItemId)
        {
            TodoItem item = _dbContext.Todos.Where(todo => todo.TodoItemId == todoItemId).FirstOrDefault();

            _dbContext.Todos.Remove(item);

            int recordsDeleted = _dbContext.SaveChanges();

            // if record was deleted
            if (recordsDeleted > 0) return true;

            return false;
        }

        public TodoItem SearchItem(Guid todoItemId)
        {
            TodoItem todoItem = _dbContext.Todos.Where(todo => todo.TodoItemId == todoItemId).FirstOrDefault();

            if (todoItem == null) return null;

            return todoItem;
        }
    }
}
