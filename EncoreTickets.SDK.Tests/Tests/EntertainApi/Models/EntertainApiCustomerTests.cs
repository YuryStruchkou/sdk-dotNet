﻿using EncoreTickets.SDK.EntertainApi.Model;
using NUnit.Framework;

namespace EncoreTickets.SDK.Tests.Tests.EntertainApi.Models
{
    internal class EntertainApiCustomerTests
    {
        [Test]
        public void EntertainApi_Customer_Constructor_InitializesCorrectly()
        {
            var customer = new Customer();
            Assert.IsNotNull(customer.Titles);
            Assert.IsNotNull(customer.Countries);
            Assert.IsTrue(customer.Countries.ContainsKey(customer.country));
        }
    }
}
