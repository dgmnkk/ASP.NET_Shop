using BusinessLogic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
	public interface IAdvertsService
	{
		IEnumerable<AdvertisementDto> GetAll();
        IEnumerable<AdvertisementDto> GetByUser(string id);
        IEnumerable<AdvertisementDto> Get(IEnumerable<int> ids);
        AdvertisementDto? Get(int id);
		IEnumerable<CategoryDto> GetAllCategories();
		IEnumerable<ConditionDto> GetAllConditions();
		void Create(AdvertisementDto advertisement);
		void Edit(AdvertisementDto advertisement);
		void Delete(int id);
	}
}
