using BasicInformation.Application.Mapper.Location;
using BasicInformation.Application.Responses;
using BasicInformation.Application.Responses.Base;
using BasicInformation.Core.Repositories;
using MediatR;

namespace BasicInformation.Application.Features
{

    public class DeleteLocation
    {
        public class Command : IRequest<CommandResponse>
        {
            public long Id { get; set; } 
        }

        public class CommandHandler : IRequestHandler<Command, CommandResponse>
        {
            private readonly ITblLocationRepository _TblLocationRepo;

            public CommandHandler(ITblLocationRepository TblLocationRepository)
            {
                _TblLocationRepo = TblLocationRepository;
            }

            public async Task<CommandResponse> Handle(Command request, CancellationToken cancellationToken)
            {
                var location = await _TblLocationRepo.GetByIdAsync(request.Id);

                if (location == null)
                    return new ResponseNotFound(); 

                await _TblLocationRepo.DeleteAsync(location);

                return new CommandResponse() { Success = true, Id = request.Id };
            }

        }
    }
}
