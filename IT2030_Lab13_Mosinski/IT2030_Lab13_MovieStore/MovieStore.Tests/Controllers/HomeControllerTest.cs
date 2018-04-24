using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IT2030_Lab13_MovieStore;
using IT2030_Lab13_MovieStore.Controllers;

namespace MovieStore.Tests.Controllers
{
    [TestClass]     // This attribute is required
    public class HomeControllerTest
    {
        [TestMethod]    // This attribute is required
        public void Index()
        {
            // Arrange - Performing some setup for the test, like data mocking
            HomeController controller = new HomeController();

            // Act - Perform some action
            ViewResult result = controller.Index() as ViewResult;

            // Assert - Where you check to see if the test passed or not
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
