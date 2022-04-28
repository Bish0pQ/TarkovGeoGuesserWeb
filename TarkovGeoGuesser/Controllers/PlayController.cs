using Microsoft.AspNetCore.Mvc;
using TarkovGeoGuesser.Extensions;
using TarkovGeoGuesser.Logic.Interfaces;
using TarkovGeoGuesser.Models.Dtos;

namespace TarkovGeoGuesser.Controllers;

public class PlayController : Controller
{
    private readonly IWebHostEnvironment _environment;
    private readonly IGameService _gameService;
    
    public PlayController(IWebHostEnvironment environment, IGameService gameService)
    {
        this._environment = environment;
        this._gameService = gameService;
    }


    [HttpGet]
    public ActionResult Index()
    {
        return View("Index");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> NewGame(IFormCollection fc)
    {
        // Validation
        if (string.IsNullOrWhiteSpace(fc["selectedMap"])) throw new Exception("Invalid map.");
        
        // Retrieve values from the form collection and build DTO
        var gameRequest = new GameRequest()
        {
            Map = Convert.ToString(fc["selectedMap"]),
            Difficulty = fc.GetDifficulty()
        };

        if (string.IsNullOrWhiteSpace(gameRequest.Difficulty))
            throw new Exception("Invalid game difficulty");

        // Process the logic
        var imageResult = _gameService.CreateNew(gameRequest.Map.ToLower(), _environment.WebRootPath);
        ViewBag.GameImage = imageResult.Replace(_environment.WebRootPath, "");
        return View("Game");
    }
}