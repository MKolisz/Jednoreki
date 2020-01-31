using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Jednoreki.Entities;
using Jednoreki.Models.Games;
using Jednoreki.Models.Payments;
using Jednoreki.Models.Users;

namespace Jednoreki.Helpers
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserModel>();
            CreateMap<RegisterModel, User>();
            CreateMap<UpdateModel, User>();

            CreateMap<Payment, PaymentModel>();
            CreateMap<PaymentModel, Payment>();

            CreateMap<Game, GameModel>();
            CreateMap<GameModel, Game>();
        }
    }
}
