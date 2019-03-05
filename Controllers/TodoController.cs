using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Todo.Models;
using Todo.Services;
using Todo.ViewModels;

namespace Todo.Controllers
{
    [Route("/Todo")]
    public class TodoController : Controller
    {
        private readonly ITodoItemService _todoService;

        public TodoController(ITodoItemService service)
        {
            this._todoService = service;
        }

        [HttpGet("")]
        public IActionResult Todo()
        {
            AddTodoViewModel todoViewModel = new AddTodoViewModel();
            todoViewModel.TodoList = _todoService.GetCompleteItems().ToList();
                
            return View(todoViewModel);
        }

        [HttpGet("UpdateTodo/{id}")]
        public IActionResult UpdateTodo(Guid id)
        {
            UpdateTodoViewModel todo = new UpdateTodoViewModel();

            todo.Todo = _todoService.SearchItem(id);

            if (todo == null) return BadRequest("Bad request, can't find the todo item to update.");
            
            return View(todo);
        }

        [HttpPost("AddItem")]
        public IActionResult AddItem(TodoItem todoItem)
        {
            if(!ModelState.IsValid)
            {
                return RedirectToAction("Todo");
            }

            bool successful = _todoService.AddNewItem(todoItem);

            if (!successful) return BadRequest("Could not add todo item");

            return RedirectToAction("Todo");
        }

        [HttpPost("DeleteItem/{id}")]
        public IActionResult DeleteItem(Guid id)
        {
            bool successful = _todoService.DeleteItem(id);

            if (!successful) return BadRequest("Could not delete todo item with id: " + id);

            return RedirectToAction("Todo");
        }
    }
}