using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LTweb05_bai1.Models;
using LTweb05_Bai1.Models;

namespace LTweb05_bai1.ViewModel
{
    public class DViewModel
    {
        public Department Department { get; set; }
        public List<Bai1> Employee { get; set; }
    }
}