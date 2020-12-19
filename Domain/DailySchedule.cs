namespace Domain
{
    public class DailySchedule
    {
        public int Id { get; set; }
        public string Day { get; set; }
        public string Period { get; set; }
        public int SubjectID { get; set; }
        public int TeacherID { get; set; }
    }
}