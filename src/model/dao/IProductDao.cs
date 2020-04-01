using System.Collections.ObjectModel;
using DailyMealPlanner.model.business;

namespace DailyMealPlanner.model.dao
{
    internal interface IProductDao
    {
        ObservableCollection<Product> ReadAllProduct(string fileName);
    }
}
