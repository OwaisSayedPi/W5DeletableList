using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace W5DeletableList
{
    public class Deletable
    {
        private Action<object> deleteFromList;
        public object item { get; set; }
        public string DisplayValue { get; set; }
        public ICommand DeleteCommand { get; set; }
        public Deletable(Action<object> deleteFromList)
        {
            this.deleteFromList = deleteFromList;
            DeleteCommand = new RelayCommand(deleteFromList, this);
        }
    }
}
