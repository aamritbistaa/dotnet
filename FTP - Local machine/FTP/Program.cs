using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace FTP
{
    public class Program
    {
        static void Main(string[] args)
        {
            string username = "amrit";
            string password = "amrit123";

            string ftphost = "192.168.1.97:21/";
            string ftpfilepath = "Ftp/";
            string path = "ftp://" + ftphost + ftpfilepath;

            string downloadpath = "ftp://" + ftphost + ftpfilepath + "NewFIle/hello.txt";
            string outputpath = @"C:\Users\amritbista\Desktop\test.txt";

            string uploadpath = path + "test.txt";
            Program obj = new Program();
            

            obj.ListFileFTP(username, password, path);
            obj.UploadFileFTP(username,password,uploadpath);
            //obj.DownloadFileFTP(username, password, downloadpath, outputpath);
            ;
            /*          Server side 
             *          Folder that can be access should be given
             *          setup the server such that it listens to incoming request 
             *          server should be stated which user can access it
            */

            /*          Client side
             *          provide the necessary permission passing the username
             *          passing the user details to server setup the connection
             */
            Console.ReadLine();

            //Upload file

            //client.DownloadFile(
            //    "ftp://ftp.example.com/remote/path/file.zip", @"C:\local\path\file.zip");
            //        FtpWebRequest request =
            //(FtpWebRequest)WebRequest.Create("localhost:21");
            //        request.Credentials = new NetworkCredential(username, password);
            //        request.Method = WebRequestMethods.Ftp.DownloadFile;
            //        using (Stream ftpStream = request.GetResponse().GetResponseStream())
            //        using (Stream fileStream = File.Create(@"D:\Ftp\Ftp\NewFIle\" + "hello.txt"))
            //        {
            //            ftpStream.CopyTo(fileStream);
            //        }
        }


        //Add files/folder permission to user with current username

        public static void SetFolderPermission(string folderPath)
        {
            var directoryInfo = new DirectoryInfo(folderPath);
            var directorySecurity = directoryInfo.GetAccessControl();
            var currentUserIdentity = WindowsIdentity.GetCurrent();
            var fileSystemRule = new FileSystemAccessRule(currentUserIdentity.Name,
                                                          FileSystemRights.Read,
                                                          InheritanceFlags.ObjectInherit |
                                                          InheritanceFlags.ContainerInherit,
                                                          PropagationFlags.None,
                                                          AccessControlType.Allow);

            directorySecurity.AddAccessRule(fileSystemRule);
            directoryInfo.SetAccessControl(directorySecurity);
        }


        public void ListFileFTP(string username, string password, string path)
        {

            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(path);
            request.Method = WebRequestMethods.Ftp.ListDirectory;

            request.Credentials = new NetworkCredential(username, password);
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            string names = reader.ReadToEnd();

            Console.WriteLine(names);
            response.Close();

        }
        public void UploadFileFTP(string username, string password, string path)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(path);
            request.Method = WebRequestMethods.Ftp.UploadFile;

            // This example assumes the FTP site uses anonymous logon.
            request.Credentials = new NetworkCredential(username, password);

            // Copy the contents of the file to the request stream.
            using (FileStream fileStream = File.Open("testfile.txt", FileMode.Open, FileAccess.Read))
            {
                using (Stream requestStream = request.GetRequestStream())
                {
                    fileStream.CopyTo(requestStream);
                }
            }

            Console.WriteLine("Upload complete");
        }
        public void DownloadFileFTP(string username, string password, string path, string outputpath)
        {
            using (WebClient request = new WebClient())
            {
                request.Credentials = new NetworkCredential(username, password);
                byte[] fileData = request.DownloadData(path);
                SetFolderPermission(@"C:\Users\amritbista\Desktop");
                using (FileStream file = File.Create(outputpath))
                {
                    file.Write(fileData, 0, fileData.Length);
                    file.Close();
                }
                Console.WriteLine(("Download Complete"));
            }
        }
    }


}
