using B8N159_HFT_2023241.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

namespace B8N159_HFT_2023241.GUI_Client.ViewModels
{
    public class WinesViewModel : ObservableRecipient
    {
        public RestCollection<Wine> Wines { get; set; }

        public RelayCommand CreateWineCommand { get; set; }
        public RelayCommand UpdateWineCommand { get; set; }
        public RelayCommand DeleteWineCommand { get; set; }

        private Wine selectedFromListbox;

        public Wine SelectedFromListbox
        {
            get { return selectedFromListbox; }
            set
            {
                if (value != null)
                {
                    selectedFromListbox = new Wine()
                    {
                        WineId = value.WineId,
                        Name = value.Name,
                        Year = value.Year,
                        Type = value.Type,
                        Price = value.Price,
                        WineryId = value.WineryId,
                        IsCheap = value.IsCheap,
                        Awards = value.Awards,
                        Winery = value.Winery
                    };                        
                }
                OnPropertyChanged();
                (UpdateWineCommand as RelayCommand).NotifyCanExecuteChanged();
                (DeleteWineCommand as RelayCommand).NotifyCanExecuteChanged();                
            }
        }

        private static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        public WinesViewModel()
        {
            if (!IsInDesignMode)
            {
                Wines = new RestCollection<Wine>("http://localhost:5874/", "wine", "hub");

                CreateWineCommand = new RelayCommand(async() =>
                {
                    await Wines.Add(new Wine() 
                    {
                        Name = SelectedFromListbox.Name,
                        Year = SelectedFromListbox.Year,
                        Type = SelectedFromListbox.Type,
                        Price = SelectedFromListbox.Price,
                        WineryId = SelectedFromListbox.WineryId
                    });
                });

                DeleteWineCommand = new RelayCommand(async() =>
                {
                    try
                    {
                        await Wines.Delete(SelectedFromListbox.WineId);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message,"Error",MessageBoxButton.OK,MessageBoxImage.Error);
                    }
                },
                () =>
                {
                    return SelectedFromListbox != null;
                }
                );

                UpdateWineCommand = new RelayCommand(async() =>
                {
                    await Wines.Update(SelectedFromListbox);
                });

                SelectedFromListbox = new Wine();
            }
        }
    }
}
