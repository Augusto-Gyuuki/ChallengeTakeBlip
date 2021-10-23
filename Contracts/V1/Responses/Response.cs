using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeTakeBlip.Contracts.V1.Responses
{
    public class Response<T>
    {
        public T firstRepository  { get; set; }
        public T secondRepository   { get; set; }
        public T thirdRepository { get; set; }
        public T fourthRepository   { get; set; }
        public T fifthRepository { get; set; }
    }
}
