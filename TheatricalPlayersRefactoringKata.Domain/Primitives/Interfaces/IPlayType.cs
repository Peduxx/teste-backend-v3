using TheatricalPlayersRefactoringKata.Domain.Entities;

namespace TheatricalPlayersRefactoringKata.Domain.Primitives.Interfaces
{
    public interface IPlayType
    {
        decimal CalculateAmount(int audience, Play play);
        decimal CalculateCredits(int audience);
    }
}
