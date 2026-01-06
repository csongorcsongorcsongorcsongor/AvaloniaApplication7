using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication7.Models
{
    public class ParcelModel
    {

        private string _name { get; set; }
        private string _id { get; set; }
        private DateOnly _submitDate { get; set; }
        private string _origin { get; set; }
        private string _destination { get; set; }
        private string _status { get; set; }
        private int _cost { get; set; }
        private int _deliveryDate { get; set; }


    }
}
