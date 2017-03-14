using System;
using System.Collections.Generic;
using DbConnection;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //DbConnector.Query("insert into user (FirstName, LastName, FavNum) values ('Big', 'Bert', 8));
            // Console.WriteLine(DbConnector.Query("select * from user"));

            List<Dictionary<string, object>> users = DbConnector.Query("select * from user");
            foreach (var user in users){
                
                System.Console.WriteLine(user["FirstName"]);
            }
        }
    }
}
