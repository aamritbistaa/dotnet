using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using System.IO;
using System.Xml.Linq;
using System.ComponentModel;
using Newtonsoft.Json;

namespace July123
{
    internal class Program
    {
        class Data
        {
            public string _id { get; set; }
            public int index { get; set; }
            public string guid { get; set; }
            public bool isActive { get; set; }
            public string balanace { get; set; }
            public string picture { get; set; }
            public int age { get; set; }
            public string eyeColor { get; set; }
            public string name { get; set; }
            public string gender { get; set; }
            public string company { get; set; }
            public string email { get; set; }
            public string phone { get; set; }
            public string address { get; set; }
            public string about { get; set; }
            public string registered { get; set; }
            public long latitude { get; set; }
            public long longitude { get; set; }
            public string[] tags { get; set; }
            public friend[] friends { get; set; }
            public string greeting { get; set; }
            public string favoriteFruit { get; set; }
        }
        public class friend
        {
            public int id { get; set; }
            public string name { get; set; }
        }

        public class newobj 
        {
            public newobj()
            {
                this.friendscollection = new List<string>();
            }
            public string name { get; set; }
            public string gender { get; set; }
            public string company { get; set; }
            public string tags { get; set; }
            public List<string> friendscollection { get; set; }


        }

        static void Main(string[] args)
        {


            try
            {

                // Create a request for the URL. 		
                WebRequest request = WebRequest.Create("https://mocki.io/v1/b96cd527-18c7-4427-920d-73f3c1b8d687");

                // If required by the server, set the credentials.
                request.Credentials = CredentialCache.DefaultCredentials;

                // Get the response.
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                // Display the status.
                //Console.WriteLine(response.StatusDescription);

                // Get the stream containing content returned by the server.
                Stream dataStream = response.GetResponseStream();


                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);

                Console.WriteLine(reader + "Reader details \n \n ");
                // Read the content.
                var responseFromServer = reader.ReadToEnd();

                // Display the content.
                //Console.WriteLine(responseFromServer);

                List<Data> responselist = JsonConvert.DeserializeObject<List<Data>>(responseFromServer);
                reader.Close();

                List<newobj> filteredlist = new List<newobj>();
                List<string> friendslist;

                foreach (var item in responselist)
                {
                    friendslist = new List<string>();
                    foreach (var item1 in item.friends)
                    {

                        if (item1.name == "Roach Walker")
                        {
                            string tag = "";
                            foreach (var item2 in item.tags)
                            {
                                tag = tag + item2;
                            }
                            foreach (var item2 in item.friends)
                            {
                                friendslist.Add(item2.name);
                            }
                            
                            
                            newobj temp = new newobj()
                            {
                                name = item.name,
                                gender = item.gender,
                                company = item.company,
                                tags = tag,
                                friendscollection = friendslist
                                //friendscollection.AddRange(friendslist)
                            };

                            filteredlist.Add(temp);
                            //friendslist.Clear();


                        }
                        //friendslist.Clear();

                    }
                }

                
                dataStream.Close();
                foreach (var item in filteredlist)
                {
                    Console.WriteLine(JsonConvert.SerializeObject(item));
                }
                response.Close();

            }
            catch (System.Exception ex)
            {

                throw ex;
            }
            Console.ReadKey();


        }
    }
}
