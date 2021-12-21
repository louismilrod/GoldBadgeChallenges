using _02_Komodo_Claims_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static _02_Komodo_Claims_Repository.Claim;

namespace _02_Komodo_Claims
{
    public class ProgramUI
    {
        public void Run()
        {
            Seed();
            RunApplication();
        }

        public readonly Claims_Repository _repo = new Claims_Repository();
        
        private void RunApplication()
        {            
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Welcome to Claims Adjustment \n" +
                    "1. See All Claims \n" +
                    "2. Take care of next claim \n" +
                    "3. Enter A New Claim \n" +
                    "4. Exit");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        GetAllClaims();                        
                        break;
                    case "2":
                        DoYouWantClaimNow();
                        break;
                    case "3":
                        EnterNewClaim();
                        break;
                    case "4":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Selection");
                        WaitForKey();
                        break;
                }
                Console.Clear();
            }
        }
      

        private void GetAllClaims()
        {
            Console.Clear();
            Queue<Claim> claims = _repo.GetAllClaims();
            foreach (Claim claim in claims)
            {
                Console.WriteLine(claim.ToString());
            }
        }

        private void WaitForKey()
        {
            Console.ReadKey();
        }

        private void Seed()
        {            
            DateTime dateOfIncident = new DateTime(2018, 04, 18);
            DateTime dateOfClaim = new DateTime(2018, 04, 27);
            Claim claimOne = new Claim(1, Claim.ClaimType.Car, "Car Accident on 465.", 400m, dateOfIncident, dateOfClaim);
            _repo.EnterNewClaim(claimOne);

            DateTime dateOfIncidentSeedTwo =new DateTime(2018, 04, 11);
            DateTime dateOfClaimSeedTwo = new DateTime(2018,04,12);
            Claim claimTwo = new Claim(2, Claim.ClaimType.Home, "House fire in kitchen", 4000m, dateOfIncidentSeedTwo, dateOfClaimSeedTwo);
            _repo.EnterNewClaim(claimTwo);

            DateTime dateOfIncidentSeedThree = new DateTime(2018, 04, 27);
            DateTime dateOfClaimSeedThree = new DateTime(2018, 06, 01);
            Claim claimThree = new Claim(3, Claim.ClaimType.Theft, "Stolen Pancakes", 4m, dateOfIncidentSeedThree, dateOfClaimSeedThree);
            _repo.EnterNewClaim(claimThree);
        }

        //Do you want to deal with this claim now(y/n)? y
        //When the agent presses 'y', the claim will be pulled off the top of the queue.If the agent presses 'n', it will go back to the main menu.

        public void DoYouWantClaimNow()
        {
            Console.Clear();
            var nextClaim = _repo.GetNextClaim();
            Console.WriteLine(nextClaim.ToString());
            
            Console.WriteLine("Do you want to deal with this claim now y/n?");
            string response = Console.ReadLine();           
            

            if (response == "Y".ToLower())
            {
               var success =  _repo.RemoveClaim();
                if (success)
                {
                    Console.WriteLine("SUCCESS");
                }else
                {
                    Console.WriteLine("FAIL");
                }
            }
            WaitForKey();           
        }

        public void EnterNewClaim()
        {
            Console.Clear();
            Claim claim = new Claim();

            Console.WriteLine("Enter claim ID");
            claim.ClaimID = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine("Enter claim Type:\n" +
                "1.Car\n " +
                "2.Home\n" +
                "3.Theft\n " +
                "4.Other\n");
            int userInput = int.Parse(Console.ReadLine());
            var convert = (ClaimType)userInput;
            claim.TypeOfClaim = convert;

            Console.WriteLine("Enter Description");
            claim.ClaimDescription = Console.ReadLine();
            Console.WriteLine("Enter amount for claim");
            claim.ClaimAmount = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("When did this incident occur?");
            claim.DateOfIncident = Convert.ToDateTime(Console.ReadLine());
            claim.DateOfClaim = DateTime.Now; 
            
            _repo.EnterNewClaim(claim);
        }


    }
}
