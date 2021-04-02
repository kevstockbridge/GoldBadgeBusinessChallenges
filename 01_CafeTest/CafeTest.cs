using System;
using System.Collections.Generic;
using _01_CafeLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _01_CafeTest
{

    [TestClass]
    public class CafeTest
    {
        private Menu _item;
        private MenuRepository _repo;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new MenuRepository();
            _item = new Menu(1, "cheeseburger", "The Komodo Spin on the  Classic, with fries and drink included.", new List<string> { "bun", "patty", "cheese", "lettuce", "tomato", "pickle" }, 4.99m );
            _repo.AddMenuItem(_item);
        }

        [TestMethod]
        public void AddMenuItem_ShouldReturnAreEqual()
        {
            //Arrange       
            _repo.AddMenuItem(_item);

            //Act
            int expected = 1;
            int actual = _repo.DisplayMenuItems().Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetMenuItemByName_ShouldReturnCorrectItem()
        {
            Menu searchedItem = _repo.GetMenuItemByName("cheeseburger");
            Assert.AreEqual("cheeseburger", searchedItem.MealName);
        }

        [TestMethod]
        public void DeleteMenuItem_ShouldReturnAreEqual()
        {
            //Arrange
            _repo.DeleteMenuItem(_item);

            //Act
            int expected = -1;
            int actual = _repo.DisplayMenuItems().Count;

            //Assert
            Assert.AreNotEqual(expected, actual);
        }

        [TestMethod]
        public void DisplayMenuItems_ShouldReturnFullMenuList()
        {
            //Arrange
            Menu testItem = new Menu();
            MenuRepository testRepo = new MenuRepository();
            testRepo.AddMenuItem(testItem);

            //Act
            List<Menu> testMenu = testRepo.DisplayMenuItems();
            bool menuHasItems = testMenu.Contains(testItem);

            //Assert
            Assert.IsTrue(menuHasItems);
        }
    }
}
