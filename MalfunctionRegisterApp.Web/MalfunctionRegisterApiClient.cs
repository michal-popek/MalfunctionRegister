
using MalfunctionRegisterApp.DataTransferObjects;

namespace MalfunctionRegisterApp.Web;

public class MalfunctionRegisterApiClient(HttpClient httpClient)
{
    public async Task<MalfunctionReportDto[]> GetMalfunctionsAsync(int maxItems = 10, CancellationToken cancellationToken = default)
    {
        List<MalfunctionReportDto>? malfunctions = null;

        try
        {
            var value = await httpClient.GetFromJsonAsync<IEnumerable<MalfunctionReportDto>>("api/MalfunctionRegister", cancellationToken);

            if (value != null)
            {
                foreach (var malfunction in value)
                {
                    if (malfunctions?.Count >= maxItems)
                    {
                        break;
                    }
                    if (malfunction is not null)
                    {
                        malfunctions ??= [];
                        malfunctions.Add(malfunction);
                    }
                }
            }
            return malfunctions?.ToArray() ?? [];
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
            var value = await httpClient.PostAsJsonAsync<AddMalfunctionReportDto>("api/MalfunctionRegister", newReport, cancellationToken);
        }
        catch (Exception ex)
        {
            errorMessage = $"Error adding new report. Error details: {ex.Message}";
        }
        return errorMessage;
    }
}
