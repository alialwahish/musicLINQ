using System;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Collections to work with
            List<Artist> Artists = JsonToFile<Artist>.ReadJson();
            List<Group> Groups = JsonToFile<Group>.ReadJson();

            //========================================================
            //Solve all of the prompts below using various LINQ queries
            //========================================================

            //There is only one artist in this collection from Mount Vernon, what is their name and age?
            var all = from art in Artists
                      where art.Hometown == "Mount Vernon"
                      select art;
            Console.WriteLine("The Artist's from Mount Vernon:");
            foreach (var a in all)
            {
                Console.WriteLine("Name: " + a.RealName + " Age: " + a.Age);
            }
            Console.WriteLine("--------------------------------------");

            // //Who is the youngest artist in our collection of artists?
            var arti = from a in Artists select a;
            Artist yunArti = Artists.First();
            foreach (var a in arti)
            {
                if (a.Age < yunArti.Age)
                {
                    yunArti = a;
                }
            }
            Console.WriteLine("The Youngest Artist is: " + yunArti.ArtistName + " Age: " + yunArti.Age);
            Console.WriteLine("--------------------------------------");





            // //Display all artists with 'William' somewhere in their real name
            Console.WriteLine("All Artists with william realname");
            foreach (var a in arti)
            {
                if (a.RealName.Contains("William"))
                {
                    Console.WriteLine(a.ArtistName+" Real Name"+a.RealName);
                }
            }

            Console.WriteLine("--------------------------------------");

            //Display the 3 oldest artist from Atlanta
            var oldest3Artists = from a in Artists
                                 where a.Hometown == "Atlanta"
                                 orderby a.Age descending
                                 select a;
            int i = 0;
            Console.WriteLine("the 3 oldest artist from Atlanta:");
            foreach (var item in oldest3Artists)
            {
                if (i <= 2)
                {
                    Console.WriteLine("Artist Name: " + item.ArtistName + " Age: " + item.Age);

                }
                else
                {
                    break;
                }
                i++;
            }

            Console.WriteLine("--------------------------------------");

            //(Optional) Display the Group Name of all groups that have members that are not from New York City
            var allGrpsNotFrmNy = from a in Artists
                                  where a.Hometown != "New York City"
                                  join g in Groups on a.GroupId equals g.Id
                                  select new { ArtistName = a.ArtistName, HomeTown = a.Hometown, GroupName = g.GroupName, };

            foreach (var ag in allGrpsNotFrmNy)
            {
                Console.WriteLine(ag.ArtistName + " " + ag.GroupName + " " + ag.HomeTown);
            }

            Console.WriteLine("--------------------------------------");


            //(Optional) Display the artist names of all members of the group 'Wu-Tang Clan'
            var allArtsNamWuTan = from a in Artists
                                  join g in Groups on a.GroupId equals g.Id
                                  where g.GroupName == "Wu-Tang Clan"
                                  select a;
            Console.WriteLine("artist names of all members of the group 'Wu-Tang Clan");
            foreach (var ag in allArtsNamWuTan)
            {
                Console.WriteLine(ag.ArtistName);
            }

        }
    }
}
