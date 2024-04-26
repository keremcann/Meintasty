using AutoMapper;
using Meintasty.Application.Contract.Canton.Queries;
using Meintasty.Application.Contract.City.Queries;
using Meintasty.Application.Contract.Register.Commands;
using Meintasty.Domain.Entity;

namespace Meintasty.Application
{
    public class ApplicationAutoMapper : Profile
    {
        public ApplicationAutoMapper()
        {
            #region User
            CreateMap<CreateUserCommandRequest, User>().ReverseMap();
            #endregion

            #region Canton
            CreateMap<GetCantonQueryResponse, Domain.Entity.Canton>().ReverseMap();
            #endregion

            #region City
            CreateMap<GetCityQueryResponse, City>().ReverseMap();
            #endregion
        }
    }
}
