using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Piast.Web.Core.Models;
using RestEase;

namespace Piast.Web.Core.Services.Interfaces
{
    [SerializationMethods(Query = QuerySerializationMethod.Serialized)]
    public interface IAdvertisementService
    {
        [Get("Advertisements/{id}")]
        Task<AdvertisementModel> FindById([Path]Guid id);
        [Get("Advertisements")]
        Task<PageModel<AdvertisementModel>> GetPage([Query]int page,[Query]int pageCount);
        [Post("Advertisements")]
        Task Add([Body]AdvertisementModel model);
    }
}