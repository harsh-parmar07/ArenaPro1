using Microsoft.AspNetCore.Mvc;
using ArenaPro1.Services;
using ArenaPro1.DTOs;
using System.Threading.Tasks;

namespace ArenaPro1.Controllers
{
    public class TournamentsController : Controller
    {
        private readonly ITournamentService _tournamentService;

        public TournamentsController(ITournamentService tournamentService)
        {
            _tournamentService = tournamentService;
        }

        public async Task<IActionResult> Index()
        {
            var tournaments = await _tournamentService.GetAllTournamentsAsync();
            return View(tournaments);
        }

        public async Task<IActionResult> Details(int id)
        {
            var tournament = await _tournamentService.GetTournamentByIdAsync(id);
            return View(tournament);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TournamentDTO tournamentDto)
        {
            await _tournamentService.AddTournamentAsync(tournamentDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var tournament = await _tournamentService.GetTournamentByIdAsync(id);
            return View(tournament);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TournamentDTO tournamentDto)
        {
            await _tournamentService.UpdateTournamentAsync(tournamentDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _tournamentService.DeleteTournamentAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}