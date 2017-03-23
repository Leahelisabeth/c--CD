using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using TheWall.Models;


namespace TheWall.Factory
{
    public class MessageFactory : IFactory<Message>
    {
        private string connectionString;
        public MessageFactory()
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
        public void Add(Message item, int? users_id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                //$==string interpolation for putting bit of csharp in string
                string query = $"Insert into messages (content, users_id) values (@content, {users_id})";
                dbConnection.Open();
                dbConnection.Execute(query, item);
            }
        }
        public IEnumerable<Message> FindAll()
        {
            //return "hello";
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Message>("SELECT * FROM messages");
                //return ReturnValue;
            }
        }
        public Message GetOne(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string Query = $"SELECT * FROM messages WHERE id = '{id}'";
                dbConnection.Open();
                return dbConnection.Query<Message>(Query).FirstOrDefault();
            }
        }
        public IEnumerable<Message> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string Query = "SELECT * FROM messages JOIN users ON messages.users_id = users.id";
                string Query2 =  "SELECT * FROM comments Join users ON comments.users_id = users.id";
                dbConnection.Open();
                var messages_ = dbConnection.Query<Message, User, Message>(Query, (message, user) =>
                {
                    message.user = user;
                    return message;
                });
                var comments_ = dbConnection.Query<Comment, User, Comment>(Query2, (comment, user) =>
                {
                    comment.user = user;
                    return comment;
                });
                List<Message> msg_cm = messages_.GroupJoin(comments_, message => message.id, 
                comment => comment.messages_id,
                (message, comments) => { message.comments = comments.ToList(); return message;} ).ToList();

                //linq group join goes here
                return msg_cm;
            }

        }
        public Message GetCms(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                var query =
                @"
        SELECT * FROM messages WHERE id = @Id;
        SELECT * FROM comments WHERE messages_id = @Id;
        ";

                using (var multi = dbConnection.QueryMultiple(query, new { Id = id }))
                {
                    var message = multi.Read<Message>().Single();
                    message.comments = multi.Read<Comment>().ToList();
                    return message;
                }
            }
        }
    }
}