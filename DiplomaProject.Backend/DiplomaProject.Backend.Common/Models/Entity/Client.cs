﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaProject.Backend.Common.Models.Entity
{
    public class Client
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateOnly BirthdayDate { get; set; }
        public string PhoneNumber { get; set; }
        public double BonusCount { get; set; }

        public User User { get; set; }
        public List<Order> Orders { get; set; }
    }
}
