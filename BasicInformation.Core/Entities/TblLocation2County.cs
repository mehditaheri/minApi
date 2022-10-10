using System;
using System.Collections.Generic;

namespace BasicInformation.Core.Entities
{
    public partial class TblLocation2County
    {
        public long Id { get; set; }
        public long? ParentId { get; set; }
        public string Title { get; set; } = null!;
        public byte LocationType { get; set; }
        public string? Username { get; set; }
        public int? ProvinceId { get; set; }
        public int? CountyId { get; set; }
    }
}
