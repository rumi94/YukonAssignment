using System;
using System.Collections.Generic;
using System.Linq;
using Domain;

namespace Entity
{
    public class DataFile
    {
        public static void DataObject(DataContext context)
        {
            if (!context.Values.Any())
            {
                var values = new List<Value>
                {
                    new Value{Id=1,Name="Rumi",Age=26} ,
                    new Value{Id=2,Name="Ashani",Age=33}
                };
                context.Values.AddRange(values);
                context.SaveChanges();
            }
            
            if (!context.DailySchedules.Any())
            {
                var dailySchedules = new List<DailySchedule>
                {
                    new DailySchedule{Id = 1, Day = "Monday",Period = "1st Period",SubjectID = 1,TeacherID = 1},
                    new DailySchedule{Id = 2, Day = "Monday",Period = "2nd Period",SubjectID = 1,TeacherID = 1},
                    new DailySchedule{Id = 3, Day = "Monday",Period = "3rd Period",SubjectID = 2,TeacherID = 2},
                    new DailySchedule{Id = 4, Day = "Monday",Period = "4th Period",SubjectID = 2,TeacherID = 2},
                    new DailySchedule{Id = 5, Day = "Monday",Period = "5th Period",SubjectID = 3,TeacherID = 3},
                    new DailySchedule{Id = 6, Day = "Monday",Period = "6th Period",SubjectID = 3,TeacherID = 3},
                    new DailySchedule{Id = 7, Day = "Monday",Period = "7th Period",SubjectID = 4,TeacherID = 4},
                    new DailySchedule{Id = 8, Day = "Monday",Period = "8th Period",SubjectID = 4,TeacherID = 4},
                    new DailySchedule{Id = 9, Day = "Tuesday",Period = "1st Period",SubjectID = 1,TeacherID = 1},
                    new DailySchedule{Id = 10, Day = "Tuesday",Period = "2nd Period",SubjectID = 1,TeacherID = 1},
                    new DailySchedule{Id = 11, Day = "Tuesday",Period = "3rd Period",SubjectID = 3,TeacherID = 3},
                    new DailySchedule{Id = 12, Day = "Tuesday",Period = "4th Period",SubjectID = 3,TeacherID = 3},
                    new DailySchedule{Id = 13, Day = "Tuesday",Period = "5th Period",SubjectID = 2,TeacherID = 2},
                    new DailySchedule{Id = 14, Day = "Tuesday",Period = "6th Period",SubjectID = 2,TeacherID = 2},
                    new DailySchedule{Id = 15, Day = "Tuesday",Period = "7th Period",SubjectID = 4,TeacherID = 4},
                    new DailySchedule{Id = 16, Day = "Tuesday",Period = "8th Period",SubjectID = 4,TeacherID = 4},
                    new DailySchedule{Id = 17, Day = "Wednesday",Period = "1st Period",SubjectID = 1,TeacherID = 1},
                    new DailySchedule{Id = 18, Day = "Wednesday",Period = "2nd Period",SubjectID = 1,TeacherID = 1},
                    new DailySchedule{Id = 19, Day = "Wednesday",Period = "3rd Period",SubjectID = 2,TeacherID = 2},
                    new DailySchedule{Id = 20, Day = "Wednesday",Period = "4th Period",SubjectID = 2,TeacherID = 2},
                    new DailySchedule{Id = 21, Day = "Wednesday",Period = "5th Period",SubjectID = 3,TeacherID = 3},
                    new DailySchedule{Id = 22, Day = "Wednesday",Period = "6th Period",SubjectID = 3,TeacherID = 3},
                    new DailySchedule{Id = 23, Day = "Wednesday",Period = "7th Period",SubjectID = 4,TeacherID = 4},
                    new DailySchedule{Id = 24, Day = "Wednesday",Period = "8th Period",SubjectID = 4,TeacherID = 4},
                    new DailySchedule{Id = 25, Day = "Thursday",Period = "1st Period",SubjectID = 1,TeacherID = 1},
                    new DailySchedule{Id = 26, Day = "Thursday",Period = "2nd Period",SubjectID = 1,TeacherID = 1},
                    new DailySchedule{Id = 27, Day = "Thursday",Period = "3rd Period",SubjectID = 4,TeacherID = 2},
                    new DailySchedule{Id = 28, Day = "Thursday",Period = "4th Period",SubjectID = 4,TeacherID = 2},
                    new DailySchedule{Id = 29, Day = "Thursday",Period = "5th Period",SubjectID = 3,TeacherID = 3},
                    new DailySchedule{Id = 30, Day = "Thursday",Period = "6th Period",SubjectID = 3,TeacherID = 3},
                    new DailySchedule{Id = 31, Day = "Thursday",Period = "7th Period",SubjectID = 2,TeacherID = 2},
                    new DailySchedule{Id = 32, Day = "Thursday",Period = "8th Period",SubjectID = 2,TeacherID = 2},
                    new DailySchedule{Id = 33, Day = "Friday",Period = "1st Period",SubjectID = 1,TeacherID = 1},
                    new DailySchedule{Id = 34, Day = "Friday",Period = "2nd Period",SubjectID = 1,TeacherID = 1},
                    new DailySchedule{Id = 35, Day = "Friday",Period = "3rd Period",SubjectID = 2,TeacherID = 2},
                    new DailySchedule{Id = 36, Day = "Friday",Period = "4th Period",SubjectID = 2,TeacherID = 2},
                    new DailySchedule{Id = 37, Day = "Friday",Period = "5th Period",SubjectID = 3,TeacherID = 3},
                    new DailySchedule{Id = 38, Day = "Friday",Period = "6th Period",SubjectID = 3,TeacherID = 3},
                    new DailySchedule{Id = 39, Day = "Friday",Period = "7th Period",SubjectID = 4,TeacherID = 4},
                    new DailySchedule{Id = 40, Day = "Friday",Period = "8th Period",SubjectID = 4,TeacherID = 4}
                };
                context.DailySchedules.AddRange(dailySchedules);
                context.SaveChanges();
            }
            if (!context.Attendences.Any())
            {
                var attendences = new List<Attendence>
                {
                    new Attendence{Id=1,Date=Convert.ToDateTime("2020-12-01"),IsPresent=true,TeacherId=1} ,
                    new Attendence{Id=2,Date=Convert.ToDateTime("2020-12-01"),IsPresent=true,TeacherId=2} ,
                    new Attendence{Id=3,Date=Convert.ToDateTime("2020-12-01"),IsPresent=true,TeacherId=3} ,
                    new Attendence{Id=4,Date=Convert.ToDateTime("2020-12-01"),IsPresent=true,TeacherId=4} 
                };
                context.Attendences.AddRange(attendences);
                context.SaveChanges();
            }
            if (!context.Subjectss.Any())
            {
                var subjectss = new List<Subjects>
                {
                    new Subjects{Id=1,Name="Maths"} ,
                    new Subjects{Id=2,Name="Physics"} ,
                    new Subjects{Id=3,Name="Chemestry"} ,
                    new Subjects{Id=4,Name="English"} 
                };
                context.Subjectss.AddRange(subjectss);
                context.SaveChanges();
            }
            if (!context.Teachers.Any())
            {
                var teachers = new List<Teacher>
                {
                    new Teacher{Id=1,Name="Mr. Dammika",SubjectID=1} ,
                    new Teacher{Id=2,Name="Mrs. Galahitiyawa",SubjectID=2} ,
                    new Teacher{Id=3,Name="Mrs. Kalupahana",SubjectID=3} ,
                    new Teacher{Id=4,Name="Mr. Peskuel",SubjectID=4} 
                };
                context.Teachers.AddRange(teachers);
                context.SaveChanges();
            }
        }
    }
}