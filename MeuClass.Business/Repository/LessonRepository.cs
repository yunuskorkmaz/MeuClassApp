using MeuClass.Business.ResultData;
using MeuClass.Data;

namespace MeuClass.Business.Repository
{
    public class LessonRepository : BaseRepository<Lesson>
    {
        public static LessonRepository Instance = new LessonRepository();

        public ResultData<Lesson> Add(Lesson lesson)
        {
            var result = Insert(lesson);

            if (result.Success == true)
            {
                return ResultData<Lesson>.Instance.Fill(true, result.Data);
            }
            else
            {
                return ResultData<Lesson>.Instance.Fill(false, result.Message);
            }
        }

    }
}
