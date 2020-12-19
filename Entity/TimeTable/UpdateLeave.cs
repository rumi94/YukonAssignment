namespace Entity.TimeTable
{
    public class UpdateLeaveRequest
    {

    }
    public class UpdateLeaveResponse
    {
        public string AbsentTeacherName { get; set; }
        public string AssignedTeacherName { get; set; }
        public string AssignedPeriodsName { get; set; }
    }
}