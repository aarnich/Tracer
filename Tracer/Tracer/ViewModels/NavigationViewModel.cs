using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tracer.Models;
using Tracer.ViewModel.Base;

namespace Tracer.ViewModels
{
    public class NavigationViewModel : ViewModelBase
    {
        private Item _item;

        public Item Item
        {
            get { return _item; }
            set
            {
                _item = value;
                OnPropertyChanged();
            }
        }
        public override Task InitializeAsync(object navigationData)
        {
            if (navigationData is Item)
                Item = (Item)navigationData;


            return base.InitializeAsync(navigationData);
        }
    }
}
