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
using Newtonsoft.Json;
using System.ComponentModel;


namespace July3
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

        public class obj
        {
            public string[] content;
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

                //List<Data> customerlist = JsonConvert.DeserializeObject<List<Data>>(responseFromServer);
                //var stringData = JsonConvert.SerializeObject(customerlist[0]);
                //Console.WriteLine(customerlist);
                //Console.WriteLine(customerlist.Count);
                //foreach (var items in customerlist)
                //{
                //    Console.WriteLine("\n\n\nHello item"+ items.content);
                //}


                List<Data> customersList = JsonConvert.DeserializeObject<List<Data>>(responseFromServer);
                List<Data> favlist = new List<Data>();
                foreach (var item in customersList)
                {
                    if (item.favoriteFruit == "banana")
                    {
                        Console.WriteLine(JsonConvert.SerializeObject(item));
                    }

                }



                //List<Data> favbana = new List<Data>();

                //foreach (var customer in customersList)
                //{
                //    if (customer.favoriteFruit == "banana")
                //    {
                //        Console.WriteLine($"id:{customer._id},index:{customer.index},guid:{customer.guid},isActive:{customer.isActive},balance:{customer.balanace},picture:{customer.picture}, age:{customer.age},eyeColor:{customer.eyeColor},name:{customer.name},gender:{customer.gender},company:{customer.company},email:{customer.email},phone:{customer.phone},address:{customer.address},about:{customer.about},registered:{customer.registered},latitude:{customer.latitude},longitute:{customer.longitude},tags:");
                //        foreach (var item in customer.tags)
                //        {
                //            Console.WriteLine(item);
                //        }
                //        Console.WriteLine();
                //        foreach (var item in customer.friends)
                //        {
                //            Console.WriteLine($"id: {item.id}, name:{item.name}");
                //        }
                //        Console.WriteLine($"greetings:{customer.greeting}, favouritefruit:{customer.favoriteFruit}");
                //    }
                //    //Console.WriteLine("\n\n");
                //}
                reader.Close();
                dataStream.Close();
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
