using Microsoft.AspNetCore.Mvc;
using ArenaPro1.Services;
using ArenaPro1.DTOs;
using System.Threading.Tasks;

namespace ArenaPro1.Controllers
{
    public class MatchResultsController : Controller
    {
        private readonly IMatchResultService _matchResultService;

        public MatchResultsController(IMatchResultService matchResultService)
        {
            _matchResultService = matchResultService;
        }

        public async Task<IActionResult> Index()
        {
            var matchResults = await _matchResultService.GetAllMatchResultsAsync();
            return View(matchResults);
        }

        public async Task<IActionResult> Details(int id)
        {
            var matchResult = await _matchResultService.GetMatchResultByIdAsync(id);
            return View(matchResult);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(MatchResultDTO matchResultDto)
        {
            await _matchResultService.AddMatchResultAsync(matchResultDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var matchResult = await _matchResultService.GetMatchResultByIdAsync(id);
            return View(matchResult);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(MatchResultDTO matchResultDto)
        {
            await _matchResultService.UpdateMatchResultAsync(matchResultDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _matchResultService.DeleteMatchResultAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}