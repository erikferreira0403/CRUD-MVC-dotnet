using CRUDusuário.Models;
using CRUDusuário.Repository.UserRepo;
using Microsoft.AspNetCore.Mvc;


namespace CRUDusuário.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepo _userRepo;
        private readonly ILogger<HomeController> _logger;

        public UserController(IUserRepo userRepo, ILogger<HomeController> logger = null)
        {
            _userRepo = userRepo;
            _logger = logger;
        }
        public IActionResult Index()
        {
            var users = _userRepo.Get();
            try
            {
                return View(users);

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View(users);
            }
        }

        [HttpGet]
        public async Task<IEnumerable<User>> GetUsers() {
        return await _userRepo.Get();
        }
        [HttpGet("{id}")]
        public async Task<User> GetId(int id)
        {
        return await _userRepo.GetById(id);
        }

        [HttpPost]
        public async Task<User> Post(User user)
        {
            await _userRepo.Update(user);
            return user;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> delete(int id)
        {
            var usertodelete = _userRepo.GetById(id);

            if(usertodelete != null)
                return NotFound();

            await _userRepo.Delete(usertodelete.Id);
            return NoContent();
        }

        [HttpPut("id")]
        public async Task<ActionResult> Update(int id, [FromBody]User user)
        {
            if (_userRepo.GetById(id) != null)
                return NotFound();

            await _userRepo.Update(user);
            return NoContent();
        }
    }
}
