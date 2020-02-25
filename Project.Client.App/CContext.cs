using Project.Client.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Client.App
{
    public class CContext
    {
        private static ContactManagementDbContext m_instance = null;

        private CContext() { }

        public static ContactManagementDbContext Instance
        {
            get
            {
                lock(m_instance)
                {
                    if(m_instance == null)
                    {
                        m_instance = new ContactManagementDbContext();
                    }
                    return m_instance;
                }
            }
        }
    }
}
