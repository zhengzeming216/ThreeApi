using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThreeApi.Models;

namespace ThreeApi.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly List<Department> _departments = new List<Department>();

        public DepartmentRepository()
        {
            _departments.Add(new Department()
            {
                Id = 1,
                Name = "HR",
                EmployeeCount = 16,
                Location = "beijing"
            });
            _departments.Add(new Department()
            {
                Id = 2,
                Name = "RD",
                EmployeeCount = 52,
                Location = "shanhai"
            });
            _departments.Add(new Department()
            {
                Id = 3,
                Name = "Sales",
                EmployeeCount = 200,
                Location = "china"
            });
        }

        public Task<Department> Add(Department department)
        {
            department.Id = _departments.Max(m => m.Id) + 1;
            _departments.Add(department);
            return Task.Run(() => department);
        }

        public Task<IEnumerable<Department>> GetAll()
        {
            return Task.Run(() => _departments.AsEnumerable());
        }

        public Task<Department> GetById(int id)
        {
            return Task.Run(() => _departments.FirstOrDefault(m => m.Id == id));
        }
    }
}
