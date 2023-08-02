using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedObjects.Modal
{
    public class Payers
    {
        public Payers() { }

        public Payer Human { get; set; } = new Payer();

        public Payer Bot { get; set; } = new Payer();
    }
}
