﻿using System.Collections.Generic;

namespace Lifti
{
    public class MatchedLocation
    {
        public MatchedLocation(string foundIn, IReadOnlyList<WordLocation> locations)
        {
            this.FoundIn = foundIn;
            this.Locations = locations;
        }

        public string FoundIn { get; set; }
        public IReadOnlyList<WordLocation> Locations { get; set; }

        public override string ToString()
        {
            return $"{FoundIn}: {string.Join(",", this.Locations)}";
        }
    }
}
