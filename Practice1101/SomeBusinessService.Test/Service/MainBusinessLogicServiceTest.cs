using Microsoft.VisualStudio.TestTools.UnitTesting;
using SomeBusinessService.Services;
using System;
using Moq;
using SomeBusinessService.Interfaces;
using SomeBusinessService.Models;

namespace SomeBusinessService.Test.Service
{
    [TestClass]
    public class MainBusinessLogicServiceTest
    {
        [TestMethod]
        public void Create_FullProductWithName_CallDBManagerCreate()
        {
            Mock<IDBManager> dbManager = new Mock<IDBManager>();
            dbManager.Setup(db => db.Create(It.IsAny<Product>()));

            var testClass = new MainBusinessLogicService(dbManager.Object);

            var product = new Product() { Name = "TestName" };
            testClass.Create(product);
            dbManager.Verify(x => x.Create(product), Times.Once);
        }

        [TestMethod]
        public void Create_NullProduct_TrowArgumentException()
        {
            Mock<IDBManager> dbManager = new Mock<IDBManager>();
            dbManager.Setup(db => db.Create(It.IsAny<Product>()));
            var testClass = new MainBusinessLogicService(dbManager.Object);
            Product product = null;

            Assert.ThrowsException<ArgumentException>(() => testClass.Create(product));
        }

        [TestMethod]
        public void Create_ProductWithNullString_ThrowArgumentException()
        {
            Mock<IDBManager> dbManager = new Mock<IDBManager>();
            dbManager.Setup(db => db.Create(It.IsAny<Product>()));
            var testClass = new MainBusinessLogicService(dbManager.Object);
            Product product = new Product();

            Assert.ThrowsException<ArgumentException>(() => testClass.Create(product));
        }

        [TestMethod]
        public void Create_ProductWithEmptyName_ThrowArgumentException()
        {
            Mock<IDBManager> dbManager = new Mock<IDBManager>();
            dbManager.Setup(db => db.Create(It.IsAny<Product>()));
            var testClass = new MainBusinessLogicService(dbManager.Object);
            Product product = new Product() { Name = "" };

            Assert.ThrowsException<ArgumentException>(() => testClass.Create(product));
        }

        [TestMethod]
        public void Delete_NameIsEmpty_CallDbManagerDelete()
        {
            Mock<IDBManager> dbManager = new Mock<IDBManager>();
            dbManager.Setup(db => db.Delete(It.IsAny<string>()));

            var testClass = new MainBusinessLogicService(dbManager.Object);

            string name = "";
            testClass.Delete(name);
            dbManager.Verify(x => x.Delete(name), Times.Once);
        }

        [TestMethod]
        public void Delete_NameIsNull_CallDbManagerDelete()
        {
            Mock<IDBManager> dbManager = new Mock<IDBManager>();
            dbManager.Setup(db => db.Delete(It.IsAny<string>()));

            var testClass = new MainBusinessLogicService(dbManager.Object);

            string name = null;
            testClass.Delete(name);
            dbManager.Verify(x => x.Delete(name), Times.Once);
        }

        [TestMethod]
        public void Delete_NameValid_CallDbManagerDelete()
        {
            Mock<IDBManager> dbManager = new Mock<IDBManager>();
            dbManager.Setup(db => db.Delete(It.IsAny<string>()));

            var testClass = new MainBusinessLogicService(dbManager.Object);

            string name = "name";
            testClass.Delete(name);
            dbManager.Verify(x => x.Delete(name), Times.Never);
        }
        [TestMethod]
        public void Update_ProductOldName_DBManagerCallUpdate()
        {
            Mock<IDBManager> dbManager = new Mock<IDBManager>();
            dbManager.Setup(db => db.Update(It.IsAny<Product>(), It.IsAny<string>()));
            var testClass = new MainBusinessLogicService(dbManager.Object);

            var oldName = "oldName";
            var product = new Product() { Name = "TestName" };

            testClass.Update(product, oldName);
            dbManager.Verify(x => x.Update(product, oldName), Times.Once);
        }

        [TestMethod]
        public void Update_NullString_ArgumentNullException()
        {
            Mock<IDBManager> dbManager = new Mock<IDBManager>();
            dbManager.Setup(db => db.Update(It.IsAny<Product>(), It.IsAny<string>()));
            var testClass = new MainBusinessLogicService(dbManager.Object);

            var product = new Product() { Name = "TestName" };
            string OldName = null;

            Assert.ThrowsException<ArgumentNullException>(() => testClass.Update(product, OldName));
        }

        [TestMethod]
        public void Update_EmptyString_ArgumentNullException()
        {
            Mock<IDBManager> dbManager = new Mock<IDBManager>();
            dbManager.Setup(db => db.Update(It.IsAny<Product>(), It.IsAny<string>()));
            var testClass = new MainBusinessLogicService(dbManager.Object);

            var product = new Product() { Name = "TestName" };
            string OldName = "";

            Assert.ThrowsException<ArgumentNullException>(() => testClass.Update(product, OldName));
        }

        [TestMethod]
        public void Get_ValidName_ArgumentNullException()
        {
            Mock<IDBManager> dbManager = new Mock<IDBManager>();
            dbManager.Setup(db => db.Get(It.IsAny<string>()));

            var testClass = new MainBusinessLogicService(dbManager.Object);

            var name = "name";
            Assert.ThrowsException<ArgumentNullException>(() => testClass.Get(name));
        }

        [TestMethod]
        public void Get_NullString_DBManagerGet()
        {
            Mock<IDBManager> dbManager = new Mock<IDBManager>();
            dbManager.Setup(db => db.Get(It.IsAny<string>()));
            var testClass = new MainBusinessLogicService(dbManager.Object);

            string name = null;

            testClass.Get(name);
            dbManager.Verify(x => x.Get(name), Times.Once);
        }

        [TestMethod]
        public void Get_EmptyString_DBManagerGet()
        {
            Mock<IDBManager> dbManager = new Mock<IDBManager>();
            dbManager.Setup(db => db.Get(It.IsAny<string>()));
            var testClass = new MainBusinessLogicService(dbManager.Object);

            var name = "";

            testClass.Get(name);
            dbManager.Verify(x => x.Get(name), Times.Once);
        }
    }
}
