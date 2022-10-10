using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicInformation.Api.xUnitTest
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
    }
}
