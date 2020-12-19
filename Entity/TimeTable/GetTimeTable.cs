namespace Entity.TimeTable
{
    public class GetTimeTableRequest
    {

    }
    public class GetTimeTableResponse
    {
        public string Period { get; set; }
        public string SubjectName { get; set; }
        public string TeacherName { get; set; }
    }
}