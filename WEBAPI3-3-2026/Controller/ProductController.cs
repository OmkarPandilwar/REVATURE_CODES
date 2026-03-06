using Microsoft.AspNetCore.Mvc; 

[ApiController]     //THIS IS  ATTRIBUTE IN ASPNET CORE IT MARK THIS CLASS IS A WEB API CONTROOLLER 
[Route("api/[controller]")]  // set url path  for controller 

public class ProductController :ControllerBase  // give build in functionality // allow class act as api controller
//  it handlw web req   okk not found etc 
{   
    private readonly IProductService _productService;  // create a field for service
            
    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]  // this attribute indicate this method handle http get request 


    //controller action method which handle http request and return response 
    // Actionresult is use to return the http responde as ok etc 
    // ienumerable is use to return collection of product   
    public ActionResult<IEnumerable<Product>> GetAllProducts()  // return type is action result which allow us to return different http response 
    {
        var products = _productService.GetAllProducts();
        return Ok(products);  // return 200 ok with product data 
    }

    [HttpGet("{id}")]  // this attribute indicate this method handle http get request with id parameter in url
    public ActionResult<Product> GetProductById(int id)
    {
        var product = _productService.GetProductById(id);
        if (product == null)
        {
            return NotFound();  // return 404 not found if product is not exist 
        }
        return Ok(product);  // return 200 ok with product data 
    }              
    [HttpPost]  // this attribute indicate this method handle http post request
    public ActionResult AddProduct(Product product)
    {
        _productService.AddProduct(product);
        return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);  // return 201 created with location header 
    }                



}
