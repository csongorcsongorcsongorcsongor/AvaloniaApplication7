using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication7.Models
{
    public class ParcelEventArgs : EventArgs
    {

        public Parcel Parcel { get; private set; }

        public ParcelEventArgs(Parcel parcel)
        {
            Parcel = parcel;
        }
    }   
}
