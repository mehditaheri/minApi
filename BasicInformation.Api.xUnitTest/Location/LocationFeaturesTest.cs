using BasicInformation.Application.Features;
using BasicInformation.Application.InputModel;
using BasicInformation.Application.Mapper.Location;
using BasicInformation.Application.Responses.Base;
using MediatR;
using System;
using System.Threading.Tasks;
using Xunit;

namespace BasicInformation.Api.xUnitTest
{
    public class LocationFeaturesTest : BaseUnitTest
    {
        protected readonly IMediator _mediator;

        public LocationFeaturesTest(IMediator mediator)
        {
            _mediator = mediator;
        }


        [Fact]
        public void AddLocationTest()
        {
            // Arrange 
            LocationInputModel input = new LocationInputModel();
            var addCommand = LocationMapper.Mapper.Map<AddLocation.Command>(input);
            CommandResponse response = new BadRequest();

            // Act
            SafeRun(async () => { response = await _mediator.Send(addCommand); });

            // Assert 
            Assert.True(response.Success);
        }



        //[Fact]
        //public async void AddLocationTest()
        //{
        //    // Arrange 
        //    LocationInputModel input = new LocationInputModel();
        //    var addCommand = LocationMapper.Mapper.Map<AddLocation.Command>(input);

        //    // Act 
        //    Func<Task<CommandResponse>> act = () => _mediator.Send(addCommand);

        //    // Assert
        //   // var exception = await Assert.ThrowsAsync<InvalidOperationException>(act);
        //   // Assert.Equal("A valid name must be supplied.", caughtException.Message);

        //    var Result = await act();
        //    Assert.True(Result.Success);
        //}
    }
}