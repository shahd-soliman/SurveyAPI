using Mapster;
using Survey.app.Models;

namespace Survey.app.Mapping
{
    public class MappingConfigurations : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Poll, PollResponse>()
             .Map(dest => dest.Id, src => src.Id)
         .Map(dest => dest.Title, src => src.Title);

            config.NewConfig<PollRequest, Poll>().
                Map(dest => dest.Title, src => src.Title)
                   .Map(dest => dest.Description, src => src.Description);


        }



    }
}


















