using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using Woods.Models;


namespace Woods.Factory
{
    public class TrailFactory : IFactory<Trail>
    {
        private string connectionString;
        public TrailFactory()
        {
            connectionString = "server=localhost;userid=root;password=root;port=3306;database=woods;SslMode=None";
        }
        internal IDbConnection Connection
        {
            get
            {
                return new MySqlConnection(connectionString);
            }
        }
        // public void Add(Comment item, int? users_id, int msg_id)
        // {
        //     using (IDbConnection dbConnection = Connection)
        //     {
        //         //$==string interpolation for putting bit of csharp in string
        //         string query = $"Insert into comments (commentbody, users_id, messages_id) values (@commentbody, {users_id}, {msg_id})";
        //         dbConnection.Open();
        //         dbConnection.Execute(query, item);
        //     }
        //}
        // public IEnumerable<Message> FindAll()
        // {
        //     //return "hello";
        //     using (IDbConnection dbConnection = Connection)
        //     {
        //         dbConnection.Open();
        //         return dbConnection.Query<Message>("SELECT * FROM messages");
        //         //return ReturnValue;
        //     }
        // }

    }
}