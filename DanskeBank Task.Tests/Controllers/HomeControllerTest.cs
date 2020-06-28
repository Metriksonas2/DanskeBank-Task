using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DanskeBank_Task;
using DanskeBank_Task.Controllers;

namespace DanskeBank_Task.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Home Page", result.ViewBag.Title);
        }
    }
}
