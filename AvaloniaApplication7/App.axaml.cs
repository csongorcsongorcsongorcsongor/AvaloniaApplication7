using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using Avalonia.Platform.Storage;
using AvaloniaApplication7.Models;
using AvaloniaApplication7.Persistence;
using AvaloniaApplication7.ViewModels;
using AvaloniaApplication7.Views;
namespace AvaloniaApplication7;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        BindingPlugins.DataValidators.RemoveAt(0);


        TextDataAccess dataAccess = new TextDataAccess();
        ParcelModel mainModel = new ParcelModel(dataAccess);
        MainViewModel viewModel = new MainViewModel(mainModel);

        MainView view = new MainView();

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = viewModel
            };
            viewModel.SaveEvent += async (s, e) =>
            {
                TopLevel topLevel = TopLevel.GetTopLevel(view);
                var file = await topLevel.StorageProvider.SaveFilePickerAsync(new FilePickerSaveOptions
                {
                    Title = "Save Parcel",
                    DefaultExtension = "txt",
                });
                if (file is not null)
                {
                    mainModel.Save(file.Path.AbsolutePath);
                }
            };

            viewModel.LoadEvent += async (s, e) =>
            {
                TopLevel topLevel = TopLevel.GetTopLevel(view);
                var file = await topLevel.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
                {
                    Title = "Load Parcel",
                    AllowMultiple = false,
                });

                if (file is not null)
                {
                    await mainModel.Load(file[0].Path.AbsolutePath);
                }
            };
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = new MainView
            {
                DataContext = viewModel
            };
        }

        base.OnFrameworkInitializationCompleted();
    }

}
