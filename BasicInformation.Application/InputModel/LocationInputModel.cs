using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicInformation.Application.InputModel
{
    public class LocationInputModel : BaseLocationInputModel
    {
        public long? ParentId { get; set; }
        public byte LocationType { get; set; }

    }
}
