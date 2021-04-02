using System;
using System.Collections.Generic;
using _02_Claims;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _02_ClaimsTest
{
    [TestClass]
    public class ClaimsTest
    {

        private Claims _claim;
        private ClaimsRepository _claimRepo;

        [TestInitialize]
        public void Arrange()
        {
            _claimRepo = new ClaimsRepository();
            _claim = new Claims(1, ClaimType.Car, "Car accident on 465", 400.00m, new DateTime(2018, 04, 25), new DateTime(2018, 04, 27));
            _claimRepo.EnterNewClaim(_claim);
        }

        //Methods: SeeAllClaims, SeeNextClaim, DealWithClaim, EnterNewClaim

        [TestMethod]
        public void SeeAllClaims_ShouldDisplayAllClaims()
        {
            Claims testClaim = new Claims();
            ClaimsRepository testRepo = new ClaimsRepository();
            testRepo.EnterNewClaim(testClaim);

            //Act
            Queue<Claims> testQueue = testRepo.SeeAllClaims();
            bool directoryHasClaims = testQueue.Contains(testClaim);

            //Assert
            Assert.IsTrue(directoryHasClaims);
        }

        [TestMethod]
        public void SeeNextClaim_ShouldShowNextClaim()
        {
            //Arrange   //Peek
            //_claimRepo.EnterNewClaim(_claim);    done in TestInitialize to put _claim into the Queue

            //Act
            Claims nextClaim =_claimRepo.SeeNextClaim();

            //Assert
            Assert.AreEqual(_claimRepo.SeeNextClaim(), _claim);
        }

        [TestMethod]
        public void DealWithClaim_ShouldRemoveClaim()
        {
            //Arrange   //Dequeue
            Claims ClaimA = new Claims(2, ClaimType.Home, "House fire in kitchen", 4000.00m, new DateTime(2018, 04, 11), new DateTime(2018, 04, 20));

            //Act
            _claimRepo.EnterNewClaim(ClaimA);
            _claimRepo.DealWithClaim();

            int expected = 1;
            int actual = _claimRepo.SeeAllClaims().Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EnterNewClaim_ShouldAddClaim()
        {
            //Arrange   //already entered this claim in the TestInitialize phase
            //_claimRepo.EnterNewClaim(_claim);

            //Act
            int expected = 1;
            int actual = _claimRepo.SeeAllClaims().Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
