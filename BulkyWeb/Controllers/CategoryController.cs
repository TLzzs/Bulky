using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BulkyWeb.Controllers;

public class CategoryController : Controller
{
    private readonly ApplicationDbContext context;
    public CategoryController(ApplicationDbContext context)
    {
        this.context = context;
    }

    public IActionResult Index()
    {
        List<Category> objCategoryList = context.Categories.ToList();
        return View(objCategoryList);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Category category)
    {
        // if (category.Name == category.DisplayOrder.ToString())
        // {
        //     ModelState.AddModelError("Name", "Name can not be the same as Display Order");
        // }
        
        context.Categories.Add(category);
        context.SaveChanges();
        TempData["Success"] = "Category created successfully";
        return RedirectToAction("Index");
    }


    public IActionResult Edit(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        Category? category = context.Categories.Find(id);
        if (category == null)
        {
            return NotFound();
        }
        return View(category);
    }

    [HttpPost]
    public IActionResult Edit(Category category)
    {
        if (ModelState.IsValid)
        {
            context.Categories.Update(category);
            context.SaveChanges();
            TempData["Success"] = "Category updated successfully";
            return RedirectToAction("Index");
        }
        return View(category);
        
    }
    
    
    public IActionResult Delete(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        Category? category = context.Categories.Find(id);
        if (category == null)
        {
            return NotFound();
        }
        return View(category);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeletePost(int? id)
    {
        Category? category = context.Categories.Find(id);
        if (category == null)
        {
            return NotFound();
        } 
        context.Categories.Remove(category);
        context.SaveChanges();
        TempData["Success"] = "Category deleted successfully";
        return RedirectToAction("Index");
    }
}