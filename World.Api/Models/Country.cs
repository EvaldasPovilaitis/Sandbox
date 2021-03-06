﻿namespace World.Api.Models
{
    using System.Collections.Generic;

    public class Country
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<Type> Types { get; set; }
    }
}
