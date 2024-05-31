using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Mvc;
using Book_Managemant.Models;

namespace Book_Managemant.Controllers
{
    public class SEARCHController : Controller
    {
        // GET: Searches
        public ActionResult Index()
        {
            return View(new SearchViewModel());
        }

        [HttpPost]
        public ActionResult SearchResults(string searchQuery)
        {
            string sqlQuery = @"
            SELECT 
    b.BookID, 
    b.Title, 
    b.PublishedYear, 
    b.ISBN,
    a.Name ,
    c.CategoryName, 
    p.PublisherName
         FROM 
         Books1 b
        JOIN 
          Authors a ON b.AuthorID = a.AuthorID
        JOIN 
           Categories c ON b.CategoryID = c.CategoryID
        JOIN 
         Publishers p ON b.PublisherID = p.PublisherID
        WHERE 
    b.BookID = @searchQuery";

            string connectionString = "Data Source=DESKTOP-IQP2QCN\\SQLEXPRESS;Initial Catalog=Book_Mng;Integrated Security=True;"; 
            List<Book_Managemant.Models.Books1DetailsViewModel> searchResults = new List<Book_Managemant.Models.Books1DetailsViewModel>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.AddWithValue("@searchQuery", searchQuery);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Book_Managemant.Models.Books1DetailsViewModel studentDetails = new Book_Managemant.Models.Books1DetailsViewModel
                    {
                        BookID = Convert.ToInt32(reader["BookID"]),
                        Title = reader["Title"].ToString(),
                        ISBN = reader["ISBN"].ToString(),
                        Name = reader["Name"].ToString(),
                        CategoryName = reader["CategoryName"].ToString(),
                        PublisherName = reader["PublisherName"].ToString(),
                        PublishedYear = reader["PublishedYear"] != DBNull.Value ? Convert.ToDateTime(reader["PublishedYear"]) : (DateTime?)null
                    };
                    searchResults.Add(studentDetails);
                }
            }

            var viewModel = new SearchViewModel
            {
                SearchQuery = searchQuery,
                SearchResults = searchResults
            };

            return View("Index", viewModel);
        }
    }
}