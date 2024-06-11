namespace SM.Application.Contracts.ProductAgg;

public class CreateProductModel
{
    public string Name { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }
    public string Description { get; set; }
    public int ProductCategoryId { get; set; }
}