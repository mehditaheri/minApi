using BasicInformation.Application.Features;
using BasicInformation.Application.InputModel;
using BasicInformation.Application.Mapper.Location;
using BasicInformation.Application.Responses.Base;
using BasicInformation.Infrastructure.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace BasicInformation.Application.tests
{
    [TestClass]
    public class LocationFeaturesTest : BaseUnitTest
    {
        [TestMethod]
        public async Task AddLocationTestAsync()
        {
            // Arrange 
            LocationInputModel input = new LocationInputModel() { Title = "asfafasfas" };
            var addCommand = LocationMapper.Mapper.Map<AddLocation.Command>(input);
            CommandResponse response = new BadRequest();
            TblLocationRepository _TblLocationRepo = new TblLocationRepository(GetDbContext(), null);

            // Act 
            response = await new AddLocation.CommandHandler(_TblLocationRepo).Handle(addCommand, new System.Threading.CancellationToken());

            // Assert 
            Assert.IsTrue(response.Success);
        }

        //[TestMethod]
        //// [ExpectedException(typeof(Exception))]
        //public async Task AddLocationTestAsync()
        //{
        //    // Arrange 
        //    LocationInputModel input = new LocationInputModel() { Title = "asfafasfas" };
        //    var addCommand = LocationMapper.Mapper.Map<AddLocation.Command>(input);
        //    CommandResponse response = new BadRequest();

        //    //var data = new List<TblLocation>
        //    //{
        //    //    new TblLocation { Title = "BBB" },
        //    //    new TblLocation { Title = "ZZZ" },
        //    //    new TblLocation { Title = "AAA" },
        //    //}.AsQueryable();

        //    //var mockSet = new Mock<DbSet<TblLocation>>();  
        //    //mockSet.As<IQueryable<TblLocation>>().Setup(m => m.Provider).Returns(data.Provider);
        //    //mockSet.As<IQueryable<TblLocation>>().Setup(m => m.Expression).Returns(data.Expression);
        //    //mockSet.As<IQueryable<TblLocation>>().Setup(m => m.ElementType).Returns(data.ElementType);
        //    //mockSet.As<IQueryable<TblLocation>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

        //    //var mockContext = new Mock<BasicInformatinContext>();
        //    //mockContext.Setup(m => m.TblLocations).Returns(mockSet.Object);


        //    var options = new DbContextOptionsBuilder<BasicInformatinContext>()
        //   .UseInMemoryDatabase(databaseName: "BasicInformatinContext")
        //   .Options;

        //    var dbContext = new BasicInformatinContext(options);
        //    //mockContext.Object;

        //    TblLocationRepository _TblLocationRepo = new TblLocationRepository(dbContext, null);

        //    // Act
        //    //  SafeRun(async () => { 
        //    response = await new AddLocation.CommandHandler(_TblLocationRepo).Handle(addCommand, new System.Threading.CancellationToken());
        //    //  }); 

        //    // Assert 
        //    Assert.IsTrue(response.Success);
        //}
    }
}