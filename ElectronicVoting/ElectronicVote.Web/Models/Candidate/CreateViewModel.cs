using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicVote.Web.Models.Candidate
{
    public class CreateViewModel
    {
        public string FullName { get; set; }
        public Boolean State { get; set; }
        public string ImagePath { get; set; }
    }
}
