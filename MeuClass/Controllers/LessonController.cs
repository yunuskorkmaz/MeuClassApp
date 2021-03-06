﻿
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Web;
using MeuClass.Business.Repository;
using MeuClass.Data;
using MeuClass.Filters;
using System.Web.Mvc;
using MeuClass.Business.ResultData;
using MeuClass.Models;

namespace MeuClass.Controllers
{
    public class LessonController : Controller
    {
        // GET: Lesson
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Detail(int id, string subview = "")
        {
            var lesson = LessonRepository.Instance._getByID(id);
            var teacher = lesson.Data.LessonAccess.FirstOrDefault(a => a.User.UserTypeID == 2)?.User;
            ViewBag.SubView = subview;

            var data = new LessonDetailViewModel()
            {
                Lesson = lesson.Data,
                Teacher = teacher
            };


            return View(data);
        }



        //[HttpPost]
        //public ActionResult Profile(int number, FormCollection form)
        //{
        //    var comment = form["comment"];
        //    var lesson_content_id = form["LessonContentId"];

        //    if (comment != String.Empty)
        //    {
        //        LessonRepository.Instance.AddLessonComment(new LessonComment()
        //        {
        //            AddedUserID = Convert.ToInt32(Session["user_id"]),
        //            LessonContentID = Convert.ToInt32(lesson_content_id),
        //            RecordDate = DateTime.Now,
        //            LessonCommentText = comment.Trim()
        //        });
        //    }
        //    var user = UserRepository.Instance.GetProfileInfo(number).Data;
        //    return View(user);
        //}



        [HttpPost]
        public ActionResult Detail(int id,FormCollection form,HttpPostedFileBase file)
        {
            var content = form["content"];

            if (content != String.Empty)
            {
                UserFile filerecord = null;
                if (file != null)
                {
                    var ext = Path.GetExtension(file.FileName);
                    var fileName = Path.GetFileNameWithoutExtension(file.FileName);
                    var newFilename = Guid.NewGuid() + ext;
                    var path = Path.Combine(Server.MapPath("~/Content/LessonContent/"), newFilename);
                    file.SaveAs(path);

                    filerecord = new UserFile()
                    {
                        FileAdderUserID = Convert.ToInt32(Session["user_id"]),
                        RecordDate = DateTime.Now,
                        FileLink = $"~/Content/LessonContent/{newFilename}",
                        FileTitle = fileName
                    };

                }

                var lessonContent = new LessonContent()
                {
                    AddedUserID = Convert.ToInt32(Session["user_id"]),
                    LessonID = id,
                    RecordDate = DateTime.Now,
                    LessonContentText = content.Trim()
                };

                if (filerecord != null)
                {
                    lessonContent.UserFile = filerecord;
                }


            LessonRepository.Instance.AddLessonContent(lessonContent);
            }

            return Detail(id, "");
        }

        [CheckAuth(UserRole.OnlyTeacher)]
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [CheckAuth(UserRole.OnlyTeacher)]
        [HttpPost]
        public ActionResult Add(Lesson lesson)
        {
            lesson.LessonAccess = new Collection<LessonAccess>()
            {
                new LessonAccess()
                {
                    UserID = Convert.ToInt32(Session["user_id"])
                }
            };
            var insert = LessonRepository.Instance.Add(lesson);
            return RedirectToAction("Detail", "Lesson", new { id = insert.Data.LessonID });
        }

        [HttpGet]
        [Route("Lesson/Join/{code}/{id}")]
        public ActionResult Join(string code, int id = 0)
        {
            ResultData<Lesson> data;



            if (id != 0)
            {
                data = LessonRepository.Instance.Join(code, id);
            }
            else
            {
                data = ResultData<Lesson>.Instance.Fill(false, "Hata var");
            }

            ResultData<Lesson> result = new ResultData<Lesson>();
            if (data.Success == true)
            {
                result.Success = true;
                result.Data = new Lesson
                {
                    LessonName = data.Data.LessonName,
                    LessonID = data.Data.LessonID
                };

            }
            else
            {
                result.Success = false;
                result.Data = null;
                result.Message = data.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);

        }


    }
}