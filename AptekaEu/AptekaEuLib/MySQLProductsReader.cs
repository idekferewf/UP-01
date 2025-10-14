using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace AptekaEuLib
{
    public class MySQLProductsReader : IProductsRepository
    {
        private string myConnectionString = "server=127.0.0.1;uid=root;pwd=vertrigo;database=aptekaeu;";

        public bool AddProduct(Product product)
        {
            return true;
        }
    }
}
