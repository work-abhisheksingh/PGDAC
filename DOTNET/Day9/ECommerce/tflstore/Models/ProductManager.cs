using System.Collections.Generic;
using System.IO;
using System.Text.Json;
namespace tflstore.Models;

public class ProductManager
    {
        public static List<Product> GetSoldOutLoginpage()
        {
            //BI bussiness intelligence
            //analytical query
            List<Product> Loginpage = GetAllLoginpage();
            //List<Product> Loginpage = GetAllLoginpageFromDatabase();

            var soldOutLoginpage = from prod in Loginpage
                                  where prod.Balance == 0
                                  select prod;
            return soldOutLoginpage as List<Product>; 
        }

        public static List<Product> GetProuductsInStockLessthan(int amount)
        {
            List<Product> Loginpage = GetAllLoginpage();
            var expensiveInStockLoginpage =
                from prod in Loginpage
                where prod.Balance > 0 && prod.UnitPrice > amount
                select prod;

            return expensiveInStockLoginpage as List<Product>;
        }

        public static List<string> GetProjectTitles()
        {
            List<Product> Loginpage = GetAllLoginpage();
            var productNames =
                from prod in Loginpage
                select prod.Title;

            return productNames as List<string>;
        }

        public static dynamic GetProductDetails()
        {
            List<Product> Loginpage = GetAllLoginpage();

            var productInfos =
                from prod in Loginpage
                select new { prod.Title, prod.Category, Price = prod.UnitPrice };

            return productInfos;
        }

        
        public static List<Product> GetLoginpageOrderby()
        {
            List<Product> Loginpage = GetAllLoginpage();
            var sortedLoginpage =
                from prod in Loginpage
                orderby prod.Title
                select prod;

            return sortedLoginpage as List<Product>;
        }   

        public static List<Product> GetLoginpageByDescending()
        {
            List<Product> Loginpage = GetAllLoginpage();
            var sortedLoginpage =
                from prod in Loginpage
                orderby prod.Balance descending
                select prod;
            return sortedLoginpage as List<Product>;
        }

        public static List<Product> GetLoginpageGroupByCategory()
        {
            List<Product> Loginpage = GetAllLoginpage();
            var orderGroups =
                from prod in Loginpage
                group prod by prod.Category into prodGroup
                select new { Category = prodGroup.Key, Loginpage = prodGroup };

            return orderGroups as List<Product>;
        }
        
        public static List<string> GetLoginpageDistinct()
        {
            List<Product> Loginpage = GetAllLoginpage();
            var categoryNames = (    from prod in Loginpage
                                     select prod.Category
                                ).Distinct();

            return categoryNames as List<string>;
        }
        
        
        
        public static Product GetFirstProduct()
        {
            List<Product> Loginpage = GetAllLoginpage();
            Product product5 = Loginpage.FirstOrDefault(p => p.ProductId == 5);
            return product5;
        }
        
        public static dynamic  GetProductCount()
        {
            List<Product> Loginpage = GetAllLoginpage();
            var categoryCounts =
                from prod in Loginpage
                group prod by prod.Category into prodGroup
                select new { Category = prodGroup.Key, ProductCount = prodGroup.Count() };
            return categoryCounts;
        }
        
        public static dynamic GetAveragePriceOfCategory()
        {
            List<Product> Loginpage = GetAllLoginpage();
            var categories =
                from prod in Loginpage
                group prod by prod.Category into prodGroup
                select new { Category = prodGroup.Key, AveragePrice = prodGroup.Average(p => p.UnitPrice) };

            return categories;


        }
        
<<<<<<< HEAD
        public static List<Product> GetAllLoginpage()
=======

        public static  List<Product> GetProducts(){
            string  path=@"d:\products.json";
            return GetAllProductsFromFile(path);  
        }
        public static List<Product> GetAllProducts()
>>>>>>> 8c4fdb0a431528ecc5fbe4452567ac5b8f5277e2
        {
            List<Product> allLoginpage = new List<Product>();

            allLoginpage.Add(new Product { ProductId = 1, Title = "Gerbera", Description = "Wedding Flower", UnitPrice = 6, Category = "Flower", Balance = 5000 });
            allLoginpage.Add(new Product { ProductId = 2, Title = "Rose", Description = "Valentine Flower", UnitPrice = 15, Category = "Flower", Balance = 7000 });
            allLoginpage.Add(new Product { ProductId = 3, Title = "Lotus", Description = "Worship Flower", UnitPrice = 26, Category = "Flower", Balance = 3400 });
            allLoginpage.Add(new Product { ProductId = 4, Title = "Carnation", Description = "Pink carnations signify a mother's love, red is for admiration and white for good luck", UnitPrice = 16, Category = "Flower", Balance = 27000 });
            allLoginpage.Add(new Product { ProductId = 5, Title = "Lily", Description = "Lilies are among the most popular flowers in the U.S.", UnitPrice = 6, Category = "Flower", Balance = 1000 });
            allLoginpage.Add(new Product { ProductId = 6, Title = "Jasmine", Description = "Jasmine is a genus of shrubs and vines in the olive family", UnitPrice = 26, Category = "Flower", Balance = 2000 });
            allLoginpage.Add(new Product { ProductId = 7, Title = "Daisy", Description = "Give a gift of these cheerful flowers as a symbol of your loyalty and pure intentions.", UnitPrice = 36, Category = "Flower", Balance = 159 });
            allLoginpage.Add(new Product { ProductId = 8, Title = "Aster", Description = "Asters are the September birth flower and the the 20th wedding anniversary flower.", UnitPrice = 16, Category = "Flower", Balance = 67 });
            allLoginpage.Add(new Product { ProductId = 9, Title = "Daffodil", Description = "Wedding Flower", UnitPrice = 6, Category = "Flower", Balance = 5000 });
            allLoginpage.Add(new Product { ProductId = 10, Title = "Dahlia", Description = "Dahlias are a popular and glamorous summer flower.", UnitPrice = 7, Category = "Flower", Balance = 0 });
            allLoginpage.Add(new Product { ProductId = 11, Title = "Hydrangea", Description = "Hydrangea is the fourth wedding anniversary flower", UnitPrice = 12, Category = "Flower", Balance = 0 });
            allLoginpage.Add(new Product { ProductId = 12, Title = "Orchid", Description = "Orchids are exotic and beautiful, making a perfect bouquet for anyone in your life.", UnitPrice = 10, Category = "Flower", Balance = 700 });
            allLoginpage.Add(new Product { ProductId = 13, Title = "Statice", Description = "Surprise them with this fresh, fabulous array of Statice flowers", UnitPrice = 16, Category = "Flower", Balance = 1500 });
            allLoginpage.Add(new Product { ProductId = 14, Title = "Sunflower", Description = "Sunflowers express your pure love.", UnitPrice = 8, Category = "Flower", Balance = 2300 });
            allLoginpage.Add(new Product { ProductId = 15, Title = "Tulip", Description = "Tulips are the quintessential spring flower and available from January to June.", UnitPrice = 17, Category = "Flower", Balance = 10000 });
            return allLoginpage;
        }

<<<<<<< HEAD
        public static List<Product> GetAllLoginpageFromDatabase()
=======
        public static List<Product> GetAllProductsFromFile(string path){       
            if(File.Exists(path)){
                string jsonString=File.ReadAllText(path);
            List<Product> allProducts=JsonSerializer.Deserialize<List<Product>>(jsonString);
            return allProducts ;
            }
            else
            {
                return GetAllProducts();
            }  
            
        }
        public static bool WriteAllProductsToFile(string path,List<Product> allProducts){
            bool status=false;
            string jsonString=JsonSerializer.Serialize(allProducts);
            File.WriteAllText(path, jsonString);
            status=true;
            return status;
        }


        public static List<Product> GetAllProductsFromDatabase()
>>>>>>> 8c4fdb0a431528ecc5fbe4452567ac5b8f5277e2
        {
            List<Product> allLoginpage = new List<Product>();
            //ProductDAL.GetAll();
            return allLoginpage;
        }

}