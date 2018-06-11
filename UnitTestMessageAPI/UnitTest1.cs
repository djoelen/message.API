using Message.API.Controllers;
using Message.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;

namespace UnitTestMessageAPI
{

    [TestClass]
    public class UnitTestMEssageController
    {

        private MessageController _messageController;

        public UnitTestMEssageController()
        {
            _messageController = new MessageController();
        }

        [TestMethod]
        public void GetMessages_ShouldWork()
        {
            // Arrange
            var controller = _messageController;

            // Act
            var result = controller.GetMessages();
            var okResult = result as OkObjectResult;

            // Assert
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);

        }

        [TestMethod]
        public void GetOneMessage_ShouldNotWork()
        {
            // arrange
            var controller = _messageController;

            // act
            var result = controller.GetMessage(10000);
            var okResult = result as OkObjectResult;

            // assert
            Assert.IsNull(okResult);


        }

        [TestMethod]
        public void PostOneMessage_ShouldWork()
        {
            // Arrange
            var controller = _messageController;

            // Act
            var actionResult = controller.CreateMessage(new MessageForCreationDto { Message = "test" });
            var createdResult = actionResult as CreatedAtRouteResult;

            // Assert
            Assert.IsNotNull(createdResult);
            Assert.AreEqual("GetMessage", createdResult.RouteName);
            Assert.AreEqual(3, createdResult.RouteValues["id"]);


        }

        [TestMethod]
        public void UpdateMessage_ShouldWork()
        {
            // Arrange
            var controller = _messageController;
            // Act
            var result = controller.UpdateMessage(1, new MessageForUpdateDto { Message = "Updated message" }) as StatusCodeResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
            Assert.AreEqual(204, result.StatusCode);
            //** Added a new assertion.
        }
    }
}
