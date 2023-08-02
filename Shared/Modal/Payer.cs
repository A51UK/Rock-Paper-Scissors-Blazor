using SharedObjects.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedObjects.Modal
{
    public class Payer
    {
        public Payer()
        {
        }

        public int payerScore { get; set; } = 0;
        public Move move { get; set; } = Move.Paper;
    }
}
