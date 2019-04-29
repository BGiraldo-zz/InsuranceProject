using AutoMapper;
using Insurance.API.Models;
using Insurance.Domain.AggregatesModel.ClientAggregate;
using Insurance.Domain.AggregatesModel.PolicyAggregate;
using Insurance.Domain.AggregatesModel.PolicyDetailAggregate;

namespace Insurance.API.Helpers
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize((config) =>
            {
                config.CreateMap<Client, ClientDTO>().ReverseMap();
                config.CreateMap<Policy, PolicyDTO>().ReverseMap();

                config.CreateMap<PolicyDetail, PolicyDetailDTO>()
                .ForMember(destination => destination.CustomerName, opts => opts.MapFrom(source => source.Client.CompleteName)) 
                .ForMember(destination => destination.PolicyName, opts => opts.MapFrom(source => source.Policy.Name))
                .ReverseMap();
            });
        }
    }
}