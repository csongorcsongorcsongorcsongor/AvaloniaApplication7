using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;

namespace AvaloniaApplication7.Models
{
    public class Parcel
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public DateOnly SubmitDate { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string Status { get; set; }
        public int Cost { get; set; }
        public int DeliveryDate { get; set; }


        public Parcel(string name, string id, DateOnly submitdate, string origin, string destination, string status, int cost, int deliverydate)
        {
            this.Name = name;
            ID = id;
            SubmitDate = submitdate;
            Origin = origin;
            Destination = destination;
            Status = status;
            Cost = cost;
            DeliveryDate = deliverydate;
        }

    }
}
