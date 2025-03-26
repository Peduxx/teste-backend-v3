using System.Globalization;
using TheatricalPlayersRefactoringKata.Domain.Abstractions;
using TheatricalPlayersRefactoringKata.Domain.Enums;
using TheatricalPlayersRefactoringKata.Domain.Generators;

namespace TheatricalPlayersRefactoringKata.Infrastructure.Factories
{
    public class OutputTypeFactory
    {
        public static IOutputGenerator CreateOutputType(EOutputType outputType, CultureInfo cultureInfo)
        {
            return outputType switch
            {
                EOutputType.Text => new TextOutputGenerator(cultureInfo),
                EOutputType.XML => new XMLOutputGenerator(cultureInfo),
                _ => throw new ArgumentException("Invalid output type."),
            };
        }
    }
}
