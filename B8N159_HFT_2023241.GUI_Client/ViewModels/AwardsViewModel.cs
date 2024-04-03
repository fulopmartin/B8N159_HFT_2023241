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
    public class AwardsViewModel : ObservableRecipient
    {
        public RestCollection<Award> Awards { get; set; }

        public RelayCommand CreateAwardCommand { get; set; }
        public RelayCommand UpdateAwardCommand { get; set; }
        public RelayCommand DeleteAwardCommand { get; set; }

        private Award selectedFromListbox;

        public Award SelectedFromListbox
        {
            get { return selectedFromListbox; }
            set
            {
                if (value != null)
                {
                    selectedFromListbox = new Award()
                    {
                        AwardId = value.AwardId,
                        AwardName = value.AwardName,
                        AwardYear = value.AwardYear,
                        WineId = value.WineId,
                        IsDomestic = value.IsDomestic
                    };
                    OnPropertyChanged();                
                    (DeleteAwardCommand as RelayCommand).NotifyCanExecuteChanged();

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
        public AwardsViewModel()
        {            
            if(!IsInDesignMode)
            {
                Awards = new RestCollection<Award>("http://localhost:5874/", "award","hub");

                CreateAwardCommand = new RelayCommand(async () =>
                {
                    try
                    {
                        await Awards.Add(new Award
                        {
                            AwardName = SelectedFromListbox.AwardName,
                            AwardYear = SelectedFromListbox.AwardYear,
                            WineId = SelectedFromListbox.WineId,
                            IsDomestic = SelectedFromListbox.IsDomestic
                        });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    
                });

                DeleteAwardCommand = new RelayCommand(async () =>
                {
                    try
                    {
                        await Awards.Delete(SelectedFromListbox.AwardId);                       

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

                UpdateAwardCommand = new RelayCommand(async () =>
                {
                    try
                    {
                        await Awards.Update(SelectedFromListbox);                  

                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                },
                () =>
                {
                    return SelectedFromListbox != null;
                });

                SelectedFromListbox = new Award();
            }
        }
    }
}
