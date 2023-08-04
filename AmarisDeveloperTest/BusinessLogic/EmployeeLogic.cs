using AmarisDeveloperTest.DataAccess;
using AmarisDeveloperTest.Models;

namespace AmarisDeveloperTest.BusinessLogic
{
    public class EmployeeLogic
    {
        private readonly EmployeeApiClient employeeApiClient;

        public EmployeeLogic(EmployeeApiClient employeeApiClient)
        {
            this.employeeApiClient = employeeApiClient;
        }

        public async Task<EmployeeApiResponse> GetEmployees()
        {
            return await employeeApiClient.GetData("employees");
        }

        // Implementa aquí tu lógica de negocios para calcular el siguiente valor
        public int CalculateNextValue()
        {
            // Tu lógica de cálculo aquí
            return 0;
        }
    }
}
