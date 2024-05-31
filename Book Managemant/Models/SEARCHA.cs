
using Book_Managemant.Controllers;
using Book_Managemant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Book_Managemant.Models
{
    public class SearchViewModel
    {
        public string SearchQuery { get; set; }
        public List<Books1DetailsViewModel> SearchResults { get; set; }


    }

}