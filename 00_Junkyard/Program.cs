using _02_Komodo_Claims_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00_Junkyard
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<Claim> claims = new Queue<Claim>();

            Claim claimA = new Claim(1, Claim.ClaimType.Theft, "stuff got took", 4.00m, new DateTime (2018, 04, 15), new DateTime(2018, 04, 18));
            Claim claimB = new Claim(2, Claim.ClaimType.Theft, "stuff got took", 4.00m, new DateTime(2018, 04, 15), new DateTime(2018, 04, 18));
            Claim claimC = new Claim(3, Claim.ClaimType.Theft, "stuff got took", 4.00m, new DateTime(2018, 04, 15), new DateTime(2018, 04, 18));

            claims.Enqueue(claimA);
            claims.Enqueue(claimB);
            var nextClaim = claims.Peek();
            Console.WriteLine($"{nextClaim.ClaimID}, {nextClaim.ClaimDescription}");
            claims.Dequeue();
            nextClaim = claims.Peek();
            Console.WriteLine(nextClaim.ClaimID);
            Console.ReadKey();
        }
    }
}
