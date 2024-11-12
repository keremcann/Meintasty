using AutoMapper;
using Meintasty.Application.Contract.Address.Queries;
using Meintasty.Application.Contract.Basket.Queries;
using Meintasty.Application.Contract.Canton.Queries;
using Meintasty.Application.Contract.Category.Queries;
using Meintasty.Application.Contract.City.Queries;
using Meintasty.Application.Contract.Home.Queries;
using Meintasty.Application.Contract.Order.Queries;
using Meintasty.Application.Contract.Register.Commands;
using Meintasty.Application.Contract.Restaurant;
using Meintasty.Application.Contract.Restaurant.Queries;
using Meintasty.Application.Contract.User.Queries;
using Meintasty.Domain.Entity;

namespace Meintasty.Application
{
    public class ApplicationAutoMapper : Profile
    {
        public ApplicationAutoMapper()
        {
            #region User
            CreateMap<Domain.Entity.User, CreateUserCommandRequest>().ReverseMap();
            CreateMap<Domain.Entity.User, GetUserQueryResponse>().ReverseMap();
            #endregion

            #region Canton
            CreateMap<GetCantonQueryResponse, Domain.Entity.Canton>().ReverseMap();
            #endregion

            #region City
            CreateMap<GetCityQueryResponse, City>().ReverseMap();
            #endregion

            #region Restaurant By City
            CreateMap<GetRestaurantsByCityIdQueryResponse, Domain.Entity.Restaurant>().ReverseMap();
            #endregion

            #region Restaurant By Id
            CreateMap<GetRestaurantDetailByIdQueryResponse, Domain.Entity.Restaurant>().ReverseMap();
            #endregion

            #region Favorite Restaurant
            CreateMap<GetFavoriteRestaurantQueryResponse, Domain.Entity.Restaurant>().ReverseMap();
            #endregion

            #region Restaurant Address
            CreateMap<RestaurantAddressContract, RestaurantAddress>().ReverseMap();
            #endregion

            #region Restaurant Menu
            CreateMap<RestaurantMenuContract, RestaurantMenu>().ReverseMap();
            #endregion

            #region Restaurant Order
            CreateMap<RestaurantOrderContract, RestaurantOrder>().ReverseMap();
            #endregion

            #region Restaurant Category
            CreateMap<GetCategoryRestaurantQueryResponse, Domain.Entity.Restaurant>().ReverseMap();
            #endregion

            #region Basket
            CreateMap<GetBasketQueryResponse, Domain.Entity.Basket>().ReverseMap();
            #endregion

            #region Order
            CreateMap<GetOrderQueryResponse, Domain.Entity.Order>().ReverseMap();
            #endregion

            #region Home Restaurant Menu
            CreateMap<GetFavoriteMenuQueryResponse, RestaurantMenu>().ReverseMap();
            #endregion

            #region User Address
            CreateMap<GetUserAddressResponse, UserAddress>().ReverseMap();
            #endregion

            #region Category
            CreateMap<GetCategoryQueryResponse, Domain.Entity.Category>().ReverseMap();
            #endregion
        }
    }
}
