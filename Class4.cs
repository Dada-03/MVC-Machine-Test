using System;

public class CategoryController : Controller
{
    private readonly AppDbContext _dbContext;

    public CategoryController()
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

    // GET: Category
    public ActionResult Index()
    {
        var categories = _dbContext.Categories.ToList();
        return View(categories);
    }

    // GET: Category/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: Category/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Category category)
    {
        if (ModelState.IsValid)
        {
            _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(category);
    }

    // GET: Category/Edit/5
    public ActionResult Edit(int id)
    {
        var category = _dbContext.Categories.Find(id);
        if (category == null)
        {
            return HttpNotFound();
        }
        return View(category);
    }

    // POST: Category/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(Category category)
    {
        if (ModelState.IsValid)
        {
            _dbContext.Entry(category).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(category);
    }

    // GET: Category/Delete/5
    public ActionResult Delete(int id)
    {
        var category = _dbContext.Categories.Find(id);
        if (category == null)
        {
            return HttpNotFound();
        }
        return View(category);
    }

    // POST: Category/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
        var category = _dbContext.Categories.Find(id);
        if (category == null)
        {
            return HttpNotFound();
        }
        _dbContext.Categories.Remove(category);
        _dbContext.SaveChanges();
        return RedirectToAction("Index");
    }
}

