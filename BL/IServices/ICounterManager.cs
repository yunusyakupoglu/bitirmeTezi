using Common;
using DTOs;
using OL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.IServices
{
    public interface ICounterManager : IService<CounterCreateDto, CounterUpdateDto, CounterListDto, ObjCounter>
    {
        Task<IResponse<List<CounterListDto>>> GetActiveAsync();
    }
}
