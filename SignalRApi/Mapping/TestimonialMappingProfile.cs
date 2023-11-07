using AutoMapper;
using SignalR.Dto.TestimonialDto;
using SignalR.Entities.Entities;

namespace SignalRApi.Mapping;

public class TestimonialMappingProfile : Profile
{
    public TestimonialMappingProfile()
    {
        CreateMap<Testimonial, CreateTestimonialDto>().ReverseMap();
        CreateMap<Testimonial, GetTestimonialDto>().ReverseMap();
        CreateMap<Testimonial, ResultTestimonialDto>().ReverseMap();
        CreateMap<Testimonial, UpdateTestimonialDto>().ReverseMap();
    }
}