using DailyMealPlanner.src.model.domain.enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyMealPlanner.src.model.domain
{
    public class Category
    {
        //русское и английское название категорий
        private static Hashtable categoryName = new Hashtable();

        CATEGORY name;
        string description;
        List<Product> products;

        static Category()
        {
            categoryName.Add("Алкоголь", CATEGORY.ALCHOHOL);
            categoryName.Add("Готовые блюда", CATEGORY.READYMEALS);
            categoryName.Add("Грибы", CATEGORY.MINCE);
            categoryName.Add("Каши, крупы", CATEGORY.PORRIDGEGRITS);
            categoryName.Add("Колбаса", CATEGORY.WURST);
            categoryName.Add("Компоты", CATEGORY.SAUCE);
            categoryName.Add("Масла", CATEGORY.OILS);
            categoryName.Add("Молочные", CATEGORY.CREAMERY);
            categoryName.Add("Замороженные овощи", CATEGORY.FROZENVEGATABLES);
            categoryName.Add("Мучное", CATEGORY.STARCHYFOOD);
            categoryName.Add("Мясо", CATEGORY.MEET);
            categoryName.Add("Овощи", CATEGORY.VEGETABLES);
            categoryName.Add("Орехи", CATEGORY.MUESLI);
            categoryName.Add("Прочее", CATEGORY.OTHER);
            categoryName.Add("Рыба", CATEGORY.FISH);
            categoryName.Add("Сладости", CATEGORY.SWEET);
            categoryName.Add("Соки", CATEGORY.JUICE);
            categoryName.Add("Супы", CATEGORY.SOUPS);
            categoryName.Add("Сухофрукты", CATEGORY.DRIEDFRUITS);
            categoryName.Add("Сыры", CATEGORY.CHEESE);
            categoryName.Add("Творог", CATEGORY.QUARK);
            categoryName.Add("Фрукты", CATEGORY.FRUITS);
            categoryName.Add("Хлеб", CATEGORY.BREAD);
            categoryName.Add("Ягоды", CATEGORY.BERRY);
            categoryName.Add("Яйца", CATEGORY.EGG);
        }

        public Category()
        {
            setName(CATEGORY.INVALID);
            Products = new List<Product>();
        }

        public List<Product> Products { get => products; set => products = value; }
        public string Description { get => description; set => description = value; }

        public void setName(CATEGORY name)
        {
            this.name = name;
        }

        public void setName(string name)
        {
            if (categoryName.ContainsKey(name))
            {
                setName((CATEGORY)categoryName[name]);
            }
            else
            {
                setName(CATEGORY.INVALID);
            }
        }

        public CATEGORY getName()
        {
            return this.name;
        }

        public string getName(CATEGORY name)
        {
            if (categoryName.ContainsValue(name))
            {
                foreach(DictionaryEntry element in categoryName)
                {
                    if((CATEGORY)element.Value == name)
                    {
                        return (string)element.Key;
                    }
                }
            }
            return CATEGORY.INVALID.ToString();
        }
    }
}
