using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using MySql.Data.MySqlClient;
using quotingDojo.Models;

namespace quotingDojo.Factories
{
    public class QuoteFactory : IFactory<Quote>
    {
        private string connectionString;
        public QuoteFactory()
        {
            connectionString = "server=localhost;userId=root;password=root;port=3306;database  =quote;SslMode=None";
        }

        internal IDbConnection Connection
        {
            get {
                return new MySqlConnection(connectionString);
            }
        }

        public void Add(Quote Item)
        {
            using(IDbConnection dbConnection = Connection)
            {
                string Query = "INSERT INTO quote (user, content) VALUES (@user, @content)";
                dbConnection.Open();
                dbConnection.Execute(Query, Item);
            }
        }

        public IEnumerable<Quote> FindAll()
        {
            using(IDbConnection dbConnection = Connection)
            {
                string Query = "SELECT * FROM quote ORDER BY createdAt";
                dbConnection.Open();
                return dbConnection.Query<Quote>(Query);
            }
        }

        public Quote GetQuoteById(int Id)
        {
            using(IDbConnection dbConnection = Connection)
            {
                string Query = $"SELECT * FROM quote WHERE id = {Id} LIMIT 1";
                dbConnection.Open();
                return dbConnection.Query<Quote>(Query).First();
            }
        }

        // public void UpdateQuote(Quote item)
        // {
        //     using(IDbConnection dbConnection = Connection)
        //     {
        //         string Query = "UPDATE quote SET user = @QuoterName, content = @QuoteContent WHERE id = @QuoteId";
        //         dbConnection.Open();
        //         dbConnection.Execute(Query, item);
        //     }
        // }

        // public void DeleteQuote(int Id)
        // {
        //     using(IDbConnection dbConnection = Connection)
        //     {
        //         string Query = $"DELETE FROM quote WHERE id = {Id}";
        //         dbConnection.Open();
        //         dbConnection.Execute(Query);
        //     }
        // }
    }
}