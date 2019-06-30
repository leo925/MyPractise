using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCorePractise.Services
{
    public interface IConferenceService
    {
        Task<IEnumerable<ConferenceModel>> GetAll();

        Task<ConferenceModel> GetById(int Id);

        Task<StatisticsModel> GetStatistics();

        Task Add(ConferenceModel model);
    }
}
