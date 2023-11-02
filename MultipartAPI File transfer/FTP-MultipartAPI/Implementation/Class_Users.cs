using FTP_MultipartAPI.Interface;
using FTP_MultipartAPI.Model;
using System.Xml.Linq;

namespace FTP_MultipartAPI.Implementation
{
    public class Class_Users:IUserOperation
    {
        List<Users> users = new List<Users>() { new Users {Id=10,Name="Ram" }, new Users { Id = 20, Name = "Ramesh" } };
        public void additem(Users obj)
        {
            users.Add(obj);
        }
        public int removeitem(int id, string name) 
        {
            var record = users.FirstOrDefault(x => ((x.Id == id) && (x.Name == name)));
            if (record!=null)
            {
                users.Remove(record);                
                return 1;
            }
            else
            { 
                return 0;
            }
        }
        public List<Users> getitem()
        {
            return users;
        }
        public int updateitem(Users obj)
        {
            var record = users.FirstOrDefault(x => ((x.Id == obj.Id) && (x.Name == obj.Name)));
            if (record != null)
            {
                record.Name = obj.Name;
                record.Id = obj.Id;
                return 1;
            }
            else
            {
                return 0;
            }

        }
    }
}
