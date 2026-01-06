using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvaloniaApplication7.Models;


namespace AvaloniaApplication7.Persistence
{
    public interface IDataAccess
    {
        Task Save(string path, Parcel parcel);
        Task<Parcel?> Load(string path);
    }
}
