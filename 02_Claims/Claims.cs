using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claims
{
    /*
     * Komodo has a bug in its software and needs some new code.

The Claim has the following properties:
ClaimID
ClaimType
Description
ClaimAmount
DateOfIncident
DateOfClaim
IsValid
Komodo allows an insurance claim to be made up to 30 days after an incident took place.If the claim is not in the proper time limit, it is not valid.

A ClaimType could be the following:
Car
Home
Theft
*/

    public enum ClaimType { Car, Home, Theft };
    
    public class Claims
    {
        public int ClaimID { get; set; }
        public ClaimType TypeOfClaim { get; set; }
        public string Description { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid
        {
            get
            {
                TimeSpan validTime = DateOfClaim - DateOfIncident;
                if (validTime.Days <= 30)
                {
                    return true;
                }
                return false;
            }
        }
        public Claims() { }

        public Claims(int claimNumber, ClaimType typeOfClaim, string description, decimal claimAmount, DateTime incidentDate, DateTime claimDate)
        {
            ClaimID = claimNumber;
            TypeOfClaim = typeOfClaim;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = incidentDate;
            DateOfClaim = claimDate;
        }
    }
}
