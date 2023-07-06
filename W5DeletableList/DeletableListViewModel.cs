using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace W5DeletableList
{
    public class DeletableListViewModel : BaseViewModel
    {
        public ObservableCollection<object> MainList { get; set; }
        public ObservableCollection<Deletable> DeletableList { get; set; }
        public DeletableListViewModel(List<object> list)
        {
            MainList = new ObservableCollection<object>(list);
            InitialiseDisplayList(MainList);
        }
        private string searchValue;

        public string SearchValue
        {
            get { return searchValue; }
            set
            {
                searchValue = value;
                FilterDisplayList(searchValue);
            }
        }
        protected void DeleteFromList(object item)
        {
            Deletable deletable = item as Deletable;
            MainList.Remove(deletable.item);
            InitialiseDisplayList(MainList);
            OnPropertyChanged(nameof(MainList));
            OnPropertyChanged(nameof(DeletableList));
        }

        private void FilterDisplayList(string searchValue)
        {
            DeletableList = new ObservableCollection<Deletable>();
            if (string.IsNullOrEmpty(searchValue) || string.IsNullOrWhiteSpace(searchValue))
            {
                InitialiseDisplayList(MainList);
            }
            else
            {
                foreach (var item in MainList)
                {
                    if (Validate(searchValue, item))
                    {
                        DeletableList.Add(DisplayItem(item));
                    }
                }
            }
            OnPropertyChanged(nameof(DeletableList));
        }

        protected virtual bool Validate(string searchValue, object item)
        {
            return item.ToString().ToLower().Contains(searchValue?.ToLower() ?? "");
        }

        public string _selectedItem { get; set; }
        public string SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                if (SearchValue != value)
                {
                    SearchValue = value;
                }
                OnPropertyChanged(nameof(SearchValue));
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        private void InitialiseDisplayList(ObservableCollection<object> mainList)
        {
            DeletableList = new ObservableCollection<Deletable>();
            foreach (var item in mainList)
            {
                DeletableList.Add(DisplayItem(item));
            }
        }

        protected virtual Deletable DisplayItem(object item)
        {
            Deletable deletable = new Deletable(DeleteFromList)
            {
                item = item,
                DisplayValue = item.ToString()
            };
            return deletable;
        }
    }
}