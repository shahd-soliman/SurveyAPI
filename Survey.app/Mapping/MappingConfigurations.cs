using Mapster;
using Survey.app.Contracts.Polls;

namespace Survey.app.Mapping
{
    public class MappingConfigurations : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Poll, PollResponse>()

         .Map(dest => dest.Title, src => src.Title)
         .Map(dest => dest.Summary, src => src.Summary)
            .Map(dest => dest.EndAt, src => src.EndAt)
            .Map(dest => dest.StartAt, src => src.StartAt);

            config.NewConfig<PollRequest, Poll>().Map(dest => dest.Title, src => src.Title).Map(dest => dest.Summary, src => src.Summary);
           
            config.NewConfig<ApplicationUser , AuthRequest>().Map(dest => dest.Email, src => src.Email).Map(dest => dest.Password, src => src.PasswordHash);
        }



    }
}



















