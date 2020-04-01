using System;
using System.Collections.ObjectModel;
using System.Xml;
using DailyMealPlanner.model.business;

namespace DailyMealPlanner.model.dao
{
    public class ProductDaoImpl : IProductDao
    {
        public ProductDaoImpl()
        {
        }

        public ObservableCollection<Product> ReadAllProduct(string fileName)
        {
            ObservableCollection<Product> products = new ObservableCollection<Product>();

            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(fileName);

            XmlElement xRoot = xDoc.DocumentElement;
            if (xRoot == null) return products;
            foreach (XmlNode xNode in xRoot)
            {
                if (xNode.Attributes == null) continue;
                XmlNode nameCategory = xNode.Attributes.GetNamedItem("name");
                XmlNode descriptionCategory = xNode.Attributes.GetNamedItem("description");

                foreach (XmlNode childNode in xNode.ChildNodes)
                {
                    Product bufProduct = new Product();
                    bufProduct.SetCategory(nameCategory.Value, descriptionCategory.Value);
                    if (childNode.Name != "Product") continue;
                    foreach (XmlNode childNode2 in childNode.ChildNodes)
                    {
                        switch (childNode2.Name)
                        {
                            case "Name":
                                bufProduct.Name = childNode2.InnerText;
                                break;
                            case "Gramms":
                                bufProduct.GrammsBase = Convert.ToDouble(childNode2.InnerText);
                                bufProduct.Gramms = Convert.ToDouble(childNode2.InnerText);
                                break;
                            case "Protein":
                                bufProduct.Protein = Convert.ToDouble(childNode2.InnerText);
                                break;
                            case "Fats":
                                bufProduct.Fats = Convert.ToDouble(childNode2.InnerText);
                                break;
                            case "Carbs":
                                bufProduct.Carbs = Convert.ToDouble(childNode2.InnerText);
                                break;
                            case "Calories":
                                bufProduct.Calories = Convert.ToDouble(childNode2.InnerText);
                                break;
                        }
                    }

                    products.Add(bufProduct);
                }
            }

            return products;
        }
    }
}