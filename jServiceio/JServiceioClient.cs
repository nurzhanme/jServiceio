using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text.Json;
using jServiceio.Responses;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace jServiceio;

public class JServiceioClient
{
    private readonly HttpClient _httpClient;

    [ActivatorUtilitiesConstructor]
    public JServiceioClient(IOptions<JServiceioOptions> options, HttpClient httpClient) : this(options.Value, httpClient)
    {
    }

    public JServiceioClient(JServiceioOptions options, HttpClient? httpClient = null)
    {
        _httpClient = httpClient ?? new HttpClient();
        _httpClient.BaseAddress = new Uri(string.IsNullOrWhiteSpace(options.ApiBaseAddress) ? "https://jservice.io/api/" : options.ApiBaseAddress);
        _httpClient.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue(MediaTypeNames.Application.Json));
    }

    /// <summary>
    /// Returns random question
    /// </summary>
    /// <param name="count">amount of clues to return, limited to 100 at a time</param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public async Task<List<QuestionResponse>> Random(int count = 1)
    {
        if (count > 100)
        {
            throw new ArgumentOutOfRangeException(nameof(count), "limited to 100 at a time");
        }
        if (count < 1)
        {
            count = 1;
        }

        var response = await _httpClient.GetAsync($"random?count={count}").ConfigureAwait(false);

        response.EnsureSuccessStatusCode();
        var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        var data = JsonSerializer.Deserialize<List<QuestionResponse>>(responseBody);

        return data;
    }


    /// <summary>
    /// Presents random final jeopardy question. Note: all final jeopardy questions have null value
    /// </summary>
    /// <param name="count">amount of clues to return, limited to 100 at a time</param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public async Task<List<QuestionResponse>> Final(int count = 1)
    {
        if (count > 100)
        {
            throw new ArgumentOutOfRangeException(nameof(count), "limited to 100 at a time");
        }
        if (count < 1)
        {
            count = 1;
        }

        var response = await _httpClient.GetAsync($"final?count={count}").ConfigureAwait(false);

        response.EnsureSuccessStatusCode();
        var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        var data = JsonSerializer.Deserialize<List<QuestionResponse>>(responseBody);

        return data;
    }
}