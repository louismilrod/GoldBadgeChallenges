using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Komodo_Claims_Repository
{
    public class Claim
    {
        public enum ClaimType
        {
            Car = 1,
            Home,
            Theft,
            Other
        }

        public Claim()
        {

        }

        public Claim(int claimID, ClaimType claimTypeOne, string claimDescription, decimal claimAmount, DateTime dateOfIncident, DateTime dateOfClaim)
        {
            ClaimID = claimID;
            TypeOfClaim = claimTypeOne;
            ClaimDescription = claimDescription;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
        }
        public int ClaimID { get; set; }
        public ClaimType TypeOfClaim { get; set; }
        public string ClaimDescription { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public decimal ClaimAmount { get; set; }
        public bool IsValid 
        { 
            get
            {
                var span = DateOfClaim - DateOfIncident;
                if (span.TotalDays > 30)
                {
                    return false;
                }
                return true;
            }
        }

        //TimeSpan Span = DateTimeA-DateTimeB
        //Span.Days > 30

        public override string ToString()
        {
            return $"{ClaimID}\n" +
                $"{TypeOfClaim}\n" +
                $"{ClaimDescription}\n" +
                $"{DateOfIncident}\n" +
                $"{DateOfClaim}\n" +
                $"{ClaimAmount}\n" +
                $"{IsValid}\n";

        }




    }
}
