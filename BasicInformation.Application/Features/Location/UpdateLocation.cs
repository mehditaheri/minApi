using BasicInformation.Application.Mapper.Location;
using BasicInformation.Application.Responses;
using BasicInformation.Application.Responses.Base;
using BasicInformation.Core.Repositories;
using MediatR;

namespace BasicInformation.Application.Features
{

    public class UpdateLocation
    {
        public class Command : IRequest<CommandResponse>
        {
            public long Id { get; set; }
            public long? ParentId { get; set; }
            public string Title { get; set; } = null!;
            public byte LocationType { get; set; }
            public decimal? Lat { get; set; }
            public decimal? Lng { get; set; }
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

                location.ParentId = request.ParentId;
                location.Title = request.Title;
                location.LocationType = request.LocationType;
                location.Lat = request.Lat;
                location.Lng = request.Lng;

                await _TblLocationRepo.UpdateAsync(location);

                return new CommandResponse() { Success = true, Data = location };
            }

        }
    }
}
