using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Entity;
using Entity.TimeTable;

namespace Logic.TimeTable
{
    public class TimeTableService : ITimeTableService
    {
        private readonly DataContext _context;
        public TimeTableService(DataContext context)
        {
            _context = context;

        }
        public async Task<ServiceResponse<List<GetTimeTableResponse>>> GetTimeTable(string day, string user, int teacherId)
        {
            ServiceResponse<List<GetTimeTableResponse>> serviceResponse = new ServiceResponse<List<GetTimeTableResponse>>();
            try
            {
                List<GetTimeTableResponse> obj = new List<GetTimeTableResponse>();

                if (user == "Student")
                {
                    var dailySchedules = _context.DailySchedules.Where(x => x.Day == day).ToList();
                    foreach (var item in dailySchedules)
                    {
                        GetTimeTableResponse res = new GetTimeTableResponse
                        {
                            Period = item.Period,
                            SubjectName = _context.Subjectss.FirstOrDefault(x => x.Id == item.SubjectID).Name,
                            TeacherName = _context.Teachers.FirstOrDefault(x => x.Id == item.TeacherID).Name,
                        };
                        obj.Add(res);
                    }
                }
                else if (user == "Teacher")
                {
                    var dailySchedules = _context.DailySchedules.Where(x => x.Day == day && x.TeacherID == teacherId).ToList();
                    foreach (var item in dailySchedules)
                    {
                        GetTimeTableResponse res = new GetTimeTableResponse
                        {
                            Period = item.Period,
                            SubjectName = _context.Subjectss.FirstOrDefault(x => x.Id == item.SubjectID).Name
                        };

                        obj.Add(res);
                    }
                }
                else
                {
                    obj = null;
                }
                serviceResponse.Data = obj;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<UpdateLeaveResponse>> UpdateLeave(int teacherId, string day)
        {
            ServiceResponse<UpdateLeaveResponse> serviceResponse = new ServiceResponse<UpdateLeaveResponse>();
            try
            {
                Attendence obj = _context.Attendences.FirstOrDefault(x => x.TeacherId == teacherId && x.Date == Convert.ToDateTime(day));
                obj.IsPresent = false;

                _context.SaveChanges();

                var availableTeacherList = _context.Attendences.Where(x => x.IsPresent == true && x.Date == Convert.ToDateTime(day)).Select(a => a.Id).ToArray();
                var shuffledArray = Shuffle(availableTeacherList);

                //Assume this day as monday
                List<DailySchedule> daily = _context.DailySchedules.Where(x => x.TeacherID == teacherId && x.Day == "Monday").ToList();

                foreach (var item in daily)
                {
                    item.TeacherID = shuffledArray[0];
                    item.SubjectID = _context.Teachers.FirstOrDefault(x => x.Id == shuffledArray[0]).SubjectID;
                    _context.SaveChanges();
                }

                UpdateLeaveResponse response = new UpdateLeaveResponse
                {
                    AbsentTeacherName = _context.Teachers.FirstOrDefault(x => x.Id == teacherId).Name,
                    AssignedTeacherName = _context.Teachers.FirstOrDefault(x => x.Id == shuffledArray[0]).Name,
                    AssignedPeriodsName = _context.Subjectss.FirstOrDefault(x => x.Id == _context.Teachers.FirstOrDefault(x => x.Id == shuffledArray[0]).SubjectID).Name
                };
                serviceResponse.Data = response;

            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public static T[] Shuffle<T>(T[] array)
        {
            Random _random = new Random();
            int n = array.Length;
            for (int i = 0; i < (n - 1); i++)
            {
                int r = i + _random.Next(n - i);
                T t = array[r];
                array[r] = array[i];
                array[i] = t;
            }
            return array;
        }

    }
}