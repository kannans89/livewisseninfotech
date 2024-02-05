using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;
using Moq;
using MVCCosmosDbApp.Models;
using MVCCosmosDbApp.Services;
using NUnit.Framework;

namespace MVCCosmosDbApp.Tests
{
    [TestFixture]
    public class TodoServiceTests
    {
        private Mock<Container> _containerMock;
        private TodoService _todoService;

        [SetUp]
        public void Setup()
        {
            _containerMock = new Mock<Container>();
            _todoService = new TodoService(_containerMock.Object);
        }

        [Test]
        public async Task GetTodosAsync_ShouldReturnListOfTodos()
        {
            // Arrange
            var expectedTodos = new List<Todo>
            {
                new Todo { Id = "1", Title = "Todo 1", Priority = 1 },
                new Todo { Id = "2", Title = "Todo 2", Priority = 2 },
                new Todo { Id = "3", Title = "Todo 3", Priority = 3 }
            };

            var iteratorMock = new Mock<FeedIterator<Todo>>();
            iteratorMock.SetupSequence(i => i.HasMoreResults)
                .Returns(true)
                .Returns(false);
            iteratorMock.Setup(i => i.ReadNextAsync())
                .ReturnsAsync(expectedTodos);

            _containerMock.Setup(c => c.GetItemQueryIterator<Todo>(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<QueryRequestOptions>()))
                .Returns(iteratorMock.Object);

            // Act
            var result = await _todoService.GetTodosAsync();

            // Assert
            Assert.AreEqual(expectedTodos, result);
        }

        [Test]
        public async Task AddTodo_ShouldReturnTrue_WhenItemCreatedSuccessfully()
        {
            // Arrange
            var todo = new Todo { Id = "1", Title = "New Todo", Priority = 1 };

            var itemResponseMock = new Mock<ItemResponse<Todo>>();
            itemResponseMock.Setup(i => i.StatusCode)
                .Returns(System.Net.HttpStatusCode.Created);

            _containerMock.Setup(c => c.CreateItemAsync<Todo>(It.IsAny<Todo>(), It.IsAny<PartitionKey>(), It.IsAny<ItemRequestOptions>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(itemResponseMock.Object);

            // Act
            var result = await _todoService.AddTodo(todo);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task AddTodo_ShouldReturnFalse_WhenItemCreationFails()
        {
            // Arrange
            var todo = new Todo { Id = "1", Title = "New Todo", Priority = 1 };

            var itemResponseMock = new Mock<ItemResponse<Todo>>();
            itemResponseMock.Setup(i => i.StatusCode)
                .Returns(System.Net.HttpStatusCode.BadRequest);

            _containerMock.Setup(c => c.CreateItemAsync<Todo>(It.IsAny<Todo>(), It.IsAny<PartitionKey>(), It.IsAny<ItemRequestOptions>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(itemResponseMock.Object);

            // Act
            var result = await _todoService.AddTodo(todo);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
