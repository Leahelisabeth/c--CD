using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using TheWall.Models;


namespace TheWall.Factory
{
    public class UserFactory : IFactory<User>
    {
        private string connectionString;
        public UserFactory()
        {
            connectionString = "server=localhost;userid=root;password=root;port=3306;database=thewall;SslMode=None";
        }
        internal IDbConnection Connection
        {
            get
            {
                return new MySqlConnection(connectionString);
            }
        }
        public void Add(User item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = "Insert into users (FirstName, LastName, Email, Password) values (@FirstName, @LastName, @Email, @Password)";
                dbConnection.Open();
                dbConnection.Execute(query, item);
            }
        }
        public IEnumerable<User> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<User>("SELECT * FROM users");
            }
        }
        public User LoginValid(string Email)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string Query = $"SELECT * FROM users WHERE Email = '{Email}'";
                dbConnection.Open();
                return dbConnection.Query<User>(Query).FirstOrDefault();
            }
        }
        public User GetOne(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string Query = $"SELECT * FROM users WHERE id = '{id}'";
                dbConnection.Open();
                return dbConnection.Query<User>(Query).FirstOrDefault();
            }
        }
        public User GetMsg(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                var query =
                @"
        SELECT * FROM users WHERE id = @Id;
        SELECT * FROM messages WHERE users_id = @Id;
        ";

                using (var multi = dbConnection.QueryMultiple(query, new { Id = id }))
                {
                    var user = multi.Read<User>().Single();
                    user.messages = multi.Read<Message>().ToList();
                    return user;
                }
            }
        }
    }
}