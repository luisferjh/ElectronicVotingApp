﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicVote.Web.Models.User
{
    public class CreateViewModel
    {
        public int IdRole { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public Boolean Record { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }          
    }
}
