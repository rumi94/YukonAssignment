using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Entity.TimeTable;

namespace Logic.TimeTable
{
    public interface ITimeTableService
    {
        Task<ServiceResponse<List<GetTimeTableResponse>>> GetTimeTable(string day, string user, int teacherId);
        Task<ServiceResponse<UpdateLeaveResponse>> UpdateLeave(int teacherId, string day);
    }
}