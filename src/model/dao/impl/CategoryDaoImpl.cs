using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DailyMealPlanner.src.model.domain;
using System.Xml;
using System.Windows;

namespace DailyMealPlanner.src.model.dao.impl
{
    public class CategoryDaoImpl : ICategoryDao
    {
        public CategoryDaoImpl() { }

        public List<Category> readAllProduct(string fileName)
        {
            List<Category> categories = new List<Category>();

            XmlDocument xDoc = new XmlDocument();
            try
            {
                xDoc.Load(fileName);
            }catch(Exception e)
            {
                MessageBox.Show(e.Message);
                
            }

            XmlElement xRoot = xDoc.DocumentElement;
            foreach(XmlNode xNode in xRoot)
            {
                Category bufCategory = new Category();
                //получение атрибутов
                if (xNode.Attributes.Count > 0)
                {
                    XmlNode name = xNode.Attributes.GetNamedItem("name");
                    if (name != null)
                    {
                        bufCategory.setName(name.Value);
                    }
                    XmlNode description = xNode.Attributes.GetNamedItem("description");
                    if (description != null)
                    {
                        bufCategory.Description = description.Value;
                    }
                }
                try
                {
                    //получение элементов
                    List<Product> bufProducts = new List<Product>();
                    foreach (XmlNode childNode in xNode.ChildNodes)
                    {
                        if (childNode.Name == "Product")
                        {
                            Product bufProduct = new Product();
                            foreach (XmlNode childNode2 in childNode.ChildNodes)
                            {
                                switch (childNode2.Name)
                                {
                                    case "Name":
                                        bufProduct.Name = childNode2.InnerText;
                                        continue;
                                    case "Gramms":
                                        bufProduct.Gramms = Convert.ToDouble(childNode2.InnerText);
                                        continue;
                                    case "Protein":
                                        bufProduct.Protein = Convert.ToDouble(childNode2.InnerText);
                                        continue;
                                    case "Fats":
                                        bufProduct.Fats = Convert.ToDouble(childNode2.InnerText);
                                        continue;
                                    case "Carbs":
                                        bufProduct.Carbs = Convert.ToDouble(childNode2.InnerText);
                                        continue;
                                    case "Calories":
                                        bufProduct.Calories = Convert.ToDouble(childNode2.InnerText);
                                        continue;

                                }
                            }
                            bufProducts.Add(bufProduct);
                        }
                    }
                    bufCategory.Products = bufProducts;
                    categories.Add(bufCategory);
                }catch(Exception e)
                {
                    MessageBox.Show(e.Message);
                }

            }
            return categories;
        }
    }
}
