using DailyMealPlanner.src.model.domain;
using DailyMealPlanner.src.model.domain.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyMealPlanner.src.model.business
{
    public class Element
    {
        public CATEGORY CATEGORY;
        Product product;

        public Element() { }

        public Product Product { get => product; set => product = value; }
    }
}
