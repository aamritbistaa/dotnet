using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Net;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Lan_FTP
{
    class OList
    {
        public string path { get; set; }
        public string name { get; set; }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            string host = "192.168.1.122";
            string port = "21";
            string username = "Spoon";
            string password = "sp@@n";
            //string host = "192.168.";
            //string port = "21";
            //string username = "Amrit";
            //string password = "amrit123";

            string path = "ftp://" + host + ":" + port + "";
            string outputpath = @"C:\Users\amritbista\Desktop\ftpdown\";
            Program obj = new Program();
            //obj.folderContent
            obj.List(username, password, path);

            bool download = false;
            if (download == true)
            {

                obj.List(username, password, path);
                obj.Download(username, password, outputpath);
            }

            obj.Upload(username, password, path);

            Console.ReadLine();
        }

        public List<OList> folderContent = new List<OList>();

        public void List(string username, string password, string path)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(path);
            request.Method = WebRequestMethods.Ftp.ListDirectory;

            request.Credentials = new NetworkCredential(username, password);
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);

            string names = reader.ReadToEnd();
            response.Close();

            string[] words = names.Split();

            foreach (var item in words)
            {
                if (item != "")
                {
                    //just add item
                    if (item.Contains("."))
                    {
                        var ite = item.Split('/');
                        folderContent.Add(
                            new OList
                            {
                                name = ite[0],
                                path = path
                            }
                            );
                    }

                    else
                    {
                        var it = item.Split('/');
                        List(username, password, path + "/" + it[0]);
                    }


                }
            }
            foreach (var item in folderContent)
            {
                Console.WriteLine(item.name + "--" + item.path);
            }

        }
        public void Download(string username, string password, string path_output)
        {
            using (WebClient request = new WebClient())
            {
                request.Credentials = new NetworkCredential(username, password);

                //Download each item
                foreach (var item in folderContent)
                {

                    byte[] fileData = request.DownloadData(item.path + "/" + item.name);

                    var temp_path = item.path.Substring(21);




                    FileAttributes attributes = File.GetAttributes(path_output);
                    if ((attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                    {
                        attributes &= ~FileAttributes.ReadOnly;
                        File.SetAttributes(path_output, attributes);
                    }
                    if (File.Exists(path_output + temp_path) == false)
                    {
                        Directory.CreateDirectory(path_output + temp_path);

                    }
                    using (FileStream file = File.Create(path_output + temp_path + "/" + item.name))
                    {
                        file.Write(fileData, 0, fileData.Length);
                        file.Close();
                    }
                    //folderContent.(item);



                }

                Console.WriteLine(("Download Complete"));
            }
        }

        public void Upload(string username, string password, string path_upload)
        {
            string path = string.Concat(path_upload,"/TestMachine/test.txt");
            try
            //ftp://192.168.1.122:21/TestMachine
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(path);
                request.Method = WebRequestMethods.Ftp.UploadFile;

                request.Credentials = new NetworkCredential(username, password);
                byte[] filecontents = File.ReadAllBytes("test.txt");

                request.ContentLength = filecontents.Length;
                using (Stream requeststream = request.GetRequestStream())
                {
                    requeststream.Write(filecontents, 0, filecontents.Length);

                }


                //using (FileStream fileStream = File.Open("test.txt", FileMode.Open, FileAccess.Read))
                //{
                //    using (Stream requestStream = request.GetRequestStream())
                //    {
                //        fileStream.CopyTo(requestStream);
                //    }
                //}

                Console.WriteLine("Upload complete");
            }
            catch (WebException e)
            {
                String status = ((FtpWebResponse)e.Response).StatusDescription;
                Console.WriteLine(status);
                Console.WriteLine(e.Message);
            }
        }



    }
}

