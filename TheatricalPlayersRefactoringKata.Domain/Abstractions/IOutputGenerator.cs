using TheatricalPlayersRefactoringKata.Domain.Entities;

namespace TheatricalPlayersRefactoringKata.Domain.Abstractions
{
    public interface IOutputGenerator
    {
        string Generate(string customer, IEnumerable<(Play Play, Performance Performance, decimal Amount, decimal Credits)> items, decimal totalAmount, decimal totalCredits);
    }
}
