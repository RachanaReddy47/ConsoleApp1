using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ConsoleApp1.NewFolder1
{
    class spex1
    {
        static void Main(string[] args)
        {
            int i = int.Parse(Console.ReadLine());
            int j= int.Parse(Console.ReadLine());


            SqlConnection Con = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Demo;Data Source=DESKTOP-FTR5U2I");
            SqlDataAdapter Adp = new SqlDataAdapter("Example1", Con);
            Adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            //Input parameter of stored procedure
            Adp.SelectCommand.Parameters.AddWithValue("@a", i);
            //SqlParameter p = new SqlParameter("@a", SqlDbType.Int);
            //p.Value = i;
            //Adp.SelectCommand.Parameters.Add(p);

            Adp.SelectCommand.Parameters.AddWithValue("@b", j);
            //output parameter of stored procedure
            SqlParameter p = new SqlParameter("@c", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            Adp.SelectCommand.Parameters.Add(p);

            SqlParameter p1 = new SqlParameter("@d", SqlDbType.Int);
            p1.Direction = ParameterDirection.Output;
            Adp.SelectCommand.Parameters.Add(p1);
            DataSet DS = new DataSet();
            Adp.Fill(DS);
            Console.WriteLine(p.Value);
            Console.WriteLine(p1.Value);
            Console.Read();




        }
    }
}
