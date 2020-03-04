using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyMealPlanner.src.model.domain
{
    public class Product
    {
        string name;
        double gramms;
        double protein;
        double fats;
        double carbs;
        double calories;

        public Product() { }

        protected Product(string name, double gramms, double protein, double fats, double carbs, double calories)
        {
            this.Name = name;
            this.Gramms = gramms;
            this.Protein = protein;
            this.Fats = fats;
            this.Carbs = carbs;
            this.Calories = calories;
        }

        public string Name { get => name; set => name = value; }
        public double Gramms { get => gramms; set => gramms = value; }
        public double Protein { get => protein; set => protein = value; }
        public double Fats { get => fats; set => fats = value; }
        public double Carbs { get => carbs; set => carbs = value; }
        public double Calories { get => calories; set => calories = value; }
    }
}
