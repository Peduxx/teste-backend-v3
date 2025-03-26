using System.Globalization;
using System.Xml.Linq;
using System.Xml;
using TheatricalPlayersRefactoringKata.Domain.Entities;
using TheatricalPlayersRefactoringKata.Domain.Abstractions;

namespace TheatricalPlayersRefactoringKata.Domain.Generators
{
    public class XMLOutputGenerator : IOutputGenerator
    {
        private readonly CultureInfo _cultureInfo;

        public XMLOutputGenerator(CultureInfo cultureInfo)
        {
            _cultureInfo = cultureInfo;
        }

        public string Generate(
            string customer,
            IEnumerable<(Play Play, Performance Performance, decimal Amount, decimal Credits)> items,
            decimal totalAmount,
            decimal totalCredits)
        {
            var statement = new XElement("Statement",
                new XAttribute("customer", customer),
                new XElement("Performances",
                    from item in items
                    select new XElement("Performance",
                        new XAttribute("play", item.Play.Name),
                        new XAttribute("audience", item.Performance.Audience),
                        new XElement("Amount", FormatAmount(item.Amount)),
                        new XElement("Credits", item.Credits)
                    )
                ),
                new XElement("TotalAmount", FormatAmount(totalAmount)),
                new XElement("TotalCredits", totalCredits)
            );

            using var stringWriter = new StringWriter();
            using var xmlWriter = XmlWriter.Create(stringWriter, new XmlWriterSettings
            {
                Indent = true,
                OmitXmlDeclaration = false
            });

            statement.WriteTo(xmlWriter);
            xmlWriter.Flush();

            return stringWriter.ToString();
        }

        private string FormatAmount(decimal amount)
        {
            return string.Format(_cultureInfo, "${0:0.00}", amount / 100);
        }
    }
}
