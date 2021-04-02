using System;
using System.Collections.Generic;
using _03_BadgeLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _03_BadgeTest
{
    [TestClass]
    public class BadgeTest
    {
        private BadgeRepository _badgeRepo;

        [TestInitialize]
        public void Arrange()
        {
            _badgeRepo = new BadgeRepository();
            _badgeRepo.AddBadge(12345, new List<string> { "A7" });
        }

        [TestMethod]
        public void AddBadgeTest()
        {
            //Arrange
            _badgeRepo.AddBadge(6789, new List<string> { "B5" });

            //Act
            int expected = 2;
            int actual = _badgeRepo.SeeAllBadges().Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetBadgeByIDTest()
        {
            Badge searchedBadge = _badgeRepo.GetBadgeByID(12345);
            Assert.AreEqual(12345, searchedBadge.BadgeID);
        }

        [TestMethod]
        public void AddDoorAccessTest()
        {
            Dictionary<int, List<string>> badgeDict = _badgeRepo.SeeAllBadges();

            _badgeRepo.AddDoorAccess(12345, "A5");
            int expected = 2;
            int actual = badgeDict[12345].Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveDoorAccessTest()
        {
            Dictionary<int, List<string>> badgeDict = _badgeRepo.SeeAllBadges();
            _badgeRepo.AddDoorAccess(12345, "A5");
            _badgeRepo.AddDoorAccess(12345, "A9");

            _badgeRepo.RemoveDoorAccess(12345, "A7");
            int expected = 2;
            int actual = badgeDict[12345].Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SeeAllBadgesTest()
        {
            BadgeRepository testRepo = new BadgeRepository();
            testRepo.AddBadge(12345, new List<string> { "A7" });

            Dictionary< int, List<string>> testDict = testRepo.SeeAllBadges();
            bool dictionaryHasBadges = testDict.ContainsKey(12345);
            
        }
    }
}
