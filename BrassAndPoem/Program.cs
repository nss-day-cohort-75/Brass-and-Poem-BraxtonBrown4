
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
            Console.WriteLine(@"
*********************
*** Add A Product ***
*********************
    ");

            AddProduct(products, productTypes);

            pause();
            break;

        case 4:
            Console.WriteLine(@"
************************
*** Update A Product ***
************************
    ");

            UpdateProduct(products, productTypes);

            pause();
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
    Console.WriteLine("What is the name of your product? (A-Z ONLY)");
    string name = Console.ReadLine().Trim();

    Console.WriteLine($@"
What is the price of your {name}? (DO NOT ADD A DOLLAR SIGN)");
    decimal price = decimal.Parse(Console.ReadLine().Trim());

    Console.WriteLine(@"
*********************
*** Product Types ***
*********************
    ");

    foreach (ProductType type in productTypes)
    {
        Console.WriteLine($"{type.Id}. {type.Title}");
    }

    Console.WriteLine($@"
Please enter the number of the type that matches your {name}");

    int typeId = int.Parse(Console.ReadLine().Trim());

    products.Add(
        new Product
        {
            Name = name,
            Price = price,
            ProductTypeId = typeId,
        }
    );

    Console.WriteLine($@"
{name} has been succsesfully added to the inventory");

}

void UpdateProduct(List<Product> products, List<ProductType> productTypes)
{
    Console.WriteLine("Which product would you like to update?");

    Console.WriteLine(@"
********************
*** All Products ***
********************
    ");
    DisplayAllProducts(products, productTypes);

    Console.WriteLine(@"
Please enter the number of the product you want to update");
    int productIndex = int.Parse(Console.ReadLine().Trim()) - 1;

    Product productToUpdate = products[productIndex];

    Console.WriteLine(@$"
What would you like to rename {productToUpdate.Name} to? (PRESS ENTER TO LEAVE UNCHANGED)
");
    string name = Console.ReadLine().Trim();

    if (!string.IsNullOrEmpty(name)) {
        productToUpdate.Name = name;
    };

    Console.WriteLine(@$"
What would you like to change the price of {productToUpdate.Name} to? (Current Price ${productToUpdate.Price}) (PRESS ENTER TO LEAVE UNCHANGED)
");
    string price = Console.ReadLine().Trim();

    if (!string.IsNullOrEmpty(price)) {
        productToUpdate.Price = decimal.Parse(price);
    };

    Console.WriteLine(@"
*********************
*** Product Types ***
*********************
    ");

    foreach (ProductType productType in productTypes)
    {
        Console.WriteLine($"{productType.Id}. {productType.Title}");
    }

    Console.WriteLine(@$"
What would you like to change the type of {productToUpdate.Name} to? (Current Type is {productToUpdate.ProductTypeId}) (PRESS ENTER TO LEAVE UNCHANGED)
");
   string type = Console.ReadLine().Trim();

    if (!string.IsNullOrEmpty(type)) {
        productToUpdate.ProductTypeId = int.Parse(type);
    };

    Console.WriteLine("Your product has been updated successfully");
}

// don't move or change this!
public partial class Program { }