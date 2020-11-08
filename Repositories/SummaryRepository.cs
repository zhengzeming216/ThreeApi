using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThreeApi.Models;
using ThreeApi.Repositories;

namespace ThreeApi.Repositories
{
    public class SummaryRepository : ISummaryRepository
    {
        private readonly IDepartmentRepository departmentRepository;

        public SummaryRepository(IDepartmentRepository departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }

        public Task<CompanySummary> GetCompanySummary()
        {
            return Task.Run(() =>
            {
                var all = departmentRepository.GetAll().Result;
                return new CompanySummary()
                {
                    EmplyeeCount = all.Sum(m => m.EmployeeCount),
                    AverageDepartmentEmployeeCount = (int)all.Average(m => m.EmployeeCount)
                };
            });
        }
    }
}
