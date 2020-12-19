using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Entity.Values;

namespace Logic
{
    public interface IValuesService
    {
        Task<ServiceResponse<List<GetValuesResponse>>> GetAllValues();
        Task<ServiceResponse<GetValuesResponse>> GetSingle(int id);
        Task<ServiceResponse<UpdateValuesResponse>> UpdateValue(UpdateValuesRequest req);
        Task<ServiceResponse<EnterValuesResponse>> EnterValue(EnterValuesRequest req);
        Task<ServiceResponse<List<GetValuesResponse>>> DeleteValue(int id);
    }
}