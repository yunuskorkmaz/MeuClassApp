using System;
using System.Collections.Generic;
using MeuClass.Business.ResultData;
using MeuClass.Data;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace MeuClass.Business.Repository
{
    public class LessonRepository : BaseRepository<Lesson>
    {
        public static LessonRepository Instance = new LessonRepository();

        public ResultData<Lesson> Add(Lesson lesson)
        {
            lesson.LessonCode = CodeControl();
            var result = _insert(lesson);

            if (result.Success == true)
            {
                return ResultData<Lesson>.Instance.Fill(true, result.Data);
            }
            else
            {
                return ResultData<Lesson>.Instance.Fill(false, result.Message);
            }
        }

        public List<LessonContent> GetLessonContent(int lessonID)
        {
            var db = new ClassAppContext();

            return db.LessonContent.Where(l => l.LessonID == lessonID)?.ToList();
        }

        public bool AddLessonContent(LessonContent content)
        {
            var db = new ClassAppContext();

            try
            {
                var added = db.LessonContent.Add(content);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public bool AddLessonComment (LessonComment comment)
        {
            var db = new ClassAppContext();
            try
            {
                var added = db.LessonComment.Add(comment);
                db.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }


        public ResultData<Lesson> Join(string code, int userid)
        {
            try
            {
                var db = new ClassAppContext();

                var lesson = db.Lesson.FirstOrDefault(a => a.LessonCode == code.Trim());

                if (lesson != null)
                {
                    var control = lesson.LessonAccess.Count(b => b.UserID == userid);

                    if (control > 0)
                    {
                        return ResultData<Lesson>.Instance.Fill(false, "Ders Zaten Alınmış");
                    }
                    else
                    {
                        var db2 = new ClassAppContext();


                        db.Entry(lesson).Collection(z => z.LessonAccess).Load();
                        lesson.LessonAccess.Add(new LessonAccess()
                        {
                            User = db.User.Single(a => a.UserID == userid)
                        });

                        db.SaveChanges();



                        return ResultData<Lesson>.Instance.Fill(true, lesson);
                    }
                }
                else
                {
                    return ResultData<Lesson>.Instance.Fill(false, "hata oluştu");
                }

            }
            catch (Exception ex)
            {
                return ResultData<Lesson>.Instance.Fill(false, "hata oluştu" + ex.Message);
            }
        }

        #region helper functions

        private string CodeControl()
        {
            var success = false;
            string code = "";
            while (success == false)
            {
                code = _codeCreate();

                var control = _search(a => a.LessonCode == code);
                if (code != "")
                {
                    if (control.Data.Count < 1)
                    {
                        success = true;
                    }
                }
            }

            return code;
        }

        private string _codeCreate()
        {

            int maxSize = 8;
            char[] chars = new char[62];
            string a;
            a = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            chars = a.ToCharArray();
            int size = maxSize;
            byte[] data = new byte[1];
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            crypto.GetNonZeroBytes(data);
            size = maxSize;
            data = new byte[size];
            crypto.GetNonZeroBytes(data);
            StringBuilder result = new StringBuilder(size);
            foreach (byte b in data)
            { result.Append(chars[b % (chars.Length - 1)]); }
            return result.ToString();

        }

        #endregion

    }
}
