using System;
using System.Web.Mvc;
using System.Net;
using System.Data;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IT2030_Lab13_MovieStore.Controllers;
using IT2030_Lab13_MovieStore.Models;
using Moq;

namespace MovieStore.Tests.Controllers
{
    [TestClass]
    public class MovieStoreControllerTest
    {
        [TestMethod]
        public void Index_Test_TestView()
        {
            // Arrange
            MoviesController controller = new MoviesController();   // creating a basic controller object

            // Act
            ViewResult result = controller.Index() as ViewResult;

            //Assert 
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void MovieStore_ListOfMovies()
        {
            // Arrange
            MoviesController controller = new MoviesController();   // creating a basic controller object

            // Act
            var result = controller.ListOfMovies();

            //Assert 
            Assert.AreEqual("Terminator 1", result[0].Title);
            Assert.AreEqual("Terminator 2", result[1].Title);
            Assert.AreEqual("Terminator 3", result[2].Title);
        }

        [TestMethod]
        public void MovieStore_IndexRedirect_Success()
        {
            // Arrange
            MoviesController controller = new MoviesController();

            // Act
            var result = controller.IndexRedirect(1) as RedirectToRouteResult;

            // Assert
            Assert.AreEqual("Create", result.RouteValues["action"]);
            Assert.AreEqual("HomeController", result.RouteValues["controller"]);
        }

        [TestMethod]
        public void MovieStore_IndexRedirect_BadRequest()
        {
            // Arrange
            MoviesController controller = new MoviesController();

            // Act
            var result = controller.IndexRedirect(0) as HttpStatusCodeResult;

            // Assert
            Assert.AreEqual(HttpStatusCode.BadRequest, (HttpStatusCode) result.StatusCode);
        }

        [TestMethod]
        public void MovieStore_ListFromDb_Success()
        {
            // Arrange 
            // Need to have "using Moq" in the header for this to work below
            Mock<IT2030_Lab13_MovieStoreDbContext> mockContext = new Mock<IT2030_Lab13_MovieStoreDbContext>();
            Mock<DbSet<Movie>> mockSet = new Mock <DbSet<Movie>>();

            var list = new List<Movie>
            {
                new Movie { MovieId = 1, Title = "Jaws"},
                new Movie { MovieId = 2, Title = "Despicable Me"}
            }.AsQueryable();

            mockSet.As<IQueryable<Movie>>().Setup(m => m.Provider).Returns(list.Provider);
            mockSet.As<IQueryable<Movie>>().Setup(m => m.GetEnumerator()).Returns(list.GetEnumerator());
            mockSet.As<IQueryable<Movie>>().Setup(m => m.Expression).Returns(list.Expression);
            mockSet.As<IQueryable<Movie>>().Setup(m => m.ElementType).Returns(list.ElementType);            

            mockContext.Setup(db => db.Movies).Returns(mockSet.Object);

            // Need to pass mock object for Dependency Injection
            MoviesController controller = new MoviesController(mockContext.Object);

            // Act
            ViewResult result = controller.ListFromDb() as ViewResult;
            List<Movie> resultModel = result.Model as List<Movie>;            

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Jaws", resultModel[0].Title);
            Assert.AreEqual("Despicable Me", resultModel[1].Title);
        }

        [TestMethod]
        public void MovieStore_Details_Success()
        {
            // Arrange 
            // Need to have "using Moq" in the header for this to work below
            Mock<IT2030_Lab13_MovieStoreDbContext> mockContext = new Mock<IT2030_Lab13_MovieStoreDbContext>();
            Mock<DbSet<Movie>> mockSet = new Mock<DbSet<Movie>>();

            var list = new List<Movie>
            {
                new Movie { MovieId = 1, Title = "Jaws"},
                new Movie { MovieId = 2, Title = "Despicable Me"}
            }.AsQueryable();

            mockSet.As<IQueryable<Movie>>().Setup(m => m.Provider).Returns(list.Provider);
            mockSet.As<IQueryable<Movie>>().Setup(m => m.GetEnumerator()).Returns(list.GetEnumerator());
            mockSet.As<IQueryable<Movie>>().Setup(m => m.Expression).Returns(list.Expression);
            mockSet.As<IQueryable<Movie>>().Setup(m => m.ElementType).Returns(list.ElementType);
            mockSet.Setup(m => m.Find(It.IsAny<Object>())).Returns(list.First());

            mockContext.Setup(db => db.Movies).Returns(mockSet.Object);

            // Need to pass mock object for Dependency Injection
            MoviesController controller = new MoviesController(mockContext.Object);

            // Act
            ViewResult result = controller.Details(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void MovieStore_Details_No_Id()
        {
            // Arrange 
            // Need to have "using Moq" in the header for this to work below
            Mock<IT2030_Lab13_MovieStoreDbContext> mockContext = new Mock<IT2030_Lab13_MovieStoreDbContext>();
            Mock<DbSet<Movie>> mockSet = new Mock<DbSet<Movie>>();

            var list = new List<Movie>
            {
                new Movie { MovieId = 1, Title = "Jaws"},
                new Movie { MovieId = 2, Title = "Despicable Me"}
            }.AsQueryable();

            mockSet.As<IQueryable<Movie>>().Setup(m => m.Provider).Returns(list.Provider);
            mockSet.As<IQueryable<Movie>>().Setup(m => m.GetEnumerator()).Returns(list.GetEnumerator());
            mockSet.As<IQueryable<Movie>>().Setup(m => m.Expression).Returns(list.Expression);
            mockSet.As<IQueryable<Movie>>().Setup(m => m.ElementType).Returns(list.ElementType);
            mockSet.Setup(m => m.Find(It.IsAny<Object>())).Returns(list.First());

            mockContext.Setup(db => db.Movies).Returns(mockSet.Object);

            // Need to pass mock object for Dependency Injection
            MoviesController controller = new MoviesController(mockContext.Object);

            // Act
            HttpStatusCodeResult result = controller.Details(null) as HttpStatusCodeResult;

            // Assert
            Assert.AreEqual(HttpStatusCode.BadRequest, (HttpStatusCode)result.StatusCode);
        }

        [TestMethod]
        public void MovieStore_Details_MovieNull()
        {
            // Arrange 
            // Need to have "using Moq" in the header for this to work below
            Mock<IT2030_Lab13_MovieStoreDbContext> mockContext = new Mock<IT2030_Lab13_MovieStoreDbContext>();
            Mock<DbSet<Movie>> mockSet = new Mock<DbSet<Movie>>();

            var list = new List<Movie>
            {
                new Movie { MovieId = 1, Title = "Jaws"},
                new Movie { MovieId = 2, Title = "Despicable Me"}
            }.AsQueryable();
            
            mockSet.As<IQueryable<Movie>>().Setup(m => m.Provider).Returns(list.Provider);
            mockSet.As<IQueryable<Movie>>().Setup(m => m.GetEnumerator()).Returns(list.GetEnumerator());
            mockSet.As<IQueryable<Movie>>().Setup(m => m.Expression).Returns(list.Expression);
            mockSet.As<IQueryable<Movie>>().Setup(m => m.ElementType).Returns(list.ElementType);

            // Pass movie as null. not happy path
            Movie movie = null;
            mockSet.Setup(m => m.Find(It.IsAny<Object>())).Returns(movie);

            mockContext.Setup(db => db.Movies).Returns(mockSet.Object);

            // Need to pass mock object for Dependency Injection
            MoviesController controller = new MoviesController(mockContext.Object);

            // Act
            HttpStatusCodeResult result = controller.Details(1) as HttpStatusCodeResult;

            // Assert
            Assert.AreEqual(HttpStatusCode.NotFound, (HttpStatusCode)result.StatusCode);
        }
    }
}
