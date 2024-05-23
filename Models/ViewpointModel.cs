using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eszaki_kozephegyseg_kilatoi_GUI.Models
{
    public class ViewpointModel
    {
        public int id { get; set; }
        public string viewpointName { get; set; }
        public string mountain { get; set; }
        public double height { get; set; }
        public string description { get; set; }
        public DateTime built { get; set; }
        public string imageUrl { get; set; }
        public int location { get; set; }


    }
}
