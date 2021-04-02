using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claims
{
    public class ClaimsRepository
    {
        //Methods Needed: SeeAllClaims, SeeNextClaim, EnterNewClaim
        //Added Methods: DealWithClaim (processes / removes = dequeue)

        private Queue<Claims> _claimDirectory = new Queue<Claims>();

        public Queue<Claims> SeeAllClaims()
        {
            return _claimDirectory;
        }

        public Claims SeeNextClaim()
        {
            return _claimDirectory.Peek();
        }

        public Claims DealWithClaim()
        {
            return _claimDirectory.Dequeue();
        }

        public void EnterNewClaim(Claims newClaim)
        {
            _claimDirectory.Enqueue(newClaim);
        }

        
    }
}
