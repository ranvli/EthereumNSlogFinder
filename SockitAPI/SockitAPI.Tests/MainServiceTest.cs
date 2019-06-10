using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SockitAPI.Model;
using SockitAPI.Helpers.Util.Interface;

namespace SockitAPI.Tests
{
    [TestClass]
    public class MainServiceTest
    {
        [TestMethod]
        public void GetHistoryAny_ValidEthDomain_ReturnsValidDomainResponse()
        {
            
            var mock = new Mock<IEnsUtil>();
            
            var mockENSHistoryDomainList = new List<ENSHistoryDomain>()
            {
                new ENSHistoryDomain
                {
                    Address = "Address1",
                    Author = "Author1",
                    BlockHash = "BlockHash1",
                    BlockNumber = 1,
                    NumberOfTransactions = 1,
                    TimeStamp = 1
                }
            };

            string domain = "test.eth";
            string nameHash = "nameHash";

            var parameter = new SearchParameter()
            {
                Any = domain,
                Address = "Address",
                BlockNumber = 0,
                From = (ulong)(DateTime.UtcNow - new DateTime(1970, 1, 1)) .TotalSeconds - 2000
            };


            mock.Setup(t => t.GetHistoryByAddressAndTimeFromAsync(It.IsAny<SearchParameter>())).ReturnsAsync(mockENSHistoryDomainList);
            mock.Setup(t => t.GetNameHashFromMainNet(It.IsAny<string>())).Returns(nameHash);
            
            var instance = new MainService(mock.Object);
            var result = instance.GetHistoryAnyAsync(parameter).Result;
            
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count == 1);
            Assert.AreEqual(parameter.EName, parameter.Any);
            Assert.AreEqual("Address1", result[0].Address);

        }

        [TestMethod]
        public void GetHistoryAny_ValidAddress_ReturnsValidDomainResponse()
        {

            var mock = new Mock<IEnsUtil>();

            var mockENSHistoryDomainList = new List<ENSHistoryDomain>()
            {
                new ENSHistoryDomain
                {
                    Address = "Address1",
                    Author = "Author1",
                    BlockHash = "BlockHash1",
                    BlockNumber = 1,
                    NumberOfTransactions = 1,
                    TimeStamp = 1
                }
            };
                        
            var parameter = new SearchParameter()
            {
                Any = "0x123",
                Address = "Address",
                BlockNumber = 0,
                From = (ulong)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds - 2000
            };

            mock.Setup(t => t.GetHistoryByAddressAndTimeFromAsync(It.IsAny<SearchParameter>())).ReturnsAsync(mockENSHistoryDomainList);
            
            var instance = new MainService(mock.Object);
            var result = instance.GetHistoryAnyAsync(parameter).Result;

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count == 1);
            Assert.AreEqual(parameter.Address, parameter.Any);
            Assert.AreEqual("Address1", result[0].Address);

        }
    }
}
