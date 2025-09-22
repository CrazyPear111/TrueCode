using System.Net.Http;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;
using TrueCode.CurrencyService.Models;
using TrueCode.CurrencyService.RateClient.Models;
using TrueCode.CurrencyService.UseCases.Interfaces;

namespace TrueCode.CurrencyService.RateClient;

public class CbrClient : ICbrClient
{
    private const string windowsEncoding = "windows-1251";
    private readonly Uri _rateUrl = new("http://www.cbr.ru/scripts/XML_daily.asp");
    private readonly HttpClient _httpClient;
    private readonly XmlSerializer _serializer;

    static CbrClient()
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
    }

    public CbrClient()
    {
        _httpClient = new HttpClient();
        _serializer = new XmlSerializer(typeof(CbrResponse));
    }

    public async Task<IEnumerable<CurrencyModel>> GetCurrenciesAsync()
    {
        var response = await GetCbrResponseAsync();

        return response.Valutes.Select(v => new CurrencyModel()
        {
            NumCode = v.NumCode,
            CharCode = v.CharCode,
            Name = v.Name,
            Rate = v.VunitRate,
        });
    }

    private async Task<CbrResponse> GetCbrResponseAsync()
    {
        try
        {
            using var stream = await _httpClient.GetStreamAsync(_rateUrl);
            using var reader = new StreamReader(stream, Encoding.GetEncoding(windowsEncoding));

            var result = (CbrResponse)_serializer.Deserialize(reader)!;
            return result ?? throw new InvalidOperationException("Deserialized response is null.");
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("Can't get currencies from Cbr service.", ex);
        }
    }
}
