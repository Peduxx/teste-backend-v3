using System.Globalization;
using TheatricalPlayersRefactoringKata.Domain.Abstractions;
using TheatricalPlayersRefactoringKata.Domain.Entities;
using TheatricalPlayersRefactoringKata.Domain.Enums;
using TheatricalPlayersRefactoringKata.Infrastructure.Factories;
namespace TheatricalPlayersRefactoringKata.Application.Services;
public class StatementPrinterService : IStatementPrinterService
{
    public string Print(Invoice invoice, Dictionary<string, Play> plays, EOutputType outputType, CultureInfo? cultureInfo = null)
    {
        cultureInfo ??= new CultureInfo("en-US");
        decimal totalOwedAmount = 0;
        decimal totalEarnedCredits = 0;

        var performanceData = new List<(Play Play, Performance Performance, decimal Amount, decimal Credits)>();

        foreach (Performance performance in invoice.Performances)
        {
            Play play = plays[performance.PlayId.ToString()];
            var factory = PlayTypeFactory.CreatePlayType(play.Type);

            decimal owedAmount = factory.CalculateAmount(performance.Audience, play);
            decimal earnedCredits = factory.CalculateCredits(performance.Audience);

            totalOwedAmount += owedAmount;
            totalEarnedCredits += earnedCredits;

            performanceData.Add((play, performance, owedAmount, earnedCredits));
        }
        var formatter = OutputTypeFactory.CreateOutputType(outputType, cultureInfo);

        return formatter.Generate(
            invoice.Customer,
            performanceData,
            totalOwedAmount,
            totalEarnedCredits);
    }
}