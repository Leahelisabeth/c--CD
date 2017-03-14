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
            Artist vernonQ = Artists.Where(artist => artist.Hometown =="Mount Vernon").Single();
            System.Console.WriteLine(vernonQ.ArtistName);
            //vernonQ.Age, 
            //Who is the youngest artist in our collection of artists?
            Artist youngA = Artists.OrderBy(artist => artist.Age).First();
            System.Console.WriteLine(youngA.ArtistName);
            //Display all artists with 'William' somewhere in their real name
            List<Artist> wills = Artists.Where(artist => artist.RealName.Contains("William")).ToList();

            //Display the 3 oldest artist from Atlanta
            List<Artist> old3 = Artists.Where(artist => artist.Hometown =="Atlanta")
                .OrderByDescending(artist => artist.Age)
                .Take(3)
                .ToList();
            //Display names of all groups less than 8 char in length
            List<Group> lesst8 = Groups.Where(groups => groups.GroupName.Length < 8).ToList();
            //(Optional) Display the Group Name of all groups that have members that are not from New York City
            List<string> noNY = Artists
                            .Join(Groups, artist => artist.GroupId, group => group.Id, (artist, group) => 
                            { artist.Group = group; 
                            return artist;
                            }).Where(artist => (artist.Hometown != "New York City" && artist.Group != null))
                            .Select(artist => artist.Group.GroupName)
                            .Distinct()//prevents duplicate values in a list
                            .ToList();
            //(Optional) Display the artist names of all members of the group 'Wu-Tang Clan'

        }
    }
}
