using AutoMapper;
using NoodleDAL = InstantNoodles.DAL.Models.NoodleModel;
using NoodleMVC = InstantNoodles.MVC.Models.NoodleModel;

namespace InstantNoodles.MVC;

public class NoodleProfile : Profile
{
	public NoodleProfile()
	{
		CreateMap<NoodleDAL, NoodleMVC>();
	}
}
