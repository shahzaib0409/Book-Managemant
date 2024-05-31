using System;

namespace Book_Managemant.Models
{
    public class Books1DetailsViewModel
    {
        internal DateTime publishedYear;

        public int BookID { get; internal set; }
        public string Title { get; set; }
        public Nullable<System.DateTime> PublishedYear { get; set; }
        public string ISBN { get; set; }

        public string Name {  get; set; }

        public string CategoryName {  get; set; }
        public string PublisherName {  get; set; }

       
    }
}