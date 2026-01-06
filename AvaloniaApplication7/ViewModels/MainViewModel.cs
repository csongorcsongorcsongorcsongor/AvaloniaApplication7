using System;
using System.Collections.ObjectModel;
using AvaloniaApplication7.Models;
using CommunityToolkit.Mvvm.Input;

namespace AvaloniaApplication7.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    private ParcelModel _model;



    private string _name { get; set; }
    private string _id { get; set; }
    private DateOnly _submitDate { get; set; }
    private string _origin { get; set; }
    private string _destination { get; set; }
    //private string _status { get; set; }
    private int _cost { get; set; }
    private int _deliveryDate { get; set; }



    public string ParcelNameInput
    {
        get { return _name; }
        set
        {
            if (_name != value)
            {
                _name = value;
                OnPropertyChanged();
            }
        }
    }
    public string IDInput
    {
        get { return _id; }
        set
        {
            if (_id != value)
            {
                _id = value;
                OnPropertyChanged();
            }
        }
    }
    public DateOnly SubmitInput
    {
        get { return _submitDate; }
        set
        {
            if (_submitDate != value)
            {
                _submitDate = value;
                OnPropertyChanged();
            }
        }
    }
    public string OriginInput
    {
        get { return _origin; }
        set
        {
            if (_origin != value)
            {
                _origin = value;
                OnPropertyChanged();
            }
        }
    }
    public string DestinationInput
    {
        get { return _destination; }
        set
        {
            if (_destination != value)
            {
                _destination = value;
                OnPropertyChanged();
            }
        }
    }
    //public string StatusInput
    //{
    //    get { return _status; }
    //    set
    //    {
    //        if (_status != value)
    //        {
    //            _status = value;
    //            OnPropertyChanged();
    //        }
    //    }
    //}
    public int CostInput
    {
        get { return _cost; }
        set
        {
            if (_cost != value)
            {
                _cost = value;
                OnPropertyChanged();
            }
        }
    }
    public int ETAInput
    {
        get { return _deliveryDate; }
        set
        {
            if (_deliveryDate != value)
            {
                _deliveryDate = value;
                OnPropertyChanged();
            }
        }
    }


    public ObservableCollection<string> StatusOptions { get; } =
    new ObservableCollection<string>
    {
        "feldolgozas alatt",
        "kiszallitas alatt",
        "kiszallitva",
        "torolve"
    };

    private string _status;
    public string StatusInput
    {
        get => _status;
        set
        {
            if (_status != value)
            {
                _status = value;
                OnPropertyChanged();
            }
        }
    }




    public RelayCommand AddParcelCommand { get; set; }
    public RelayCommand SaveCommand { get; set; }
    public RelayCommand LoadCommand { get; set; }

    public ObservableCollection<Parcel> Parcels { get; set; }

    public event EventHandler SaveEvent;
    public event EventHandler LoadEvent;
    
    public MainViewModel(ParcelModel model)
    {
        _model = model;


        Parcels = new ObservableCollection<Parcel>();
        AddParcelCommand = new RelayCommand(AddParcel);

        SaveCommand = new RelayCommand(OnSave);
        LoadCommand = new RelayCommand(() => { LoadEvent?.Invoke(this, EventArgs.Empty); });
    }

    private void OnSave()
    {
        var parcel = new Parcel(ParcelNameInput,
            IDInput,
            SubmitInput,
            OriginInput,
            DestinationInput,
            StatusInput,
            CostInput, ETAInput);
        _model.SetParcel(parcel);
        SaveEvent?.Invoke(this, EventArgs.Empty);
    }
    private void Model_ParcelLoaded(object? sender, ParcelEventArgs e)
    {
        int deliveryDays = ETAInput;

        if (StatusInput == "kiszallitva")
            deliveryDays = 0;

        ParcelNameInput = e.Parcel.Name;
        IDInput = e.Parcel.ID;
        SubmitInput = e.Parcel.SubmitDate;
        OriginInput = e.Parcel.Origin;
        DestinationInput = e.Parcel.Destination;
        StatusInput = e.Parcel.Status;
        CostInput = e.Parcel.Cost;
        deliveryDays = e.Parcel.DeliveryDate; 
    }

    private void AddParcel()
    {
        if (CostInput <= 0)
            return;

        int deliveryDays = ETAInput;

        if (StatusInput == "kiszallitva")
            deliveryDays = 0;

        var package = new Parcel(
            ParcelNameInput,
            IDInput,
            SubmitInput,
            OriginInput,
            DestinationInput,
            StatusInput,
            CostInput,
            deliveryDays
        );

        Parcels.Add(package);
    }

}
