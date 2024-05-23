using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ASP_LR_4_Kyrylenko_402
{
    public class LibraryController : Controller
    {
        [Route("Library")]
        public IActionResult Library()
        {
            return Content("You are in a library");
        }

        [Route("Library/Books")]
        public IActionResult Books()
        {
            var books = ReadBooksFromJson();
            return Json(books);
        }

        [Route("Library/Profile/{id?}")]
        public IActionResult Profile(int? id)
        {
            List<User> users = ReadUsersFromJson();

            if (id.HasValue && id >= 0 && id <= 5)
            {
                var user = users.Find(u => u.Id == id);
                if (user != null)
                    return Json(user);
                else
                    return NotFound();
            }
            else
            {
                return Content("current user info: artem");
            }
        }

        private List<Book> ReadBooksFromJson()
        {
            var json = System.IO.File.ReadAllText("books.json");
            return JsonConvert.DeserializeObject<List<Book>>(json);
        }

        private List<User> ReadUsersFromJson()
        {
            var json = System.IO.File.ReadAllText("users.json");
            return JsonConvert.DeserializeObject<List<User>>(json);
        }
    }

    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
