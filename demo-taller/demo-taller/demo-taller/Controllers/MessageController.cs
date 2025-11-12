using demo_taller.Models.Entities;
using demo_taller.Models.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace demo_taller.Controllers
{
    public class MessageController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        MessageServices messageServices;

        public MessageController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            messageServices = new MessageServices(_configuration);
        }

        public IActionResult Post([FromBody] Message message)
        {
            try
            {
                return Ok(messageServices.Post(message));
            }
            catch (SqlException e)
            {
                ViewBag.Message = e.Message;
                return View(e.ToString());
            }
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
