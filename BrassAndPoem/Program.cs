
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
    DisplayMenu();
    try
    {
        Console.WriteLine("Please enter a number to select an option");

        int choice = int.Parse(Console.ReadLine().Trim());

        switch (choice)
        {
            case 1:
                DisplayAllProducts(products, productTypes);

                pause();
                break;

            case 2:
                DeleteProduct(products, productTypes);

                pause();
                break;

            case 3:
                AddProduct(products, productTypes);

                pause();
                break;

            case 4:
                UpdateProduct(products, productTypes);

                pause();
                break;

            case 5:
                Console.WriteLine(@"
Exiting... Bye Bye!
            ");

                on = false;
                break;
        }
    }
    catch
    {
        Console.WriteLine(@"
******************************
******* FAILED ATTEMPT *******
*** SELECT A VALID INTEGER ***
******************************
");
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
************
*** Menu ***
************

1. Display all products
2. Delete a product
3. Add a new product
4. Update product properties
5. Exit
    ");
}

void DisplayAllTypes(List<Product> products, List<ProductType> productTypes)
{
    Console.WriteLine(@"
*********************
*** Product Types ***
*********************
    ");

    foreach (ProductType type in productTypes)
    {
        Console.WriteLine($"{type.Id}. {type.Title}");
    }
}

void DisplayAllProducts(List<Product> products, List<ProductType> productTypes)
{
    Console.WriteLine(@"
********************
*** All Products ***
********************
    ");

    foreach (Product product in products)
    {
        ProductType type = productTypes.FirstOrDefault(productType => productType.Id == product.ProductTypeId);

        Console.WriteLine($"{products.IndexOf(product) + 1}. {type.Title} {product.Name} - ${product.Price}");
    }
}

void DeleteProduct(List<Product> products, List<ProductType> productTypes)
{

    try
    {
        Console.WriteLine(@"
************************
*** Delete By Number ***
************************
    ");

        DisplayAllProducts(products, productTypes);

        Console.WriteLine(@"
Please enter the number of the product you would like to delete");

        int productIndex = int.Parse(Console.ReadLine().Trim()) - 1;

        products.RemoveAt(productIndex);
    }
    catch
    {
        Console.WriteLine(@"
******************************
******* FAILED ATTEMPT *******
*** SELECT A VALID INTEGER ***
******************************
");
        DeleteProduct(products, productTypes);
    }
}

void AddProduct(List<Product> products, List<ProductType> productTypes)
{
    try
    {
        Console.WriteLine(@"
*********************
*** Add A Product ***
*********************
    ");

        Console.WriteLine("What is the name of your product? (A-Z ONLY)");
        string name = Console.ReadLine().Trim();

        Console.WriteLine($@"
What is the price of your {name}? (DO NOT ADD A DOLLAR SIGN)");
        decimal price = decimal.Parse(Console.ReadLine().Trim());

        DisplayAllTypes(products, productTypes);

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
    catch
    {
        Console.WriteLine(@"
******************************
******* FAILED ATTEMPT *******
*** SELECT A VALID INTEGER ***
******************************
");
        AddProduct(products, productTypes);
    }


}

void UpdateProduct(List<Product> products, List<ProductType> productTypes)
{
    try
    {
        Console.WriteLine(@"
************************
*** Update A Product ***
************************
    ");

        Console.WriteLine("Which product would you like to update?");

        DisplayAllProducts(products, productTypes);

        Console.WriteLine(@"
Please enter the number of the product you want to update");
        int productIndex = int.Parse(Console.ReadLine().Trim()) - 1;

        Product productToUpdate = products[productIndex];

        Console.WriteLine(@$"
What would you like to rename {productToUpdate.Name} to? (PRESS ENTER TO LEAVE UNCHANGED)
");
        string name = Console.ReadLine().Trim();

        if (!string.IsNullOrEmpty(name))
        {
            productToUpdate.Name = name;
        }
    ;

        Console.WriteLine(@$"
What would you like to change the price of {productToUpdate.Name} to? (Current Price ${productToUpdate.Price}) (PRESS ENTER TO LEAVE UNCHANGED)
");
        string price = Console.ReadLine().Trim();

        if (!string.IsNullOrEmpty(price))
        {
            productToUpdate.Price = decimal.Parse(price);
        }
    ;

        DisplayAllTypes(products, productTypes);

        Console.WriteLine(@$"
What would you like to change the type of {productToUpdate.Name} to? (Current Type is {productToUpdate.ProductTypeId}) (PRESS ENTER TO LEAVE UNCHANGED)
");
        string type = Console.ReadLine().Trim();

        if (!string.IsNullOrEmpty(type))
        {
            productToUpdate.ProductTypeId = int.Parse(type);
        }
    ;

        Console.WriteLine("Your product has been updated successfully");
    }
    catch
    {
        Console.WriteLine(@"
******************************
******* FAILED ATTEMPT *******
*** SELECT A VALID INTEGER ***
******************************
");
        UpdateProduct(products, productTypes);
    }
}

// don't move or change this!
public partial class Program { }