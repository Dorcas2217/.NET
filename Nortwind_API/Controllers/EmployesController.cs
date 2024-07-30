using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nortwind_API.Entities;
using Nortwind_API.Models;
using Nortwind_API.Repository;
using Nortwind_API.UnitsOfWork;

namespace Nortwind_API.Controllers
{
    [ApiController]
    [Route("/api/controller")]
    public class EmployesController : ControllerBase
    {
        private readonly NorthwindContext _dbContext;
        private readonly UnitOfWorkSQL _unitOfWorkSQL;

        public EmployesController()
        {
            this._dbContext = new NorthwindContext();
            this._unitOfWorkSQL = new UnitOfWorkSQL(_dbContext);

        }

        [HttpGet("getAllEmployes")]
        public IEnumerable<EmployeDTO> GetAllEmployes()
        {
            IList<Employee> list = _unitOfWorkSQL._employesRepository.GetAll();
            return   list.Select(e => EmployeeToDTO(e)).ToList();
           
        }

        
        [HttpPost("addEmployee")]
        public bool AddEmployee([FromBody] EmployeDTO employes)
        {
            Employee newEmployee = DTOToEmployee(employes);
           bool result =  this._unitOfWorkSQL.employesRepository.Save(newEmployee, emp => emp.LastName.Equals(newEmployee.LastName));
            if(result) result = true;
            return false;
        }

        [HttpGet("getOne/id")]
        public ActionResult<EmployeDTO> getOne(int id)
        {
            Employee employeFounded = this._unitOfWorkSQL.employesRepository.GetById(id); 
            if(employeFounded == null)
            {
                return NotFound();
            }
            EmployeDTO emARenvoyer = EmployeeToDTO(employeFounded);
            return emARenvoyer;
            
        }

        // POST: HomeController/Create
        [HttpPost("updateEmploye")]
        [ValidateAntiForgeryToken]
        public bool UpdateEMploye([FromBody] EmployeDTO employes)
        {
            Employee empl = DTOToEmployee(employes);
            bool result = this._unitOfWorkSQL.employesRepository.Save(empl);
            if (result) result = true;
            return false;
        }


        // GET: HomeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        private static EmployeDTO EmployeeToDTO(Employee emp) =>
            new EmployeDTO
            {
                EmployeeId = emp.EmployeeId,
                LastName = emp.LastName,
                FirstName = emp.FirstName,
                BirthDate = emp.BirthDate,
                HireDate = emp.HireDate,
                Title = emp.Title,
                TitleOfCourtesy = emp.TitleOfCourtesy

            };

        private static Employee DTOToEmployee(EmployeDTO emp) =>
            new Employee
            {
                EmployeeId = emp.EmployeeId,
                LastName = emp.LastName,
                FirstName = emp.FirstName,
                BirthDate = emp.BirthDate,
                HireDate = emp.HireDate,
                Title = emp.Title,
                TitleOfCourtesy = emp.TitleOfCourtesy
            };


    }
}
