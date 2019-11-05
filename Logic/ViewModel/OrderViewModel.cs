using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ViewModel
{
    public class OrderViewModel
    {

        public int Id { get; set; }

        public string ClientName { get; set; }
        public string MasterName { get; set; }
        public string StageName { get; set; }
        public string ServiceName { get; set; }
        public DateTime DateOrder { get; set; } 
        public string Description { get; set; }
        public string DeviceName { get; set; }
    }
}
