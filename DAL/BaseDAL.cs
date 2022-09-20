using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BaseDAL
    {
        protected Entities db;
        public BaseDAL()
        {
            db = new Entities();
        }
    }
}
