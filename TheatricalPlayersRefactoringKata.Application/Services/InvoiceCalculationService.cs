using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheatricalPlayersRefactoringKata.Domain.Entities;
using TheatricalPlayersRefactoringKata.Domain.Enums;
using TheatricalPlayersRefactoringKata.Infrastructure.Factories;

namespace TheatricalPlayersRefactoringKata.Application.Services;

public class InvoiceCalculationService
{
    public async Task<Invoice> CalculateInvoice(string customer, List<Performance> performances, List<Play> plays)
    {
        var items = new List<(Play Play, Performance Performance, decimal Amount, decimal Credits)>();
        decimal totalAmount = 0;
        decimal totalCredits = 0;

        foreach (var performance in performances)
        {
            var play = plays.FirstOrDefault(p => p.Id == performance.PlayId)
                ?? throw new ArgumentException($"Play with ID {performance.PlayId} not found.");

            var factory = PlayTypeFactory.CreatePlayType(play.Type);
            var amount = factory.CalculateAmount(performance.Audience, play);
            var credits = factory.CalculateCredits(performance.Audience);

            totalAmount += amount;
            totalCredits += credits;

            items.Add((play, performance, amount, credits));
        }

        return new Invoice(customer, performances)
        {
            Items = items,
            TotalAmount = totalAmount,
            TotalCredits = totalCredits
        };
    }
}