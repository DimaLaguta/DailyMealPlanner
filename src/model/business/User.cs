using DailyMealPlanner.src.model.business.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyMealPlanner.src.model.domain
{
    public class User
    {
        string name;
        DAILYACTIVITY dailyActivity;
        string weight;
        int age;
        double height;


        public User() { }

        public User(string name, string weight, int years, double growth)
        {
            //Name = name;
            //Weight = weight;
            //Years = years;
            //Growth = growth;
        }
        
    }
}
