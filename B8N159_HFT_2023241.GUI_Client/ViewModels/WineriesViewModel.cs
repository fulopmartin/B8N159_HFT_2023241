using B8N159_HFT_2023241.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace B8N159_HFT_2023241.GUI_Client.ViewModels
{
    public class WineriesViewModel : ObservableRecipient
    {
        public RestCollection<Winery> Wineries { get; set; }


        public RelayCommand CreateWineryCommand { get; set; }
        public RelayCommand UpdateWineryCommand { get; set; }
        public RelayCommand DeleteWineryCommand { get; set; }

        private Winery selectedFromListbox;

        public Winery SelectedFromListbox
        {
            get { return selectedFromListbox; }
            set
            {
                if (value != null)
                {
                    selectedFromListbox = new Winery()
                    {
                        WineryId = value.WineryId,
                        Name = value.Name,
                        Zipcode = value.Zipcode,
                        Wines = value.Wines
                    };
                    OnPropertyChanged();
                    (DeleteWineryCommand as RelayCommand).NotifyCanExecuteChanged();

                }
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
        public WineriesViewModel()
        {
            if (!IsInDesignMode)
            {
                Wineries = new RestCollection<Winery>("http://localhost:5874/", "winery", "hub");

                CreateWineryCommand = new RelayCommand( async() =>
                {
                    try
                    {
                        await Wineries.Add(new Winery
                        {
                            Name = SelectedFromListbox.Name,
                            Zipcode = SelectedFromListbox.Zipcode
                        });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                });

                DeleteWineryCommand = new RelayCommand( async() =>
                {
                    try
                    {
                        await Wineries.Delete(SelectedFromListbox.WineryId);                     
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    
                },
                () =>
                {
                    return SelectedFromListbox != null;
                }
                );

                UpdateWineryCommand = new RelayCommand( async() =>
                {
                    try
                    {
                        await Wineries.Update(SelectedFromListbox);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                },
                () => 
                { 
                    return SelectedFromListbox != null; 
                });

                SelectedFromListbox = new Winery();
            }
        }
    }
}
