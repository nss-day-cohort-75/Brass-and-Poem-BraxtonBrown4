
//create a "products" variable here to include at least five Product instances. Give them appropriate ProductTypeIds.

List<Product> products = new List<Product> {

    new Product {
        Name = "Haiku",
        Price = 12.00m,
        ProductTypeId = 2,
    },

    new Product {
        Name = "Sonnet",
        Price = 11.50m,
        ProductTypeId = 2,
    },

    new Product {
        Name = "Free Verse",
        Price = 29.99m,
        ProductTypeId = 2,
    },

    new Product {
        Name = "Tuba",
        Price = 400.00m,
        ProductTypeId = 1,
    },

    new Product {
        Name = "Brass Pipe",
        Price = 1000.00m,
        ProductTypeId = 1,
    },
};

//create a "productTypes" variable here with a List of ProductTypes, and add "Brass" and "Poem" types to the List. 

List<ProductType> productTypes = new List<ProductType> {

    new ProductType {
        Id = 1,
        Title = "Brass",
    },

    new ProductType {
        Id = 2,
        Title = "Poem",
    },
};

//put your greeting here

Console.WriteLine(@"
**********************************
*** Welcome To Brass And Poems ***
**********************************
");

//implement your loop here

Boolean on = true;

while (on)
{
    Console.WriteLine(@"
************
*** Menu ***
************
");

    DisplayMenu();

    Console.WriteLine("Please enter a number to select an option");

    int choice = int.Parse(Console.ReadLine().Trim());

    switch (choice)
    {
        case 1:
            Console.WriteLine(@"
********************
*** All Products ***
********************
    ");
            DisplayAllProducts(products, productTypes);

            pause();
            break;

        case 2:
            Console.WriteLine(@"
************************
*** Delete By Number ***
************************
    ");

            DisplayAllProducts(products, productTypes);

            Console.WriteLine(@"
Please enter the number of the product you would like to delete");

            DeleteProduct(products, productTypes);

            pause();
            break;

        case 3:

            break;

        case 4:

            break;

        case 5:
            Console.WriteLine("Exiting... Bye Bye!");
            on = false;
            break;

        default:
            Console.WriteLine("Please select a valid integer.");
            break;
    }

}

void pause()
{
    Console.WriteLine(@"
press enter to continue
    ");
    Console.ReadLine();
}

void DisplayMenu()
{
    Console.WriteLine(@"
1. Display all products
2. Delete a product
3. Add a new product
4. Update product properties
5. Exit
    ");
}

void DisplayAllProducts(List<Product> products, List<ProductType> productTypes)
{
    foreach (Product product in products)
    {
        ProductType type = productTypes.FirstOrDefault(productType => productType.Id == product.ProductTypeId);

        Console.WriteLine($"{products.IndexOf(product) + 1}. {type.Title} {product.Name} - ${product.Price}");
    }
}

void DeleteProduct(List<Product> products, List<ProductType> productTypes)
{
    int productIndex = int.Parse(Console.ReadLine().Trim()) - 1;

    products.RemoveAt(productIndex);
}

void AddProduct(List<Product> products, List<ProductType> productTypes)
{
    throw new NotImplementedException();
}

void UpdateProduct(List<Product> products, List<ProductType> productTypes)
{
    throw new NotImplementedException();
}

// don't move or change this!
public partial class Program { }