using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using COMP003B.Assignment6.Data;
using COMP003B.Assignment6.Models;

namespace COMP003B.Assignment6.Controllers
{
    public class PlayerTeamsController : Controller
    {
        private readonly SoccerTeamContext _context;

        public PlayerTeamsController(SoccerTeamContext context)
        {
            _context = context;
        }

        // GET: PlayerTeams
        public async Task<IActionResult> Index()
        {
            var soccerTeamContext = _context.PlayerTeams.Include(p => p.Player).Include(p => p.Team);
            return View(await soccerTeamContext.ToListAsync());
        }

        // GET: PlayerTeams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playerTeam = await _context.PlayerTeams
                .Include(p => p.Player)
                .Include(p => p.Team)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (playerTeam == null)
            {
                return NotFound();
            }

            return View(playerTeam);
        }

        // GET: PlayerTeams/Create
        public IActionResult Create()
        {
            ViewData["PlayerId"] = new SelectList(_context.Players, "PlayerId", "Name");
            ViewData["TeamId"] = new SelectList(_context.Teams, "TeamId", "City");
            return View();
        }

        // POST: PlayerTeams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PlayerId,TeamId")] PlayerTeam playerTeam)
        {
            if (ModelState.IsValid)
            {
                _context.Add(playerTeam);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PlayerId"] = new SelectList(_context.Players, "PlayerId", "Name", playerTeam.PlayerId);
            ViewData["TeamId"] = new SelectList(_context.Teams, "TeamId", "City", playerTeam.TeamId);
            return View(playerTeam);
        }

        // GET: PlayerTeams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playerTeam = await _context.PlayerTeams.FindAsync(id);
            if (playerTeam == null)
            {
                return NotFound();
            }
            ViewData["PlayerId"] = new SelectList(_context.Players, "PlayerId", "Name", playerTeam.PlayerId);
            ViewData["TeamId"] = new SelectList(_context.Teams, "TeamId", "City", playerTeam.TeamId);
            return View(playerTeam);
        }

        // POST: PlayerTeams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PlayerId,TeamId")] PlayerTeam playerTeam)
        {
            if (id != playerTeam.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(playerTeam);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlayerTeamExists(playerTeam.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["PlayerId"] = new SelectList(_context.Players, "PlayerId", "Name", playerTeam.PlayerId);
            ViewData["TeamId"] = new SelectList(_context.Teams, "TeamId", "City", playerTeam.TeamId);
            return View(playerTeam);
        }

        // GET: PlayerTeams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playerTeam = await _context.PlayerTeams
                .Include(p => p.Player)
                .Include(p => p.Team)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (playerTeam == null)
            {
                return NotFound();
            }

            return View(playerTeam);
        }

        // POST: PlayerTeams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var playerTeam = await _context.PlayerTeams.FindAsync(id);
            if (playerTeam != null)
            {
                _context.PlayerTeams.Remove(playerTeam);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlayerTeamExists(int id)
        {
            return _context.PlayerTeams.Any(e => e.Id == id);
        }
    }
}
