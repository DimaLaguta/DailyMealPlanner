using System.Collections.ObjectModel;

namespace DailyMealPlanner.model.business
{
    public class MealTime
    {
        public Time Time { get; set;}

        public ObservableCollection<Product> Products { get; set; }

        public MealTime() { }

        public MealTime(Time time)
        {
            this.Time = time;
            Products = new ObservableCollection<Product>();
        }
    }
}
