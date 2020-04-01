using System;
using DailyMealPlanner.model.business.enums;

namespace DailyMealPlanner.model.service
{
    public class UserService
    {
        public UserService()
        {
        }

        public double Bmr(double weight, double height, int age)
        {
            return 447.593 + 9.247 * weight + 3.098 * height - 4.330 * age;
        }

        public double Amr(DailyActivity dailyActivities)
        {
            switch (dailyActivities)
            {
                case DailyActivity.LOW:
                    return 1.2;
                case DailyActivity.NORMAL:
                    return 1.275;
                case DailyActivity.AVERAGE:
                    return 1.55;
                case DailyActivity.HIGH:
                    return 1.725;
                case DailyActivity.INVALID:
                    return 1.2;
                default:
                    return 1.2;
            }
        }

        public int DailyCaloriesRate(double bmr, double amr)
        {
            return (int) Math.Round(bmr * amr);
        }
    }
}