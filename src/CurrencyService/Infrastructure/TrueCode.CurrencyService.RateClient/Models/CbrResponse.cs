using System.Xml.Serialization;

namespace TrueCode.CurrencyService.RateClient.Models;

[XmlRoot("ValCurs")]
public class CbrResponse
{
    [XmlAttribute("Date")]
    public string Date { get; set; }

    [XmlAttribute("name")]
    public string Name { get; set; }

    [XmlElement("Valute")]
    public List<Valute> Valutes { get; set; }
}
