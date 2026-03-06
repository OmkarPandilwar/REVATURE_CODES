public class ProductServices : IProductService
{
    private readonly List<Product> _products;  // create a field to store products

    public ProductServices()  // constructor to initialize the product list
    {
        _products = new List<Product>
        {
            new Product { Id = 1, Name = "Product 1", Price = 10.99m },
            new Product { Id = 2, Name = "Product 2", Price = 19.99m },
            new Product { Id = 3, Name = "Product 3", Price = 5.99m }
        };
    }

    public IEnumerable<Product> GetAllProducts()  // method to return all products
    {
        return _products;
    }

    public Product GetProductById(int id)  // method to get a product by its ID
    {
        return _products.FirstOrDefault(p => p.Id == id);
    }

    public void AddProduct(Product product)  // method to add a new product
    {
        _products.Add(product);
    }

    public void UpdateProduct(Product product)  // method to update an existing product
    {
        var existingProduct = GetProductById(product.Id);
        if (existingProduct != null)
        {
            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
        }
    }

    public void DeleteProduct(int id)  // method to delete a product by its ID
    {
        var productToRemove = GetProductById(id);
        if (productToRemove != null)
        {
            _products.Remove(productToRemove);
        }
    }   
}