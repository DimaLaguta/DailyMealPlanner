using System.Collections.ObjectModel;
using DailyMealPlanner.model.business;
using DailyMealPlanner.model.dao;

namespace DailyMealPlanner.model.service
{
    public class ProductService
    {
        private readonly Db db = Db.GetInstance();

        public ProductService()
        {
        }

        public ObservableCollection<Category> GetCategories()
        {
            return db.GetCategories();
        }

        public ObservableCollection<Product> GetProductByCategory(Category category)
        {
            return db.GetProductByCategory(category);
        }

        internal double GetGrammsCoefficient(Product product)
        {
            return product.Gramms / product.GrammsBase;
        }
    }
}