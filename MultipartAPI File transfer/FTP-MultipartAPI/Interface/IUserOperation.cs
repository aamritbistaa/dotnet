using FTP_MultipartAPI.Model;

namespace FTP_MultipartAPI.Interface
{
    public interface IUserOperation
    {
        public void additem(Users obj);
        public int removeitem(int id, string name);
        public List<Users> getitem();
        public int updateitem(Users obj);

    }
}
