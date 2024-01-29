﻿using Coldrun.Database.Enums;

namespace Coldrun.Database.Entities
{
    public partial class Truck
    {
        public string Code { get; set; } = null!;

        public string Name { get; set; } = null!;

        public TruckStatus Status { get; set; }

        public string? Description { get; set; }
    }

}
