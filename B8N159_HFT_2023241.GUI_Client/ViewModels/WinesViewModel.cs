using B8N159_HFT_2023241.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace B8N159_HFT_2023241.GUI_Client.ViewModels
{
    public class WinesViewModel : ObservableRecipient
    {
        public RestCollection<Wine> Wines { get; set; }
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
                Wines = new RestCollection<Wine>("http://localhost:5874/", "wine");
            }
        }
    }
}
