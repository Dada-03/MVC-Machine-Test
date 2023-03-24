using System;

public class ProductController : Controller
{
    private readonly AppDbContext _dbContext;

    public ProductController()
    {
        _dbContext = new AppDbContext();
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _dbContext.Dispose();
        }
        base.Dispose(disposing);
    }


