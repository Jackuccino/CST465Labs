﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_8.Models
{
    public class CustomIdentityUser : IdentityUser
    {
        public string DisplayName { get; set; }
        public int? Age { get; set; }
    }
}
