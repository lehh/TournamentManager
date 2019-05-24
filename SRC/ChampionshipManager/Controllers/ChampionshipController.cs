﻿using ChampionshipManager.Model;
using ChampionshipManager.ViewModel;
using ChampionshipManager.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChampionshipManager.Controllers
{
    public class ChampionshipController : Controller
    {
        private readonly ChampionshipManagerContext _context;

        public ChampionshipController(ChampionshipManagerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            var model = new ChampionshipCreateViewModel();
            var teamList = await _context.Team.ToListAsync();

            var SelectListItemList = new List<SelectListItem>();

            foreach (var team in teamList)
            {
                SelectListItemList.Add(new SelectListItem()
                {
                    Text = team.Name,
                    Value = team.Id.ToString()
                });
            }

            model.TeamMultiSelectList = new MultiSelectList(SelectListItemList);

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Create(ChampionshipCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                //Rules
                var countSelectedTeams = model.TeamIdList.Count;

                if (!Tools.IsPowerOfTwo(countSelectedTeams))
                {
                    TempData["Message"] = "Error: The number of selected teams must be a power of 2.";
                }

                

                try
                {
                    var championship = new Championship()
                    {
                        Name = model.Name
                    };

                    var teamChampionshipList = new List<TeamChampionship>();

                    foreach (var teamId in model.TeamIdList)
                    {
                        teamChampionshipList.Add(new TeamChampionship()
                        {
                            Team = new Team() { Id = teamId },
                            Championship = championship, 
                        });
                    }

                    _context.Championship.Add(championship);
                    await _context.SaveChangesAsync();

                    TempData["Message"] = "Championship " + championship.Name + " inserted successfully!";

                    return View();
                }
                catch (Exception ex)
                {
                    TempData["Message"] = ex.Message;
                }
            }

            return View(model);
        }
    }
}