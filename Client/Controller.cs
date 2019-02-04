using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Service;

namespace Client
{
    public class Controller : ServiceClient
    {
        private Controller() { }
        private static Controller m_Instance { get; set; }
        public static Controller Instance
        {
            get
            {
                if(m_Instance == null)
                {
                    m_Instance = new Controller();
                }
                return m_Instance;
            }
        }
    }
}