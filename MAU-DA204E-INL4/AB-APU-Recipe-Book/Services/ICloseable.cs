using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB_APU_Recipe_Book.Services
{
    internal interface ICloseable
    {
        public object DialogResultCustom { get; set; }
        void Close();
    }
}
