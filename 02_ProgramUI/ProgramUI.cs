using _02_Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ProgramUI
{
    class ProgramUI
    {
        private ClaimsRepository _claimRepo = new ClaimsRepository();

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
                Console.WriteLine("Choose a Menu Item: \n" +
                    "1. See All Claims \n" +
                    "2. Take Care of Next Claim \n" +
                    "3. Enter a New Claim \n" +
                    "4. Exit Menu");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        {
                            SeeAllClaims();
                            break;
                        }
                    case "2":
                        {
                            TakeCareOfNextClaim();
                            break;
                        }
                    case "3":
                        {
                            EnterNewClaim();
                            break;
                        }
                    case "4":
                        {
                            continueToRun = false;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Please enter an appropriate menu item (1-4).");
                            break;
                        }
                }
            }
        }

        private void SeeAllClaims()
        {
            Queue<Claims> claimQueue = _claimRepo.SeeAllClaims();
            foreach (Claims claim in claimQueue)
            {
                Console.WriteLine($"Claim ID: {claim.ClaimID}");
                Console.WriteLine($"Type: { claim.TypeOfClaim}");
                Console.WriteLine($"Description: {claim.Description}");
                Console.WriteLine($"Amount: ${claim.ClaimAmount}");
                Console.WriteLine($"Date of Accident: {claim.DateOfIncident.ToString("MM/dd/yyyy")}");
                Console.WriteLine($"Date of Claim: {claim.DateOfClaim.ToString("MM/dd/yyyy")}");
                Console.WriteLine($"This Claim is Valid: {claim.IsValid}");
                Console.WriteLine("--------------------");
            }
            Console.WriteLine("Press any key to return to the main menu: ");
            Console.ReadKey();
        }

        private void TakeCareOfNextClaim()
        {
            Claims nextClaim = _claimRepo.SeeNextClaim(); 
            Console.WriteLine("Here are the details for the next claim to be handled: ");
            Console.WriteLine($"Claim ID: {nextClaim.ClaimID}");
            Console.WriteLine($"Type: { nextClaim.TypeOfClaim}");
            Console.WriteLine($"Description: {nextClaim.Description}");
            Console.WriteLine($"Amount: ${nextClaim.ClaimAmount}");
            Console.WriteLine($"Date of Accident: {nextClaim.DateOfIncident.ToString("MM/dd/yyyy")}");
            Console.WriteLine($"Date of Claim: {nextClaim.DateOfClaim.ToString("MM/dd/yyyy")}");
            Console.WriteLine($"This Claim is Valid: {nextClaim.IsValid}");
            Console.WriteLine("--------------------");

            Console.WriteLine("Do you want to deal with this claim now? Type Y or N.");
            string userAnswer = Console.ReadLine().ToLower();
            switch (userAnswer)
            {
                case "y":
                    {
                        _claimRepo.DealWithClaim();
                        Console.WriteLine("This claim has been deleted from the Directory.");
                        break;
                    }
                case "n":
                    {
                        Console.WriteLine("This claim has been returned to the Directory.");
                        break;
                    }
                default:
                    {
                        Console.WriteLine("You have pressed an invalid key. Please enter either Y or N.");
                        break;
                    }
            }
            Console.WriteLine("Press any key to return to the main menu: ");
            Console.ReadKey();
        }

        private void EnterNewClaim()
        {
            Claims claimAdded = new Claims();
            Console.WriteLine("Enter the Claim ID: ");
            int claimID = int.Parse(Console.ReadLine());
            claimAdded.ClaimID = claimID;

            Console.WriteLine("Enter the Claim Type: \n" +
                "1. Car \n" +
                "2. Home \n" +
                "3. Theft");
            int claimType = int.Parse(Console.ReadLine());
            claimAdded.TypeOfClaim = (ClaimType)claimType;

            Console.WriteLine("Enter a Claim Description: ");
            claimAdded.Description = Console.ReadLine();

            Console.WriteLine("Amount of Damage: ");
            string damageAmount = Console.ReadLine();
            claimAdded.ClaimAmount = decimal.Parse(damageAmount);

            Console.WriteLine("Date of Accident (yyyy, mm, dd): ");
            string accidentDate = Console.ReadLine();
            claimAdded.DateOfIncident = DateTime.Parse(accidentDate);

            Console.WriteLine("Date of Claim (yyyy, mm, dd): ");
            string claimDate = Console.ReadLine();
            claimAdded.DateOfClaim = DateTime.Parse(claimDate);

            _claimRepo.EnterNewClaim(claimAdded);
            Console.WriteLine("Press any key to return to the main menu: ");
            Console.ReadKey();
        }

        private void SeedList()
        {
            Claims claimA = new Claims(1, ClaimType.Car, "Car accident on 465", 400.00m, new DateTime(2018, 04, 25), new DateTime(2018, 04, 27));
            Claims claimB = new Claims(2, ClaimType.Home, "House fire in kitchen", 4000.00m, new DateTime(2018, 04, 11), new DateTime(2018, 04, 17));
            Claims claimC = new Claims(3, ClaimType.Theft, "Stolen pancakes", 4.00m, new DateTime(2018, 04, 27), new DateTime(2018, 06, 28));

            _claimRepo.EnterNewClaim(claimA);
            _claimRepo.EnterNewClaim(claimB);
            _claimRepo.EnterNewClaim(claimC);
        }
    }
}
