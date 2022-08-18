using AutoMapper;
using NoodleDAL = InstantNoodles.DAL.Models.NoodleModel;
using NoodleMVC = InstantNoodles.MVC.Models.NoodleModel;
using InstantNoodles.MVC.Models;

namespace InstantNoodles.MVC;

public class NoodleProfile : Profile
{
	public NoodleProfile()
	{
		CreateMap<NoodleDAL, DifferentNoodleModel>()
			.ForMember(destination => destination.IdNouille, options => options.MapFrom(source => source.NoodleID))
			.ForMember(destination => destination.Nom, options => options.MapFrom(source => source.Name))
			.ForMember(destination => destination.Viande, options => options.MapFrom(source => source.Meat))
            .ForMember(destination => destination.Legume, options => options.MapFrom(source => source.Vegetable))
			.ReverseMap();
	}
}
