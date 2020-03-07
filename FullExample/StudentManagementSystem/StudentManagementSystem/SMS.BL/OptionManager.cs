using System.Collections.Generic;
using System.Threading.Tasks;
using LazyCache;
using SMS.BL.Domain;
using SMS.BL.Domain.General;
using SMS.Core.Entities;
using SMS.Globalizaiton.Resources;

namespace SMS.BL
{
    public class OptionManager : BaseManagement, IOptionManager
    {
        private readonly IAppCache _cache;


        public OptionManager(IAppCache cache)
        {

            _cache = cache;

        }

        public async Task<List<Option<int, string>>> GetGenders()
        {

            var list = await _cache.GetOrAddAsync("genders", () => Task.Run(loadGenders));

            return list;
        }


        private List<Option<int, string>> loadGenders()
        {

            var list = new List<Option<int, string>>
            {
                new Option<int, string> {Id = 1, Title = Resource.Male},
                new Option<int, string> {Id = 2, Title = Resource.Female}
            };

            return list;
        }
    }
}
