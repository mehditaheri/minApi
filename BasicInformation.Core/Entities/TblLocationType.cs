using System;
using System.Collections.Generic;

namespace BasicInformation.Core.Entities
{
    public partial class TblLocationType
    {
        public short Id { get; set; }
        public string Title { get; set; } = null!;
        public string EnglishTitle { get; set; } = null!;
        public short? ParentId { get; set; }
    }
}
