using ConsoleApp1;

public class Program
{
    public static void Main(string[] args)
    {

        List<Product> catalog = new()
        {
            new Product { ID=1, Name="Laptop", Category="Electronics", Price=1200, Stock=10 },
            new Product { ID=2,Name="Phone", Category="Electronics", Price=800, Stock=25 },
            new Product { ID=3, Name="T-Shirt", Category="Clothing", Price=30, Stock=100 },
            new Product { ID=4, Name="Jeans", Category="Clothing", Price=60, Stock=50 },
            new Product { ID=5, Name="Chocolate", Category="Food", Price=5, Stock=200 },
            new Product { ID=6, Name="Coffee Beans", Category="Food", Price=15, Stock=80 },
            new Product { ID=7, Name="C# Book", Category="Books", Price=45, Stock=30 },
            new Product { ID=8, Name="Novel", Category="Books", Price=20, Stock=60 },
            new Product { ID=9,Name="Headphones", Category="Electronics", Price=150,Stock=40 },
            new Product { ID=10, Name="Jacket", Category="Clothing", Price=120, Stock=15 }
        };

        var product = new Product();

        #region SearchMethod

        List<Product> electronics = product.SearchProducts(catalog, p => p.Category == "Electronics");

        Console.WriteLine("--- Electronics ---");
        foreach (Product p in electronics)
        {
            Console.WriteLine(
                $"{p.Name} - ${p.Price} (Stock: {p.Stock})"
            );
        }

        electronics = product.SearchProducts(catalog, p => p.Price < 50);
        Console.WriteLine();

        Console.WriteLine("--- Under $50 ---");
        foreach (Product p in electronics)
        {
            Console.WriteLine(
                $"{p.Name} - ${p.Price} (Stock: {p.Stock})"
            );
        }

        electronics = product.SearchProducts(catalog, p => p.Stock > 0);
        Console.WriteLine();

        Console.WriteLine("--- In Stock ---");
        foreach (Product p in electronics)
        {
            Console.WriteLine(
                $"{p.Name} - ${p.Price} (Stock: {p.Stock})"
            );
        }

        electronics = product.SearchProducts(catalog, p => p.Category == "Clothing" && p.Price < 100);
        Console.WriteLine();

        Console.WriteLine("--- Clothing under $100 ---");
        foreach (Product p in electronics)
        {
            Console.WriteLine(
                $"{p.Name} - ${p.Price} (Stock: {p.Stock})"
            );
        }
        Console.WriteLine();

        #endregion

        #region ReportMethod

        Console.WriteLine("---Short Report---");
        product.PrintReport(catalog, p => Console.WriteLine($"{p.Name} - ${p.Price} "));
        Console.WriteLine();

        Console.WriteLine("---Detailed Report---");
        product.PrintReport(catalog, p => Console.WriteLine($"[{p.Category}] {p.Name} | Price: ${p.Price} | Stock: {p.Stock}"));
        Console.WriteLine();

        #endregion

        #region TransformMethod

        var summary = product.TransformProducts(catalog, p =>  $"{p.Name} - (${p.Price})" );

        Console.WriteLine("---Summary List---");
        foreach (var item in summary)
        {
            Console.WriteLine(item);
        }

        summary = product.TransformProducts(catalog, p => PriceLabel(p));

        Console.WriteLine("---Price Labels---");
        foreach (var item in summary)
        {
            Console.WriteLine(item);
        }
        #endregion

        #region FilterMethod

        var filteredProducts = product.FilterProducts(catalog, p => p.Stock < 20);

        Console.WriteLine("---Low Stock Alert---");

        foreach (var item in filteredProducts)
        {
            Console.WriteLine($"[LOW STOCK] {item.Name}: only {item.Stock} left!");
        }
        #endregion
    }

    public static string PriceLabel(Product p)
    {
        if (p.Price > 100)
        {
            return "Expensive!";
        }
        else
        {
            return "Affordable";
        }
    }
}


