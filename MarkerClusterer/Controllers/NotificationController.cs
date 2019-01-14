using MarkerClusterer.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarkerClusterer.Controllers
{
    public class NotificationController : Controller
    {
        // GET: Notification
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            return View();
        }

        public ActionResult AllToast()
        {
            this.AddToastMessage("MENSAJE DE ERROR", "Mensaje de error", ToastType.Error);
            this.AddToastMessage("Mensaje Informativo", "Mensaje informativo", ToastType.Info);
            this.AddToastMessage("Mensaje Exitoso", "Mensaje exitoso", ToastType.Success);
            this.AddToastMessage("Mensaje de Advertencia", "Mensaje de Advertencia", ToastType.Warning);
            return RedirectToAction("Index");
        }
        public ActionResult Error()
        {
            this.AddToastMessage("MENSAJE DE ERROR", "Mensaje de error", ToastType.Error);
            return RedirectToAction("Index");
        }
        public ActionResult Info()
        {
            this.AddToastMessage("Mensaje Informativo", "Mensaje informativo", ToastType.Info);
            return RedirectToAction("Index");
        }
        public ActionResult Success()
        {
            this.AddToastMessage("Mensaje Exitoso", "Mensaje exitoso", ToastType.Success);
            return RedirectToAction("Index");
        }
        public ActionResult Warning()
        {
            this.AddToastMessage("Mensaje de Advertencia", "Mensaje de Advertencia", ToastType.Warning);
            return RedirectToAction("Index");
        }
    }
}