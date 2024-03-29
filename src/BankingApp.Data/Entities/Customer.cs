﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingApp.Data.Entities;

namespace BankingApp.Data.Entities
{
    public class Customer : BaseEntity
    {
        public int  CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string Email { get; set; }
        public string IdType { get; set; }
        public string PhoneNumber { get; set; }
        public string IdNumber { get; set; }
        public string BVN { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
