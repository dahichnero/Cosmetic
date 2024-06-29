using CosmeticHealth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmeticHealth
{
    public class Session
    {
        private Session()
        {
            context=new CosmeticHeathContext();
        }
        private static Session? instance;
        public static Session Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Session();
                }
                return instance;
            }
        }
        private CosmeticHeathContext context;
        public CosmeticHeathContext Context => context;
    }
}
