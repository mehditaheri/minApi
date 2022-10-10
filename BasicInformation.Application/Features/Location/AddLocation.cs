using BasicInformation.Application.Mapper.Location;
using BasicInformation.Application.Responses;
using BasicInformation.Application.Responses.Base;
using BasicInformation.Core.Entities;
using BasicInformation.Core.Repositories;
using FluentValidation;
using MediatR;

namespace BasicInformation.Application.Features
{

    public class AddLocation
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

        //public class Validator : AbstractValidator<Command>
        //{
        //    // private readonly IMediator _mediator;

        //    public Validator(/*IMediator mediator*/)
        //    {
        //        // _mediator = mediator;

        //        RuleFor(x => x.ParentId)
        //            .NotEmpty()
        //            .WithMessage("شناسه والد نمی تواند خالی باشد");

        //        //RuleFor(x => x)
        //        //    .MustAsync(NotHaveManageSecurityPermission)
        //        //    .WithMessage(
        //        //        "You cannot add an entity who has permission to " +
        //        //        "manage security. Please coordinate with your system " +
        //        //        "administrators first.");

        //        //RuleFor(query => query).Custom((query, context) => {
        //        //    if (entity.Id != null)
        //        //    {
        //        //        context.AddFailure("رکورد مورد نظر از دسترس خارج است");
        //        //    }
        //        //});

        //    }

        //    //private async Task<bool> NotHaveManageSecurityPermission(Command command, CancellationToken token)
        //    //{
        //    //    var permissionsForEntityToAdd =
        //    //        await _mediator.Send(new Permissions.Query { EntityId = command.Id }, token);

        //    //    return !permissionsForEntityToAdd.Contains(Permission.ManageSecurity);
        //    //}
        //}


        public class CommandHandler : IRequestHandler<Command, CommandResponse>
        {
            private readonly ITblLocationRepository _TblLocationRepo;

            public CommandHandler(ITblLocationRepository TblLocationRepository)
            {
                _TblLocationRepo = TblLocationRepository;
            }

            public async Task<CommandResponse> Handle(Command request, CancellationToken cancellationToken)
            { 
                //var validation = new Validator().Validate(request);

                //if (!validation.IsValid)
                //    return new HasError(validation);

                var location = new TblLocation();

                location.ParentId = request.ParentId;
                location.Title = request.Title;
                location.LocationType = request.LocationType;
                location.Lat = request.Lat;
                location.Lng = request.Lng;

                var dbLocation = await _TblLocationRepo.AddAsync(location);

                return new CommandResponse() { Success = true, Data = dbLocation };
            }

        }
    }
}
