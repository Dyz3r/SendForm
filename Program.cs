using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.Net;
using System.IO;

namespace SendForm
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Random random = new Random();

                Console.WriteLine("Enter the amount of loops you want this form to submit (must be a number!):");
                int amount = int.Parse(Console.ReadLine());

                for (int i = 0; i < amount; i++)
                {
                    string name = "name" + random.Next(10000);
                    string password = "passwd" + random.Next(10000);
                    string email = "email.test." + random.Next(1000) + "@gmail.com";

                    // EDIT THESE FIELDS TO WORK FOR YOUR FORM SUBMIT.
                    NameValueCollection nvc = new NameValueCollection();
                    nvc.Add("name", name);
                    nvc.Add("password", password);
                    nvc.Add("email", email);
  
                    // EDIT THE WEBSITE IT SENDS THE DATA TO
                    string url = "http://test.com/submit";

                    WebClient client = new WebClient();
                    client.UploadValues(url, nvc);

                    File.AppendAllText("bot-log.txt", "Credentials: " + name + "," + password + Environment.NewLine);
                    Console.WriteLine("Added " + name + " with password " + password);

                }

                Console.WriteLine("Finished!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.Read();
        }
    }
}
