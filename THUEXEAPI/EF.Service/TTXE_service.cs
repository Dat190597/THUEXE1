using EF.Contract;
using EF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace EF.Service
{
    public class TTXE_service : ITTXE
    {
        private THUEXE_Entities dbContext = new THUEXE_Entities(); 

       
        public void Add(TTXE ttxe)
        {
            
            try
            {
                
                dbContext.TTXEs.Add(ttxe);
                dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
                
            }
            
        }

        public void Delete(string TTX_ID)
        {
            try
            {
                var entity = dbContext.TTXEs.Where(x => x.TTX_BSX == TTX_ID).FirstOrDefault();
                dbContext.TTXEs.Remove(entity);
                dbContext.SaveChanges();
        }
            catch (Exception e)
            {
                throw e;
            }
}

        public List<TTXE> GetTTXE()
        {
            var ttxe = dbContext.TTXEs.ToList();
           return ttxe;
        }


        public void Update(string bsx, string dongia)
        {
            object[] param =
            {
                new  SqlParameter("@TTX_BSX", bsx),
                new  SqlParameter("@TTX_DONGIA", dongia)
            };
            dbContext.Database.ExecuteSqlCommand("exec updateTTXE @TTX_BSX, @TTX_DONGIA",param);
        }

        public TTXE Find(string bsx)
        {
            object[] param =
            {
                new  SqlParameter("@TTX_BSX", bsx)
            };
            var data = dbContext.Database.SqlQuery<TTXE>("select * from TTXE where TTX_BSX = @TTX_BSX", param).ToList();

            return data.FirstOrDefault();
        }
    }
}
