using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using ATIP.Core.DTOs.Children;
using ATIP.Core.Entities;
using ATIP.Core.Enums;

namespace ATIP.Management.Services;

public class AtipApiClient : IAtipApiClient
{
    private readonly HttpClient _httpClient;

    public AtipApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Child> CreateChildAsync(
        CreateChildRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync(
            "api/children",
            request);

        response.EnsureSuccessStatusCode();

        var child = await response.Content
            .ReadFromJsonAsync<Child>();

        return child
            ?? throw new JsonException(
                "The API returned an empty Child response.");
    }

    public async Task<IReadOnlyList<Child>> GetChildrenAsync(
        ChildStatus? status = null)
    {
        var endpoint = "api/children";

        if (status is not null)
        {
            endpoint += $"?status={Uri.EscapeDataString(
                status.Value.ToString())}";
        }

        var children = await _httpClient
            .GetFromJsonAsync<List<Child>>(endpoint);

        return children ?? [];
    }

    public async Task<Child?> GetChildAsync(int childId)
    {
        var response = await _httpClient.GetAsync(
            $"api/children/{childId}");

        if (response.StatusCode == HttpStatusCode.NotFound)
        {
            return null;
        }

        response.EnsureSuccessStatusCode();

        return await response.Content
            .ReadFromJsonAsync<Child>();
    }

    public async Task<Child?> UpdateChildAsync(
        int childId,
        UpdateChildRequest request)
    {
        using var httpRequest = new HttpRequestMessage(
            HttpMethod.Patch,
            $"api/children/{childId}")
        {
            Content = JsonContent.Create(request)
        };

        var response = await _httpClient.SendAsync(
            httpRequest);

        if (response.StatusCode == HttpStatusCode.NotFound)
        {
            return null;
        }

        response.EnsureSuccessStatusCode();

        return await response.Content
            .ReadFromJsonAsync<Child>();
    }

    public async Task<bool> ArchiveChildAsync(int childId)
    {
        var response = await _httpClient.DeleteAsync(
            $"api/children/{childId}");

        if (response.StatusCode == HttpStatusCode.NotFound)
        {
            return false;
        }

        response.EnsureSuccessStatusCode();

        return true;
    }
}
