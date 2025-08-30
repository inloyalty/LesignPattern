using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Structural.Adapter
{

    public class Employee
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

    }

    // 1. Target Interface 
    internal interface IEmployeeServive
    {
        public List<Employee> GetEmployees();
    }


    // 2. Adaptee( Lagency System)

    public class ThirdPartyEmployeeService
    {


        public List<ThirdPartyEmployeeResponse> GetEmployeeDetails()
        {

            return new List<ThirdPartyEmployeeResponse>()
            {
              new ThirdPartyEmployeeResponse{EmpEmail="PK@test.co,",EmpName="PK", EmpPhone="11111"},
              new ThirdPartyEmployeeResponse{EmpEmail="PK1@test.co,",EmpName="PK2", EmpPhone="11111"},
              new ThirdPartyEmployeeResponse{EmpEmail="PK2@test.co,",EmpName="PK3", EmpPhone="11111"}
            };
        }
        public class ThirdPartyEmployeeResponse
        {
            public string EmpName { get; set; }
            public string EmpEmail { get; set; }
            public string EmpPhone { get; set; }
        }
    }


    // 3. Adaptor 

    public class ThirdParyEmployeeAdaptor : IEmployeeServive
    {
        private readonly ThirdPartyEmployeeService _thirdPartyEmployeeService;

        public ThirdParyEmployeeAdaptor(ThirdPartyEmployeeService thirdPartyEmployeeService)
        {
            _thirdPartyEmployeeService = thirdPartyEmployeeService;
        }
        public List<Employee> GetEmployees()
        {

            // Converting to target return type 
            return _thirdPartyEmployeeService.GetEmployeeDetails()
             .Select(x =>
               new Employee
               {
                   Name = x.EmpName,
                   Email = x.EmpEmail,
                   Phone = x.EmpPhone
               }
              ).ToList();

        }
    }


    public class EmployeeAdaptorClient
    {

        public static void Test()
        {
            var thirdPartyEmployeeService = new ThirdPartyEmployeeService();
            IEmployeeServive employeeServive = new ThirdParyEmployeeAdaptor(thirdPartyEmployeeService);
           var employees= employeeServive.GetEmployees();
            employees?.ForEach(x =>
            {
                Console.WriteLine($"Name : {x.Name}");
            }
            );
     

        }
    }


}
