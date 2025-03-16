using AutoMapper;
using Manager.Task.Domain.DTO;
using Manager.Task.Domain.Task;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<TaskDto, ManagerTask>()
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));

        CreateMap<ManagerTask, TaskResponseDto>()
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title.ToString()))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description.ToString()));
    }
}