using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThreeApi.Models;

namespace ThreeApi.Repositories
{
    public interface ISummaryRepository
    {
        Task<CompanySummary> GetCompanySummary();
    }
}
