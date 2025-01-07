
using Dapr.Client;
using MalfunctionRegisterApp.DataTransferObjects;

namespace MalfunctionRegisterApp.Web;

public class MalfunctionRegisterApiClient(DaprClient httpClient)
{
    public async Task<MalfunctionReportDto[]> GetMalfunctionsAsync(int maxItems = 10, CancellationToken cancellationToken = default)
    {
        List<MalfunctionReportDto>? malfunctions = null;

        try
        {
            return await httpClient.InvokeMethodAsync<MalfunctionReportDto[]>(HttpMethod.Get, "apiservicesidecar", "api/MalfunctionRegister");
        }
        catch (Exception ex)
        {
            return malfunctions?.ToArray() ?? [];
        }

        
    }

    public async Task<string> AddMalfunctionsAsync(AddMalfunctionReportDto newReport, CancellationToken cancellationToken = default)
    {
        var errorMessage = "Completed Successfully";
        try
        {
            await httpClient.InvokeMethodAsync<AddMalfunctionReportDto>(HttpMethod.Post, "apiservicesidecar", "api/MalfunctionRegister", newReport);
        }
        catch (Exception ex)
        {
            errorMessage = $"Error adding new report. Error details: {ex.Message}";
        }
        return errorMessage;
    }
}
