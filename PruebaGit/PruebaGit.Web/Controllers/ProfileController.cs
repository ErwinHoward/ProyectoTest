using Microsoft.AspNet.Identity;
using PruebaGit.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace PruebaGit.Web.Controllers { 
public class ProfileController : Controller
{
    readonly ApplicationDbContext db = new ApplicationDbContext();
    // GET: Profile
    public ActionResult Details()
    {
        var userId = User.Identity.GetUserId();
        var user = db.Users.Find(userId);
        return View(user);
    }

    [HttpPost]
    public ActionResult Details(ProfileViewModel pvm)
    {
        var userId = User.Identity.GetUserId();
        var userbd = db.Users.Find(userId);

        userbd.Name = pvm.Name;
        userbd.PhoneNumber = pvm.PhotoNumber;
        userbd.Photo = pvm.Photo;
        userbd.Videos = pvm.Videos;
        userbd.Hobbies = pvm.Hobbies;
        userbd.Descripcion = pvm.Descripcion;
        db.SaveChanges();
        return RedirectToAction("Details");

    }
    [HttpPost]
    public ActionResult Picture(HttpPostedFileBase pic)
    {

        string path = Server.MapPath("~/Upload/");
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        var userId = User.Identity.GetUserId();
        var userdb = db.Users.Find(userId);
        var photo = pic.FileName;
        var dir = "";
        if (pic != null)
        {
            dir = User.Identity.Name + Path.GetExtension(photo);
            pic.SaveAs(path + dir);
        }
        userdb.Photo = dir;
        db.SaveChanges();
        return RedirectToAction("Details");
    }

}
}