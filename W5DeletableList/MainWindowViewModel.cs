using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace W5DeletableList
{
    public class MainWindowViewModel : BaseViewModel
    {
        public DeletableListViewModel ProductList { get; set; }
        public DeletableListViewModel StringList { get; set; }
        public MainWindowViewModel()
        {
            ProductList = new ProductSearchableView( new List<object>() {
                new Product() { ProductID = 1, ProductName = "Milkshake"},
                new Product() { ProductID = 2, ProductName = "Apple Juice"},
                new Product() { ProductID = 3, ProductName = "Mocktail"},
                new Product() { ProductID = 4, ProductName = "Cocktail"},
                new Product() { ProductID = 5, ProductName = "On the Rocks"},
            });

            StringList = new DeletableListViewModel(new List<object>() { "Owais", "Amey", "Ajay", "Sagar" });
        }        
    }
}
