using System.Collections.Generic;

namespace DailyMealPlanner.model.business
{
    public class Category
    {
        private static readonly Dictionary<string,Category> AllCategories = new Dictionary<string, Category>();

        public string Name { get; set; }
        public string Description { get; set; }

        private Category() { }

        private Category(string name, string description)
        {
            this.Name = name;
            this.Description = description;
        }

        public static Category GetInstance(string nameCategory, string description)
        {
            if (AllCategories.TryGetValue(nameCategory, out Category resultCategory)) return resultCategory;
            Category bufCategory = new Category(nameCategory, description);
            AllCategories.Add(nameCategory, bufCategory);
            return bufCategory;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() + Description.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (!(obj is Category) && (obj == null)  ) return false;
            Category obj1 = (Category)obj;
            return this.Name == obj1.Name && this.Description == obj1.Description;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
