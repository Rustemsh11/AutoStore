using AutoStore.Domain.Abstract;
using AutoStore.Domain.Entities;
using AutoStore.WebUI.Controllers;
using AutoStore.WebUI.Helpers;
using AutoStore.WebUI.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AutoStore.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //arrange
            Mock<IAutoRepository> mock = new Mock<IAutoRepository>();
            mock.Setup(m => m.Autos).Returns(new List<Auto>
            {
                new Auto{AutoId=1, Name="Auto1"},
                new Auto{AutoId=2, Name="Auto2"},
                new Auto{AutoId=3, Name="Auto3"},
                new Auto{AutoId=4, Name="Auto4"},
                new Auto{AutoId=5, Name="Auto5"},
                new Auto{AutoId=6, Name="Auto6"},
            });
            AutoController autoController = new AutoController(mock.Object);
            int pageSize = 4;

            //act
            IEnumerable<Auto> result = (IEnumerable<Auto>)autoController.List(null, 2).Model;

            //asset
            List<Auto> resultAuto = result.ToList();
            Assert.IsTrue(resultAuto.Count == 2);
            Assert.AreEqual(resultAuto[1].Name, "Auto5");
            Assert.AreEqual(resultAuto[1].Name, "Auto6");
        }
        [TestMethod]
        public void Can_Generate_Page_Links()
        {
            HtmlHelper helper = null;

            PagingInfo pagingInfo = new PagingInfo
            {
                ItemPerPage = 5,
                ThisPage = 2,
                TotalItems = 20
            };

            Func<int, string> pageUrlDelegate = i => "Page" + i;

            MvcHtmlString result = helper.PageLinks(pagingInfo, pageUrlDelegate);

            Assert.AreEqual(@"<a class=""btn btn-default"" href=""Page1"">1</a>" + @"<a class=""btn btn-default btn-primary selected"" href=""Page2"">2</a>" +
                    @"<a class=""btn btn-default"" href=""Page3"">3</a>" + @"<a class=""btn btn-default"" href=""Page4"">4</a>", result.ToString());
        }
        [TestMethod]
        public void RemoveItemCartList()
        {
            Auto auto1 = new Auto { AutoId = 1, Name = "auto1" };
            Auto auto2 = new Auto { AutoId = 2, Name = "auto2" };
            Auto auto3 = new Auto { AutoId = 3, Name = "auto3" };

            Cart cart = new Cart();

            cart.AddItem(auto1, 1);
            cart.AddItem(auto2, 1);
            cart.AddItem(auto3, 1);
            List<CartLine> results = cart.cartLines.ToList();

            cart.RemoveLine(auto2);
            Assert.AreEqual(results.Count(), 2);
            




        }
        [TestMethod]
        public void CanRightPagingInfo()
        {
            Mock<IAutoRepository> mock = new Mock<IAutoRepository>();
            mock.Setup(m => m.Autos).Returns(new List<Auto>
            {
                new Auto{AutoId=1, Name="Auto1"},
                new Auto{AutoId=2, Name="Auto2"},
                new Auto{AutoId=3, Name="Auto3"},
                new Auto{AutoId=4, Name="Auto4"},
                new Auto{AutoId=5, Name="Auto5"},
                new Auto{AutoId=6, Name="Auto6"},
            });

            AutoController autoController = new AutoController(mock.Object);
            autoController.pageSize = 2;

            AutoPagingListView result = (AutoPagingListView)autoController.List(null,2).Model;


            PagingInfo pagingInfo = result.PagingInfo;
            Assert.AreEqual(pagingInfo.ThisPage, 2);
            Assert.AreEqual(pagingInfo.ItemPerPage, 2);
            Assert.AreEqual(pagingInfo.TotalItems, 6);
            Assert.AreEqual(pagingInfo.TotalPages, 3);

        }
    }
}
