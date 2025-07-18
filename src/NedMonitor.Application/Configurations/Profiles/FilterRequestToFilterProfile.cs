using AutoMapper;
using NedMonitor.Application.Requests;
using NedMonitor.Domain.Filters;
using Zypher.Persistence.Abstractions.Data.Filters;
using Zypher.Requests;

namespace NedMonitor.Application.Configurations.Profiles;

public class FilterRequestToFilterProfile : Profile
{
    public FilterRequestToFilterProfile()
    {
        CreateMap<FilterRequest, Filter>();

        CreateMap<LogFilterRequest, LogFilter>();
    }
}
