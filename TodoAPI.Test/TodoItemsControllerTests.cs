using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAPI.Controllers;
using TodoAPI.Data;
using TodoAPI.Models;

namespace TodoAPI.Test;
public class TodoItemsControllerTests
{
    private TodoContext _context;
    private TodoItemsController _controller;

    public TodoItemsControllerTests()
    {
        var options = new DbContextOptionsBuilder<TodoContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // Unique database name
            .Options;

        _context = new TodoContext(options);
        _controller = new TodoItemsController(_context);
    }

    [Fact]
    public async Task GetTodoItems_ReturnsAllItems()
    {
        // Arrange
        var todoItem = new TodoItem { Title = "Test Title", Description = "Test Description" };
        _context.TodoItems.Add(todoItem);
        await _context.SaveChangesAsync();

        // Act
        var result = await _controller.GetTodoItems();

        // Assert
        var items = Assert.IsType<List<TodoItem>>(result.Value);
        Assert.Single(items);
    }

    [Fact]
    public async Task GetTodoItem_ReturnsItemById()
    {
        // Arrange
        var todoItem = new TodoItem { Title = "Test Title", Description = "Test Description" };
        _context.TodoItems.Add(todoItem);
        await _context.SaveChangesAsync();

        // Act
        var result = await _controller.GetTodoItem(todoItem.Id);

        // Assert
        Assert.Equal(todoItem.Id, result.Value.Id);
    }

    [Fact]
    public async Task PostTodoItem_CreatesNewItem()
    {
        // Arrange
        var todoItem = new TodoItem { Title = "Test Title", Description = "Test Description" };

        // Act
        var result = await _controller.PostTodoItem(todoItem);

        // Assert
        var item = (result.Result as CreatedAtActionResult).Value as TodoItem;
        Assert.Equal(todoItem.Title, item.Title);
    }

    [Fact]
    public async Task PutTodoItem_UpdatesExistingItem()
    {
        // Arrange
        var todoItem = new TodoItem { Title = "Test Title", Description = "Test Description" };
        _context.TodoItems.Add(todoItem);
        await _context.SaveChangesAsync();

        todoItem.Title = "Updated Title";

        // Act
        await _controller.PutTodoItem(todoItem.Id, todoItem);

        // Assert
        var item = _context.TodoItems.Find(todoItem.Id);
        Assert.Equal("Updated Title", item.Title);
    }

    [Fact]
    public async Task DeleteTodoItem_RemovesItem()
    {
        // Arrange
        var todoItem = new TodoItem { Title = "Test Title", Description = "Test Description" };
        _context.TodoItems.Add(todoItem);
        await _context.SaveChangesAsync();

        // Act
        await _controller.DeleteTodoItem(todoItem.Id);

        // Assert
        var item = _context.TodoItems.Find(todoItem.Id);
        Assert.Null(item);
    }
}

