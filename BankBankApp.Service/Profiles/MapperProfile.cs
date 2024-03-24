﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BankBankApp.Domain;
using BankBankApp.Service.DTOs;

namespace BankBankApp.Service.Profiles
{
	public class MapperProfile : Profile
	{
		public MapperProfile()
		{
			CreateMap<User, UserDTO>().ReverseMap();
			CreateMap<RegisterDTO, User>();
			CreateMap<UserUpdateDTO, User>().ReverseMap();
			CreateMap<Account, AccountDTO>().ReverseMap();
			CreateMap<Card, CardDTO>().ReverseMap();
		}
	}
}
