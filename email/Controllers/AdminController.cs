using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using email.Models;
using email.Services;


namespace email.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            MailServices usa = new MailServices();
            List<Mail> groupList = usa.getAllmailtList();
            return View(groupList);
        }
        public ActionResult Sourcelist()
        {
            MailServices usa = new MailServices();
            List<Mail> groupList = usa.getAllmailtList();
            return View(groupList);
           
        }
        public ActionResult UseremailList()
        { 
            return View();
        }
        public ActionResult Sendemail()
        {
            return View();
        }

        public ActionResult CreatetTemplate()
        {
            return View();
        }

        public JsonResult mailSend(Mail mail)
        {
           MailServices usa = new MailServices();
            int status = usa.insertmailServices(mail);
            if (status > 0)
            {
                return Json(new { success = "200", mesaage = "Success" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = "400", mesaage = "Failed" }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult updateGroupname(Mail mail)
        {
            MailServices usa = new MailServices();
            int status = usa.updategroup(mail);
            if (status > 0)
            {
                return Json(new { success = "200", mesaage = "Success" }, JsonRequestBehavior.AllowGet);

            }
            else
            {
                return Json(new { success = "400", mesaage = "Failed" }, JsonRequestBehavior.AllowGet);

            }


            }
        public ActionResult Delete_Event(string id)
        {
            MailServices usa = new MailServices();
            int status = usa.sofrDelete(id);
            if (status > 0)
            {
                return RedirectToAction("Sourcelist");
            }
            else
            {
            }
            return null;

        }
    }
}