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
    public class FakeWineRepository : IRepository<Wine>
    {
        public void Create(Wine item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Wine Read(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Wine> ReadAll()
        {
            return new List<Wine>()
            {
                new Wine(1,"A bor",2017,WineType.Vörös,1900,1)
                {
                    Awards = new HashSet<Award>()
                    {
                        new Award(1,2017,"A",1,true),
                        new Award(2,2018,"B",1,true),
                        new Award(3,2016,"C",1,false),
                        new Award(4,2018,"D",1,false)
                    }
                },
                new Wine(2,"B bor",2019,WineType.Fehér,2100,2)
                {
                    Awards = new HashSet<Award>()
                    {
                        new Award(5,2018,"E",2,false),
                    }
                },
                new Wine(3,"C bor",2016,WineType.Rozé,3000,3)
                {
                    Awards = new HashSet<Award>()
                    {
                        new Award(6,2018,"F",3,true),
                        new Award(7,2018,"G",3,true),
                        new Award(8,2018,"H",3,true),
                    }
                }
            }.AsQueryable();
        }

        public void Update(Wine item)
        {
            throw new NotImplementedException();
        }
    }
    [TestFixture]
    public class Tester
    {
        WineLogic wineLogic;
        WineryLogic wineryLogic;
        Mock<IRepository<Winery>> mockWineryRepository;

        [SetUp]
        public void Init()
        {
            wineLogic = new WineLogic(new FakeWineRepository());

            var inputdata = new List<Winery>()
            {
                new Winery(1,"Első borászat",1000),
                new Winery(2,"Második borászat",2000),
                new Winery(3,"Harmadik borászat",3000),
            }.AsQueryable();

            mockWineryRepository = new Mock<IRepository<Winery>>();
            mockWineryRepository.Setup(m => m.ReadAll()).Returns(inputdata);
            wineryLogic = new WineryLogic(mockWineryRepository.Object);
        }
        [Test]
        public void WinesWithNationalAwardTest()
        {
            var result = wineLogic.WinesWithNationalAward().ToList();

            Assert.That(result[0].Name == "A bor");
            Assert.That(result[1].Name == "B bor");
            Assert.That(result.Count() == 2);
        }

        [Test]
        public void WineryLogicReadAllTest()
        {
            var testReadAll = wineryLogic.ReadAll();

            mockWineryRepository.Verify(
                m => m.ReadAll(),
                Times.Once());
        }

        [Test]
        public void WineryCreateTestWithInvalidItem()
        {
            Winery testItem = null; try
            {
                wineryLogic.Create(testItem);
            }
            catch
            {
            }            
            mockWineryRepository.Verify(
                m => m.Create(testItem),
                Times.Never);
        }
        [Test]
        public void WineryCreateTestWithValidItem()
        {
            Winery testItem = new Winery(4,"Teszt Borászat",7000);
            wineryLogic.Create(testItem);

            mockWineryRepository.Verify(
                m => m.Create(testItem),
                Times.Once);
        }
    }
}
