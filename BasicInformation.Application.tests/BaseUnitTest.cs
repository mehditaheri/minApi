using BasicInformation.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace BasicInformation.Application.tests
{
    public class BaseUnitTest
    {
        protected void SafeRun(Action T)
        {
            try
            {
                T();
            }
            catch
            {
            }
        }


        protected BasicInformatinContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<BasicInformatinContext>()
          .UseInMemoryDatabase(databaseName: "BasicInformatinContext")
          .Options;

            return new BasicInformatinContext(options);
        }
    }
}
