using Clinic_IndividualWork_KazanovAlexandr.Context;
using Clinic_IndividualWork_KazanovAlexandr.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Clinic_IndividualWork_KazanovAlexandr.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var doctors = await _context.Doctor.ToListAsync();
            return View(doctors);
        }

        public async Task<IActionResult> Privacy()
        {
            var patients = await _context.Patient.ToListAsync();
            return View(patients);
        }

        public IActionResult AddPatient()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddPatient(Patient patient)
        {
            _context.Patient.Add(patient);
            await _context.SaveChangesAsync();
            return RedirectToAction("Privacy");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
