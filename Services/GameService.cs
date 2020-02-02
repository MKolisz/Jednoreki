using Jednoreki.Entities;
using Jednoreki.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jednoreki.Services
{
    public interface IGameService
    {
        Game Create(Game game);
        IEnumerable<Game> GetAll();
        IEnumerable<Game> GetByUserId(int userId);
        void Delete(int id);
    }

    public class GameService : IGameService
    {
        private GameContext _context;
        private UserContext _user_context;

        public GameService(GameContext context, UserContext userContext)
        {
            _context = context;
            _user_context = userContext;
        }

        public Game Create(Game game)
        {
            var user = _user_context.Users.Find(game.UserId);
            if (user == null)
                throw new AppException("User not found, wrong id or id field is missing");

            //user doesn't have enough money to play
            if (game.Balance > user.Balance)
                throw new AppException("You dont have enough money to play");
            else if (game.Balance < 2)
                throw new AppException("Minimum amount to play is 2");

            double prize = 0;
            prize -= game.Balance;

            Random rnd = new Random();
            game.Number1 = rnd.Next(0, 4);
            game.Number2 = rnd.Next(0, 4);
            game.Number3 = rnd.Next(0, 4);

            if(game.Number1==game.Number2&&game.Number2==game.Number3)
            {
                prize += game.Balance * 21;
            }

            user.Balance += prize;
            _user_context.Users.Update(user);

            game.Date = System.DateTime.Now;
            game.Balance = prize;
            _context.Games.Add(game);

            _context.SaveChanges();
            _user_context.SaveChanges();

            return game;
        }

        public IEnumerable<Game> GetAll()
        {
            return _context.Games;
        }

        public IEnumerable<Game> GetByUserId(int userId)
        {
            if (_user_context.Users.Find(userId) == null)
                throw new AppException("User not found");

            return from games in _context.Games
                   where games.UserId == userId
                   select games;
        }

        public void Delete(int id)
        {
            var game = _context.Games.Find(id);
            if (game != null)
            {
                _context.Games.Remove(game);
                _context.SaveChanges();
            }
            else throw new AppException("Payment with given id doesn't exist");
        }
    }
}
