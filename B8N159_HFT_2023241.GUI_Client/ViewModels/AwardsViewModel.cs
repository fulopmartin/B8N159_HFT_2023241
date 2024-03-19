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
    public class AwardsViewModel : ObservableRecipient
    {
        public RestCollection<Award> Awards { get; set; }
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
                Awards = new RestCollection<Award>("http://localhost:5874/", "award");
            }
        }
    }
}
