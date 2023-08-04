using AmarisDeveloperTest.Models;
using System.Net;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace AmarisDeveloperTest.DataAccess
{
    public class EmployeeApiClient
    {

        public async Task<EmployeeApiResponse> GetData(string endpoint)
        {
            int maxRetries = 3;
            int retryDelayMilliseconds = 1000; // 1 segundo

            for (int retry = 0; retry < maxRetries; retry++)
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    HttpResponseMessage response = await httpClient.GetAsync("http://dummy.restapiexample.com/api/v1/employees");
                    if (response.IsSuccessStatusCode)
                    {
                        try
                        {
                            // Crea una instancia del cliente HttpClient
                           
                                // Realiza la solicitud HTTP GET y obtiene la respuesta
                                

                                // Asegúrate de que la solicitud fue exitosa antes de continuar
                                response.EnsureSuccessStatusCode();

                                // Lee la respuesta como una cadena JSON
                                string jsonResponse = await response.Content.ReadAsStringAsync();

                                // Deserializa la respuesta JSON en un objeto de modelo
                                EmployeeApiResponse responseModel = Newtonsoft.Json.JsonConvert.DeserializeObject<EmployeeApiResponse>(jsonResponse);

                            return responseModel;
                        }
                        catch (HttpRequestException ex)
                        {
                            // Manejo de errores si la solicitud no fue exitosa
                            Console.WriteLine($"Error al realizar la solicitud HTTP: {ex.Message}");
                        }
                    }

                    if (response.StatusCode == HttpStatusCode.TooManyRequests)
                    {
                        await Task.Delay(retryDelayMilliseconds);
                        retryDelayMilliseconds *= 2; // Incrementar el tiempo de retraso para cada reintent
                    }
                    else
                    {
                        // Manejar otros códigos de error si es necesario
                        response.EnsureSuccessStatusCode();
                    }
                }
            }

            throw new Exception("Número máximo de reintentos alcanzado.");
        }
    }
}
