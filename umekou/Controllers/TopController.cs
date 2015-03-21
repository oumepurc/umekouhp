using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.IO;

using umekou.Models;
namespace umekou.Controllers
{
    public class TopController : Controller
    {
        //
        // GET: /Top/
        CardModel model = new CardModel();
        public ActionResult Index()
        {

            SearchCondition_Card condition = new SearchCondition_Card();

            bool result = false;
            string resErrMsg = "";

            CardModel model = new CardModel();
            var items = model.getData(condition, ref result, ref resErrMsg);
            if (result==false)
            {
               

            }



            return View(items);
        }

        public ActionResult Editor()
        {

            ViewBag.htmlData = "";
            return View();
        }

        public ActionResult Editor_ForEdit(int id)
        {

            bool result = false;
            string resErrMsg = "";
            SearchCondition_Card condition = new SearchCondition_Card();
            condition.id = id;
            var items = model.getData(condition, ref result, ref resErrMsg);
            if (result == false)
            {

            }

            if (items == null || items.Count == 0)
            {


            }

            var item = items.First();

            ViewBag.id = id;
            ViewBag.isEditForUpdate = true;

            ViewBag.data = item;

            ViewBag.htmlData = item.edit_data;
            ViewBag.id = item.raw.id;
            return View("Editor");
        }


        //=============================================================
        //　登録データ一覧を、ＪＳＯＮデータで返す
        //　※非同期
        //=============================================================
        [OutputCache(Location = System.Web.UI.OutputCacheLocation.None)]
        public JsonResult getData_JSON()
        {
            bool result = false;
            string resErrMsg = "";
            SearchCondition_Card condition = new SearchCondition_Card();
            var items = model.getData(condition, ref result, ref resErrMsg);
            if (result == false)
            {

            }
           
            return Json(items, JsonRequestBehavior.AllowGet);
        }




        //=============================================================
        //　データを削除し、削除結果をＪＳＯＮデータで返す
        //　※非同期
        //=============================================================
        [OutputCache(Location = System.Web.UI.OutputCacheLocation.None)]
        public JsonResult removeData_JSON(int id)
        {
            JsonResultData resultData = new JsonResultData();
            resultData.result = model.remove(id, ref resultData.errMsg);
            return Json(resultData, JsonRequestBehavior.AllowGet);
        }




        //===============================================================================
        //CKEditorからのイメージを保存
        //TODO
        //===============================================================================
        [HttpPost]
        public ActionResult UploadImage(HttpPostedFileBase upload, string CKEditorFuncNum, string CKEditor, string langCode)
        {
            string vImagePath = String.Empty;
            string vMessage = String.Empty;
            string vFilePath = String.Empty;
            string vOutput = String.Empty;

            try
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    var vFileName = DateTime.Now.ToString("yyyyMMdd-HHMMssff") +
                                    Path.GetExtension(upload.FileName).ToLower();

                    string serverPath = Server.MapPath("~/img/upload_img");
                    string imagesPath = serverPath;


                    var vFolderPath = imagesPath;
                    if (!Directory.Exists(vFolderPath))
                    {
                        Directory.CreateDirectory(vFolderPath);
                    }

                    vFilePath = Path.Combine(vFolderPath, vFileName);


                    upload.SaveAs(vFilePath);


                    vImagePath = Url.Content("~/img/upload_img/" + vFileName);
                    vMessage = "Image was saved correctly";
                }
            }
            catch
            {
                vMessage = "There was an issue uploading";
            }

            vOutput = @"<html><body><script>window.parent.CKEDITOR.tools.callFunction(" + CKEditorFuncNum + ", \"" + vImagePath + "\");</script></body></html>";

            return Content(vOutput);

        }
    }
}
