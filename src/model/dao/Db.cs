using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using DailyMealPlanner.model.business;

namespace DailyMealPlanner.model.dao
{
    public class Db
    {
        private static readonly Db db = new Db();

        private readonly IProductDao productDao = new ProductDaoImpl();

        private readonly ObservableCollection<MealTime> mealTimes = new ObservableCollection<MealTime>();
        private readonly ObservableCollection<Product> products;

        private Db()
        {
            products = productDao.ReadAllProduct(Path.GetFullPath(@"..\..\resources\FoodProducts.xml"));
        }

        public static Db GetInstance()
        {
            return db;
        }

        #region Products

        public ObservableCollection<Product> GetProducts()
        {
            return products;
        }

        public ObservableCollection<Category> GetCategories()
        {
            HashSet<Category> categories = new HashSet<Category>();

            foreach (Product i in products)
            {
                categories.Add(i.Category);
            }

            return new ObservableCollection<Category>(categories);
        }
        
        public ObservableCollection<Product> GetProductByCategory(Category category)
        {
            ObservableCollection<Product> categoryOfProducts = new ObservableCollection<Product>();

            foreach (Product i in products)
            {
                if (i.Category.Equals(category))
                {
                    categoryOfProducts.Add(i);
                }
            }

            return categoryOfProducts;
        }

        #endregion

        #region Meal Time

        public List<MealTime> GetMealTimes()
        {
            return mealTimes.ToList<MealTime>();
        }

        public ObservableCollection<string> GetNameOfMealTimes()
        {
            ObservableCollection<string> resultNameOfMealTimes = new ObservableCollection<string>();
            foreach (MealTime i in mealTimes)
            {
                resultNameOfMealTimes.Add(i.Time.Name);
            }

            return resultNameOfMealTimes;
        }

        public void AddMealTime(Time time)
        {
            mealTimes.Add(new MealTime(time));
        }

        public ObservableCollection<Product> GetProductsByTime(Time time)
        {
            return mealTimes.ToList<MealTime>().Find(x => x.Time.Equals(time)).Products;
        }

        public void AddProductByTime(Product product, Time time)
        {
            foreach (MealTime i in mealTimes)
            {
                if (i.Time.Equals(time))
                {
                    i.Products.Add(product);
                    break;
                }
            }
        }

        public void DeleteMealTime(Time time)
        {
            foreach (MealTime i in mealTimes)
            {
                if (i.Time.Equals(time))
                {
                    mealTimes.Remove(i);
                    break;
                }
            }
        }
        public void DeleteProduct(Time time, Product product)
        {
            foreach (MealTime i in mealTimes)
            {
                if (i.Time.Equals(time))
                {
                    i.Products.Remove(product);
                    break;
                }
            }
        }

        public void DeleteAllProducts(Time time)
        {
            foreach (MealTime i in mealTimes)
            {
                if (i.Time.Equals(time))
                {
                    i.Products = new ObservableCollection<Product>();
                    break;
                }
            }
        }

        #endregion
    }
}