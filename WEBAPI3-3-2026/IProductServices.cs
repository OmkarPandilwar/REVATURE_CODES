public interface IProductService
{
    IEnumerable<Product> GetAllProducts();  //  method would return collection of product 
    Product GetProductById(int id);
    void AddProduct(Product product);
    void UpdateProduct(Product product);
    void DeleteProduct(int id);
}