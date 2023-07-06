using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace W5DeletableList
{
    public class ProductSearchableView : DeletableListViewModel
    {
        public ProductSearchableView(List<object> items) : base(items)
        {
        }
        protected override Deletable DisplayItem(object item)
        {
            Product product = (Product)item;
            Deletable deletable = new Deletable(DeleteFromList)
            {
                item = item,
                DisplayValue = product.ProductName,
            };
            return deletable;
        }
        protected override bool Validate(string searchValue, object item)
        {
            Product p = (Product)item;
            return p?.ProductName.ToLower().Contains(searchValue?.ToLower() ?? "") ?? false;
        }
    }
}