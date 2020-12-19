using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Entity;
using Entity.Values;

namespace Logic
{
    public class ValuesService : IValuesService
    {
        private readonly DataContext _context;
        public ValuesService(DataContext context)
        {
            _context = context;

        }

        public async Task<ServiceResponse<List<GetValuesResponse>>> GetAllValues()
        {
            ServiceResponse<List<GetValuesResponse>> serviceResponse = new ServiceResponse<List<GetValuesResponse>>();
            try
            {
                List<Value> obj = _context.Values.ToList();

                List<GetValuesResponse> getValues = new List<GetValuesResponse>();

                foreach (var item in obj)
                {
                    GetValuesResponse valuesResponse = new GetValuesResponse
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Age = item.Age
                    };
                    getValues.Add(valuesResponse);
                }

                serviceResponse.Data = getValues;

            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetValuesResponse>> GetSingle(int id)
        {
            ServiceResponse<GetValuesResponse> serviceResponse = new ServiceResponse<GetValuesResponse>();
            try
            {
                Value obj = _context.Values.FirstOrDefault(a => a.Id == id);

                GetValuesResponse valuesResponse = new GetValuesResponse
                {
                    Id = obj.Id,
                    Name = obj.Name,
                    Age = obj.Age
                };

                serviceResponse.Data = valuesResponse;

            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<EnterValuesResponse>> EnterValue(EnterValuesRequest req)
        {
            ServiceResponse<EnterValuesResponse> serviceResponse = new ServiceResponse<EnterValuesResponse>();

            try
            {
                Random rnd = new Random();
                Value obj = new Value();

                obj.Id = rnd.Next();
                obj.Name = req.Name;
                obj.Age = req.Age;

                _context.Values.Add(obj);
                _context.SaveChanges();

                Value res = _context.Values.FirstOrDefault(a => a.Id == obj.Id);

                EnterValuesResponse valuesResponse = new EnterValuesResponse
                {
                    Id = res.Id,
                    Name = res.Name,
                    Age = res.Age
                };

                serviceResponse.Data = valuesResponse;

            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }
        public async Task<ServiceResponse<UpdateValuesResponse>> UpdateValue(UpdateValuesRequest req)
        {
            ServiceResponse<UpdateValuesResponse> serviceResponse = new ServiceResponse<UpdateValuesResponse>();

            try
            {
                Value obj = _context.Values.FirstOrDefault(a => a.Id == req.Id);
                obj.Name = req.Name;
                obj.Age = req.Age != 0 ? req.Age : obj.Age;

                _context.SaveChanges();

                Value res = _context.Values.FirstOrDefault(a => a.Id == req.Id);
                UpdateValuesResponse valuesResponse = new UpdateValuesResponse
                {
                    Id = res.Id,
                    Name = res.Name,
                    Age = res.Age
                };

                serviceResponse.Data = valuesResponse;

            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetValuesResponse>>> DeleteValue(int id)
        {
            ServiceResponse<List<GetValuesResponse>> serviceResponse = new ServiceResponse<List<GetValuesResponse>>();

            try
            {
                Value obj = _context.Values.FirstOrDefault(a => a.Id == id);
                _context.Values.Remove(obj);
                _context.SaveChanges();

                List<Value> objList = _context.Values.ToList();
                List<GetValuesResponse> getValues = new List<GetValuesResponse>();

                foreach (var item in objList)
                {
                    GetValuesResponse valuesResponse = new GetValuesResponse
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Age = item.Age
                    };
                    getValues.Add(valuesResponse);
                }

                serviceResponse.Data = getValues;

            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }
    }
}