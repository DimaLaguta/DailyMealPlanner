using DailyMealPlanner.src.model.dao;
using DailyMealPlanner.src.model.dao.impl;
using DailyMealPlanner.src.model.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyMealPlanner.src.model.service
{
    public class CategoryService
    {
        ICategoryDao categoryDao = new CategoryDaoImpl();
        public CategoryService()
        {
            List<Category> cat = categoryDao.readAllProduct(@"..\..\resources\FoodProducts.xml");
        }
    }
}
