namespace DailyMealPlanner.model.business
{
    public class Product
    {
        private double grammsBase;
        private double gramms;
        private double protein;
        private double fats;
        private double carbs;
        private double calories;


        public Category Category { get; private set; }
        public string Name { get; set; }

        public double GrammsBase
        {
            get { return grammsBase; }
            set { grammsBase = value >= 0 ? value : 1; }
        }

        public double Gramms
        {
            get { return gramms; }
            set { gramms = value >= 0 ? value : 1; }
        }

        public double Protein
        {
            get { return protein; }
            set { protein = value >= 0 ? value : 1; }
        }

        public double Fats
        {
            get { return fats; }
            set { fats = value >= 0 ? value : 1; }
        }

        public double Carbs
        {
            get { return carbs; }
            set { carbs = value >= 0 ? value : 1; }
        }

        public double Calories
        {
            get { return calories; }
            set { calories = value >= 0 ? value : 1; }
        }

        public Product()
        {
        }

        public Product(string nameCategory, string descriptionCategory)
        {
            this.Category = Category.GetInstance(nameCategory, descriptionCategory);
        }

        public Product(string nameCategory, string descriptionCategory, string name, double grammsBase, double gramms,
            double protein, double fats,
            double carbs, double calories) : this(nameCategory, descriptionCategory)
        {
            this.Name = name;
            GrammsBase = grammsBase;
            this.Gramms = gramms;
            this.Protein = protein;
            this.Fats = fats;
            this.Carbs = carbs;
            this.Calories = calories;
        }

        public void SetCategory(string nameCategory, string descriptionCategory)
        {
            Category = Category.GetInstance(nameCategory, descriptionCategory);
        }
    }
}