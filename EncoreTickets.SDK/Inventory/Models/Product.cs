﻿using System;
using EncoreTickets.SDK.Interfaces;

namespace EncoreTickets.SDK.Inventory.Models
{
    public class Product : IIdentifiableObject
    {
        public string id { get; set; }

        public string name { get; set; }

        public string type { get; set; }

        public Venue venue { get; set; }

        public string onSale { get; set; }

        public DateTime bookingStarts { get; set; }

        public DateTime bookingEnds { get; set; }
    }
}