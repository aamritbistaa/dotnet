using CRUD_SP.Models;
using System.Data;
using System.Data.SqlClient;

namespace CRUD_SP.Service
{
    public class UserDAL
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-F8B89L4;Initial Catalog=CRUDstoredprocedure;User ID=sa;Password=p@ssw0rd");

        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        public List<UserModel> GetUsers()
        {
            cmd = new SqlCommand("sp_select",conn);
            cmd.CommandType = CommandType.StoredProcedure;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);

            List<UserModel> list = new List<UserModel>();
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new UserModel()
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    Name = dr["Name"].ToString(),
                    Email = dr["Email"].ToString(),
                    Age = Convert.ToInt32(dr["Age"])

                });
            }
            return list;
        }
        public bool InsertUser(UserModel user)
        {
            cmd = new SqlCommand("sp_insert", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", user.Name);

            cmd.Parameters.AddWithValue("@email", user.Email);
            cmd.Parameters.AddWithValue("@age", user.Age);
            conn.Open();
            int r = cmd.ExecuteNonQuery();
            if (r > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }


}
