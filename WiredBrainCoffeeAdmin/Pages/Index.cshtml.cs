using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using System.Text;
using System.Text.Json;
using System;
using System.IO;
using System.Threading.Tasks;
using FootballField.Data.Models;
using FootballField.Data;
using System.Reflection.Metadata;

namespace FootballField.Pages
{
    public class IndexModel : PageModel
    {
        //private WiredContext wiredContext;
        //private IWebHostEnvironment webEnv;
        private readonly ILogger<IndexModel> _logger;
        private IBookedFieldRepository bookedFieldsRepo;
        public List<BookedField> Fields { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IBookedFieldRepository bookedFieldRepository)
        {
            this.bookedFieldsRepo = bookedFieldRepository;
            _logger = logger;
        }

        public List<BookedField> BookedFields { get; set; }
        //, WiredContext context, IWebHostEnvironment environment
        //public IndexModel(ILogger<IndexModel> logger)
        //{
        //    _logger = logger;
        //    //this.wiredContext = context;
        //    //this.webEnv = environment;
        //}

        public void OnGet()
        {
            //var rawJson = System.IO.File.ReadAllText("wwwroot/sampledata/fields.json");
            //BookedFields = JsonSerializer.Deserialize<List<BookedField>>(rawJson);
            //foreach (BookedField bookedField in BookedFields)
            //{
            //    this.wiredContext.BookedFields.Add(bookedField);
            //}

            //var test = this.wiredContext.SaveChanges();
            Fields = bookedFieldsRepo.GetAll();
        }
    }
}