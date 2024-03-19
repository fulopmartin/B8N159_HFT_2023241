using B8N159_HFT_2023241.GUI_Client.Controls;
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
using System.Windows.Controls;

namespace B8N159_HFT_2023241.GUI_Client.ViewModels
{
    public class MainWindowViewModel : ObservableRecipient
    {
        private UserControl selectedControl;

        public UserControl SelectedControl
        {
            get { return selectedControl; }
            set { SetProperty(ref selectedControl, value); }
        }
        //RestCollections
        
        public RestCollection<Wine> Wines {  get; set; }
        public RestCollection<Winery> Wineries {  get; set; }

        //Commands
        public RelayCommand AwardCommand { get; set; }
        public RelayCommand WinesCommand { get; set; }
        public RelayCommand WineriesCommand { get; set; }


        private static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        public MainWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                
                Wines = new RestCollection<Wine>("http://localhost:5874/", "wine");
                Wineries = new RestCollection<Winery>("http://localhost:5874/", "winery");

                AwardsUserControl awardsControl = new AwardsUserControl();
                WinesUserControl winesControl = new WinesUserControl();
                WineriesUserControl wineriesControl = new WineriesUserControl();
                


                AwardCommand = new RelayCommand(() =>
                {
                    SelectedControl = awardsControl;
                });
                WinesCommand = new RelayCommand(() =>
                {
                    SelectedControl = winesControl;
                });
                WineriesCommand = new RelayCommand(() =>
                {
                    SelectedControl = wineriesControl;
                });                

            }
        }
    }
}
