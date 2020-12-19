using System;

namespace Domain
{
    public class Attendence
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public bool IsPresent { get; set; }
        public DateTime Date{ get; set; }
    }
}