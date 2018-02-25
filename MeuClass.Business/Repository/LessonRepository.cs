using MeuClass.Business.ResultData;
using MeuClass.Data;

namespace MeuClass.Business.Repository
{
    public class LessonRepository : BaseRepository<Lesson>
    {
        public static LessonRepository Instance = new LessonRepository();

        public ResultData<Lesson> Add(Lesson lesson)
        {
            using (this)
            {
                var result = _Add(lesson);
                SaveChanges();
                if (result != null)
                {
                    return ResultData<Lesson>.Instance.Fill(true, result);
                }
                else
                {
                    return ResultData<Lesson>.Instance.Fill(false, "hata");
                }
            }
        }

    }
}
