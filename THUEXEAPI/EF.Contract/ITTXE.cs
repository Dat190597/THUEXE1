using EF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Contract
{
    public interface ITTXE
    {
        void Add(TTXE ttxe);

        void Delete(string TTX_ID);

        void Update(string TTX_ID, string DONGIA);

        TTXE Find(string TTX_ID);

        List<TTXE> GetTTXE();
    }
}
