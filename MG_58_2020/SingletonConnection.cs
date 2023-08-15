using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG_58_2020
{
    public class SingletonConnection
    {
        public SqlConnection Connection { get; private set; }
        private static object _obj = new object();
        private SingletonConnection()
        {
            Connection = new SqlConnection(@"Data Source=(localdb)\mg_58_2020;Initial Catalog=mg_58_2020;Integrated Security=true");
        }

        private static SingletonConnection _instance = null;
        public static SingletonConnection Instance
        {
            get
            {
                lock(_obj)
                {
                    if (_instance == null)
                        _instance = new SingletonConnection();
                    return _instance;
                }
            }
        }
    }
}