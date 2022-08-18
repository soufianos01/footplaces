using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FootballField.Data;
using FootballField.Data.Models;

namespace FootballField.Pages
{
    public class AddFieldModel : PageModel
    {
        private IBookedFieldRepository bookedFieldsRepo;
        private IWebHostEnvironment webEnv;
        public AddFieldModel(IBookedFieldRepository bookedFieldRepository, IWebHostEnvironment environment)
        {
            this.bookedFieldsRepo = bookedFieldRepository;
            this.webEnv = environment;
        }

        [FromRoute]
        public string Id { get; set; }

        [BindProperty]
        public BookedField EditField { get; set; }
        public void OnGet()
        {
            EditField = this.bookedFieldsRepo.GetById(Id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid) { return Page(); }

            if (EditField.Upload is not null)
            {
                EditField.ImageFile = EditField.Upload.FileName;

                var file = Path.Combine(webEnv.ContentRootPath,
                    "wwwroot/images/logos", EditField.Upload.FileName);
                using (var fileStream = new FileStream(file, FileMode.Create))
                {
                    await EditField.Upload.CopyToAsync(fileStream);
                }
            }

            EditField.Edited = DateTime.Now;
            EditField.Id = Id;
            this.bookedFieldsRepo.Update(EditField);

            return RedirectToPage("Index");
        }
    }
}
