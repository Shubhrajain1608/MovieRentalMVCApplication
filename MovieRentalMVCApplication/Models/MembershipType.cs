using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieRentalMVCApplication.Models
{
    public class MembershipType
    {
        public int Id { get; set; }

        public short SignUpFee { get; set; }

        public byte DurationInMonth { get; set; }

        public byte DiscoutRate { get; set; }
        public string Name { get; set; }


    }
}