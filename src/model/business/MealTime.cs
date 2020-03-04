using DailyMealPlanner.src.model.business;
using DailyMealPlanner.src.model.domain;
using DailyMealPlanner.src.model.domain.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyMealPlanner.src.model.domain
{
    public abstract class MealTime
    {
        TIME time;

        SortedDictionary<Element, int> products;

        public MealTime() { }

        public double Gramms
        {
            get
            {
                double resultGramms = 0;
                foreach(Element i in products.Keys)
                {
                    resultGramms += i.Product.Gramms * products[i];
                }
                return resultGramms;
            }
        }
        public double Protein
        {
            get
            {
                double resultProtein = 0;
                foreach (Element i in products.Keys)
                {
                    resultProtein += i.Product.Protein * products[i];
                }
                return resultProtein;
            }
        }

        public double Fats
        {
            get
            {
                double resultFats = 0;
                foreach (Element i in products.Keys)
                {
                    resultFats += i.Product.Fats * products[i];
                }
                return resultFats;
            }
        }
        public double Carbs
        {
            get
            {
                double resultCarbs = 0;
                foreach (Element i in products.Keys)
                {
                    resultCarbs += i.Product.Carbs * products[i];
                }
                return resultCarbs;
            }
        }
        public double Calories
        {
            get
            {
                double resultCalories = 0;
                foreach (Element i in products.Keys)
                {
                    resultCalories += i.Product.Calories * products[i];
                }
                return resultCalories;
            }
        }

        public void addProduct(Element element)
        {
            if (products.Keys.Contains(element))
            {
                products[element]++;
            }
            else
            {
                products.Add(element, 1);
            }
        }
    }
}
