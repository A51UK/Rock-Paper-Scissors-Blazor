using SharedObjects.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedObjects
{
    public class SharedFunctions
    {
        public Move GetMove(int move) => move switch
        {
            0 => Move.Rock,
            1 => Move.Paper,
            2 => Move.Scissors,
            _ => throw new NotImplementedException()
        };
    }
}
