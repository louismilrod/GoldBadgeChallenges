using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Komodo_Claims_Repository
{
    public class Claims_Repository
    {
        public readonly Queue<Claim> _claimsDirectory = new Queue<Claim>(); //do not work like lists, list have add and remove, queue just dial up who is next

        //Enqueue() to add Dequeue() to retrieve count propery will show the amount of elements in queue
        //use foreach loop to show each element in the loop peak() will show the next

        public Queue<Claim> GetAllClaims()  //get all the claims
        {
            return _claimsDirectory;
        }

        //take care of all claims
        public Claim GetNextClaim()
        {
            Claim claim = _claimsDirectory.Peek();
            return claim;
        }

        //remove existing claim
        public void ClearClaimList()
        {
            _claimsDirectory.Clear();

        }
        //enter new claim
        public void EnterNewClaim(Claim claim)
        {
            _claimsDirectory.Enqueue(claim);
        }

        //remove single claim
        public bool RemoveClaim()
        {
            if (_claimsDirectory.Count > 0)
            {
                _claimsDirectory.Dequeue();
                return true;
            }
            return false;
        }
    }
}
