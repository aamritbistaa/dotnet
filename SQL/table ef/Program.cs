using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace table_ef
{
    static class Program
    {
        static void addall(SqlConnection cnn)
        {
            string q1 = "Insert into Table5 values ('102','Ram') ,('103','Shasdasd');";
            try
            {
            cnn.Open();
            SqlCommand q2 = new SqlCommand(q1, cnn); 
            q2.ExecuteNonQuery();
            cnn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void displayall(SqlConnection cnn)
        {
            String query = "Select * from Table1;";
            try
            {
                cnn.Open();
                SqlCommand q = new SqlCommand(query, cnn);

                SqlDataReader dr = q.ExecuteReader();
                while (dr.Read())
                {
                    //Console.WriteLine(dr);
                    Console.WriteLine(dr.GetString(0));
                    Console.WriteLine(dr.GetString(1));
                }
                dr.Close();

                cnn.Close();
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        static void Main()
        {
            
            SqlConnection cnn;

            string connectiondetail= "Server=DESKTOP-F8B89L4;Database=EF_DatabaseFirst;Trusted_Connection=true";
            cnn = new SqlConnection (connectiondetail);
            displayall(cnn);

            

            Console.ReadLine();
        }
        
    }

}
