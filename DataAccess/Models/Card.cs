using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Card
    {
        public string CollectionId { get; set; }
        public string CollectionName { get; set; }
        public int ImageNumber { get; set; }
        public string SavePath { get; set; }
        public string SaveBackPath { get; set; }
    }
}
