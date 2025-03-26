using System.Globalization;
using TheatricalPlayersRefactoringKata.Domain.Abstractions;
using TheatricalPlayersRefactoringKata.Domain.Entities;
using System.Text;

namespace TheatricalPlayersRefactoringKata.Domain.Generators
{
    public class TextOutputGenerator : IOutputGenerator
    {
        private readonly CultureInfo _cultureInfo;

        public TextOutputGenerator(CultureInfo cultureInfo)
        {
            _cultureInfo = cultureInfo;
        }

        public string Generate(
            string customer,
            IEnumerable<(Play Play, Performance Performance, decimal Amount, decimal Credits)> items,
            decimal totalAmount,
            decimal totalCredits)
        {
            StringBuilder result = new();

            result.AppendLine($"Statement for {customer}");

            foreach (var item in items)
            {
                result.AppendLine($"  {item.Play.Name}: {FormatAmount(item.Amount)} ({item.Performance.Audience} seats)");
            }

            result.AppendLine($"Amount owed is {FormatAmount(totalAmount)}");
            result.AppendLine($"You earned {totalCredits} credits");

            return result.ToString();
        }

        private string FormatAmount(decimal amount)
        {
            return string.Format(_cultureInfo, "${0:0.00}", amount / 100);
        }
    }
}
