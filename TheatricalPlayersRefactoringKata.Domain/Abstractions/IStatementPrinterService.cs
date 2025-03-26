using System.Globalization;
using TheatricalPlayersRefactoringKata.Domain.Entities;
using TheatricalPlayersRefactoringKata.Domain.Enums;

namespace TheatricalPlayersRefactoringKata.Domain.Abstractions
{
    public interface IStatementPrinterService
    {
        string Print(Invoice invoice, Dictionary<string, Play> plays, EOutputType outputType, CultureInfo cultureInfo);
    }
}
