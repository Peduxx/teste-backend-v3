using TheatricalPlayersRefactoringKata.Domain.Entities;
using TheatricalPlayersRefactoringKata.Domain.Primitives.Interfaces;

namespace TheatricalPlayersRefactoringKata.Domain.Primitives
{
    public abstract class PlayType : IPlayType
    {
        public virtual decimal CalculateAmount(int audience, Play play)
        {
            return (decimal)Math.Clamp(play.Lines, 1000, 4000) / 10;
        }

        public virtual decimal CalculateCredits(int audience)
        {
            return Math.Max(audience - 30, 0);
        }
    }
}
