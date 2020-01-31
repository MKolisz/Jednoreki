using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Jednoreki.Entities;
using Jednoreki.Helpers;
using Jednoreki.Services;
using Microsoft.Extensions.Options;
using Jednoreki.Models.Games;

namespace Jednoreki.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly GameContext _context;
        private IGameService _gameService;
        private IMapper _mapper;

        public GamesController (GameContext context, IGameService gameService, IMapper mapper)
        {
            _context = context;
            _gameService = gameService;
            _mapper = mapper;
        }

        // POST: api/Payments/PlayGame
        [HttpPost("PlayGame")]
        public IActionResult PlayGame([FromBody]GameModel model)
        {
            // map model to entity
            var game = _mapper.Map<Game>(model);

            try
            {
                // create payment
                _gameService.Create(game);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}