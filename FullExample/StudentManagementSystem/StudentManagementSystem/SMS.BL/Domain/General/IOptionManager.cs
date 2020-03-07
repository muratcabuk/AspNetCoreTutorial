using System.Collections.Generic;
using System.Threading.Tasks;
using SMS.Core.Entities;
using SMS.Core.Interfaces;

namespace SMS.BL.Domain.General
{
    public interface IOptionManager:IManager
    {
        Task<List<Option<int,string>>> GetGenders();
    }
}