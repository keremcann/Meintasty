﻿using System.Runtime.Serialization;

namespace Meintasty.Application.Contract.Restaurant.Queries
{
    [DataContract]
    public class GetRestaurantsByCityIdQueryResponse
    {
        [DataMember]
        public int TotalCount { get; set; }
        [DataMember]
        public int TotalPages { get; set; }
        [DataMember]
        public int CurrentPage { get; set; }
        [DataMember]
        public int? NextPage { get; set; }
        [DataMember]
        public int? PrevPage { get; set; }
        [DataMember]
        public List<RestaurantsByCityIdContract>? Restaurants { get; set; }
    }

    public class RestaurantsByCityIdContract
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string? RestaurantName { get; set; }
        [DataMember]
        public string? Url { get; set; }
        [DataMember]
        public string? Email { get; set; }
        [DataMember]
        public string? PhoneNumber { get; set; }
        [DataMember]
        public string? TaxNumber { get; set; }
        [DataMember]
        public string? WorkDayFrom { get; set; }
        [DataMember]
        public string? WorkDayTo { get; set; }
        [DataMember]
        public string? WorkHourFrom { get; set; }
        [DataMember]
        public string? WorkHourTo { get; set; }
        [DataMember]
        public int TotalCount { get; set; }
    }
}
