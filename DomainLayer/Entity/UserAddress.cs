﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DomainLayer.Model
{
    public class UserAddress
    {
      
        public int UserId { get; set; }
        public User User { get; set; }

        public int? AddressId { get; set; }
        public Address Address { get; set; }
    }
}