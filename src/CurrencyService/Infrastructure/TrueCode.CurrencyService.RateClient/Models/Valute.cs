using System.Xml.Serialization;

namespace TrueCode.CurrencyService.RateClient.Models;

public class Valute
{
    [XmlAttribute("ID")]
    public string Id { get; set; }

    [XmlElement("NumCode")]
    public int NumCode { get; set; }

    [XmlElement("CharCode")]
    public string CharCode { get; set; }

    [XmlElement("Nominal")]
    public int Nominal { get; set; }

    [XmlElement("Name")]
    public string Name { get; set; }

    [XmlElement("Value")]
    public string ValueRaw { get; set; }

    [XmlIgnore]
    public decimal Value => decimal.Parse(
        ValueRaw.Replace(',', '.'),
        System.Globalization.CultureInfo.InvariantCulture);

    [XmlElement("VunitRate")]
    public string VunitRateRaw { get; set; }

    [XmlIgnore]
    public decimal VunitRate => decimal.Parse(
        VunitRateRaw.Replace(',', '.'),
        System.Globalization.CultureInfo.InvariantCulture);
}
