using DailyMealPlanner.src.model.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyMealPlanner.src.model.dao
{
    interface ICategoryDao
    {
        List<Category> readAllProduct(string fileName);
    }
}
