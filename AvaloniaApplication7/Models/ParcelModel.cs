using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvaloniaApplication7.Persistence;

namespace AvaloniaApplication7.Models
{
    public class ParcelModel
    {
        private readonly IDataAccess _dataAccess;

        public event EventHandler<ParcelEventArgs?> ParcelLoaded;

        public Parcel? CurrentParcel { get; private set; }

        public ParcelModel(IDataAccess access)
        {
            _dataAccess = access;
        }

        public void SetParcel(Parcel parcel)
        {
            CurrentParcel = parcel;
        }

        public async Task Save(string path)
        {
            if(CurrentParcel != null) await _dataAccess.Save(path,CurrentParcel);
        }
        public async Task Load(string path)
        {
            CurrentParcel = await _dataAccess.Load(path);
            if (CurrentParcel != null) { ParcelLoaded?.Invoke(this, new ParcelEventArgs(CurrentParcel)); }

        }
    }
}
