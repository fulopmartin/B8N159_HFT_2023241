using B8N159_HFT_2023241.Logic;
using B8N159_HFT_2023241.Models;
using B8N159_HFT_2023241.Repository;
using Microsoft.VisualBasic.FileIO;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace B8N159_HFT_2023241.Test
{
    [TestFixture]
    public class Tester
    {
        WineryLogic wl;
        Mock<IRepository<Winery>> mockWineryRepository;
        [SetUp]
        public void Init()
        {
            var inputdata = new List<Winery>()
            {
                new Winery(1,"Első borászat",1000),
                new Winery(2,"Második borászat",2000),
                new Winery(3,"Harmadik borászat",3000),
            }.AsQueryable();

            mockWineryRepository = new Mock<IRepository<Winery>>();
            mockWineryRepository.Setup(m => m.ReadAll()).Returns(inputdata);
            wl = new WineryLogic(mockWineryRepository.Object);
        }

        [Test]
        public void WineryLogicReadAllTest()
        {
            var testReadAll = wl.ReadAll();

            mockWineryRepository.Verify(
                m => m.ReadAll(),
                Times.Once());
        }
    }
}
