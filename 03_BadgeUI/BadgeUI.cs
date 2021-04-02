using _03_BadgeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_BadgeUI
{
    class BadgeUI
    {
        private BadgeRepository _badgeRepo = new BadgeRepository();

        public void Run()
        {
            SeedList();
            RunMenu();
        }

        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Hello Security Admin. What would you like to do? \n" +
                    "1. Add a Badge \n" +
                    "2. Edit a Badge \n" +
                    "3. List All Badges \n" +
                    "4. Exit Menu");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        {
                            AddBadge();
                            break;
                        }
                    case "2":
                        {
                            EditBadge();
                            break;
                        }
                    case "3":
                        {
                            ListAllBadges();
                            break;
                        }
                    case "4":
                        {
                            continueToRun = false;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Please select an appropriate option (1-4).");
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                            break;
                        }
                }
            }
        }

        private void AddBadge()
        {
            Console.WriteLine("");
            Console.WriteLine("What is the number on the badge?");
            string badgeResponse = Console.ReadLine();
            int newBadgeNumber = int.Parse(badgeResponse);

            Console.WriteLine("List a door that it needs access to: ");
            List<string> doorResponse = new List<string> { Console.ReadLine() };

            bool addingDoor = true;
            while (addingDoor)
            {
                Console.WriteLine("Any other doors (Y/N) ?");
                string response = Console.ReadLine().ToLower();
                switch (response)
                {
                    case "y":
                        {
                            Console.WriteLine("List a door that it needs access to: ");
                            doorResponse.Add(Console.ReadLine());
                            break;
                        }
                    case "n":
                        {
                            addingDoor = false;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Please type either Y or N.");
                            break;
                        }
                }
            }
            _badgeRepo.AddBadge(int.Parse(badgeResponse), doorResponse);
        }

        private void EditBadge()
        {
            Console.WriteLine("What is the badge number to update?");
            string badgeResponse = Console.ReadLine();
            BadgeAccess(int.Parse(badgeResponse));
            Console.WriteLine("");
            Console.WriteLine("What would you like to do? \n" +
                "1. Remove a Door \n" +
                "2. Add a Door \n");
            string editingDoor = Console.ReadLine();
            switch (editingDoor)
            {
                case "1":
                    {
                        Console.WriteLine("Which door would you like to remove?");
                        string doorRemoved = Console.ReadLine();
                        _badgeRepo.RemoveDoorAccess(int.Parse(badgeResponse), doorRemoved);
                        BadgeAccess(int.Parse(badgeResponse));
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    }
                case "2":
                    {
                        Console.WriteLine("Which door would you like to add?");
                        string doorAdded = Console.ReadLine();
                        _badgeRepo.AddDoorAccess(int.Parse(badgeResponse), doorAdded);
                        BadgeAccess(int.Parse(badgeResponse));
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Please select either 1 or 2.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    }
            }
        }

        private void BadgeAccess(int badgeResponse)
        {
            Dictionary<int, List<string>> badgeDict = _badgeRepo.SeeAllBadges();
            Console.WriteLine("");
            Console.WriteLine($"{badgeResponse} has access to: ");
            Badge badge = _badgeRepo.GetBadgeByID(badgeResponse);
            foreach (string doorResponse in badge.DoorNames)
            {
                Console.Write($"{doorResponse} \n");
            }
        }

        private void ListAllBadges()
        {
            Dictionary<int, List<string>> badgeDict = _badgeRepo.SeeAllBadges();
            foreach (KeyValuePair<int, List<string>> badge in badgeDict)
            {
                Console.Write($" Badge #: {badge.Key} \n" +
                " Door Access: "); 
                foreach (string door in badge.Value)
                {
                    Console.Write($"{door}, ");
                }
                Console.WriteLine("");
                Console.WriteLine("----------------");
            }
            Console.WriteLine("Press any key to continue... ");
            Console.ReadKey();
        }


        private void SeedList()
        {
            _badgeRepo.AddBadge(12345, new List<string> { "A7" });
            _badgeRepo.AddBadge(22345, new List<string> { "A1", "A4", "B1", "B2" });
            _badgeRepo.AddBadge(32345, new List<string> { "A4", "A5" });
        }
    }
}
