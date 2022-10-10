using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicInformation.Application.InputModel
{


    public abstract class BaseEntity
    {
        public string? Title { get; set; }

    }
    public class BaseLocationInputModel : BaseEntity
    { 
        //public string Title { get; set; } = null!;
        //public string? Title { get; set; }
        public decimal? Lat { get; set; }
        public decimal? Lng { get; set; }
    } 
}
