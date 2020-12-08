using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Tracer.Models;
using Tracer.Services;
using Xamarin.Forms;
using Tracer.ViewModel.Base;

namespace Tracer.ViewModels
{
    public class ItemViewModel : ViewModelBase
    {
        private Item _selectedItem;
        private ObservableCollection<Item> _items;
        private ObservableCollection<NotesItem> _notes;

        public ItemViewModel()
        {
            Task.Run(LoadData);
        }
        public ObservableCollection<Item> Items
        {
            get { return _items; }
            set { _items = value;
                OnPropertyChanged();
            }
        }
        public Item SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<NotesItem> Notes
        {
            get { return _notes; }
            set
            {
                _notes = value;
                OnPropertyChanged();
            }
        }
        public ICommand Navigate => new Command(NavigateToWindow);

        private async void LoadData()
        {
            Items = new ObservableCollection<Item>(DataService.Instance.GetItems());
            var actualNotes = await NotesService.Instance.GetActualNotes();
            Notes = new ObservableCollection<NotesItem>(actualNotes);
        }
        private void NavigateToWindow()
        {
            Console.WriteLine("I am being called");
            NavigationService.Instance.NavigateToAsync<NavigationViewModel>(SelectedItem);
        }
    }
}
