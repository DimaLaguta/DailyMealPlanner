using CarRental.Utility;
using DailyMealPlanner.src.model.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyMealPlanner.src.viewModel
{
    public class MainViewModel: OnPropertyChangedClass
    {
        CategoryService categoryService = new CategoryService();

        public MainViewModel()
        {
            
        }
    }
}
