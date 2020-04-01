using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DailyMealPlanner.model.business;
using DailyMealPlanner.model.dao;

namespace DailyMealPlanner.model.service
{
    public class MealTimeService
    {
        private readonly Db db = Db.GetInstance();

        private readonly ProductService productService = new ProductService();

        public MealTimeService()
        {
        }

        public List<MealTime> GetMealTimes()
        {
            return db.GetMealTimes();
        }

        public ObservableCollection<string> GetNameOfMealTime()
        {
            return db.GetNameOfMealTimes();
        }

        public void AddMealTime(Time time)
        {
            db.AddMealTime(time);
        }

        public void DeleteMealTime(Time time)
        {
            db.DeleteMealTime(time);
        }

        public ObservableCollection<Product> GetProducts(Time time)
        {
            return db.GetProductsByTime(time);
        }

        public void AddProductByTime(Product product, string timeString)
        {
            Time time = Time.GetInstance(timeString);
            db.AddProductByTime(product, time);
        }

        public void DeleteProduct(Time time, Product product)
        {
            db.DeleteProduct(time, product);
        }

        public void DeleteAllProducts(string timeString)
        {
            Time time = Time.GetInstance(timeString);
            db.DeleteAllProducts(time);
        }

        public int CalculateCaloriesPerDay()
        {
            double resultCalories = 0;
            List<MealTime> mealTimes = db.GetMealTimes();
            foreach (MealTime mealTime in mealTimes)
            {
                foreach (Product product in mealTime.Products)
                {
                    resultCalories += productService.GetGrammsCoefficient(product) * product.Calories;
                }
            }

            return (int) Math.Round(resultCalories);
        }
    }
}