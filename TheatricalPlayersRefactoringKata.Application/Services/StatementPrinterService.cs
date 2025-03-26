using System.Collections.Generic;
using System.Globalization;
using TheatricalPlayersRefactoringKata.Domain.Abstractions;
using TheatricalPlayersRefactoringKata.Domain.Entities;
using TheatricalPlayersRefactoringKata.Domain.Enums;
using TheatricalPlayersRefactoringKata.Infrastructure.Factories;

namespace TheatricalPlayersRefactoringKata.Application.Services;

public class StatementPrinterService : IStatementPrinterService
{
    private readonly InvoiceCalculationService _invoiceCalculationService;

    public StatementPrinterService()
    {
        _invoiceCalculationService = new InvoiceCalculationService();
    }

    public async Task<string> Print(Invoice invoice, Dictionary<string, Play> plays, EOutputType outputType)
    {
        var cultureInfo = new CultureInfo("pt-BR");
        var formatter = OutputTypeFactory.CreateOutputType(outputType, cultureInfo);

        return formatter.Generate(
            invoice.Customer,
            invoice.Items,
            invoice.TotalAmount,
            invoice.TotalCredits);
    }
}