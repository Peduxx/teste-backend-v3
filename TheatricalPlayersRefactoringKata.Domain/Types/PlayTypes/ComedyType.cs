using TheatricalPlayersRefactoringKata.Domain.Entities;
using TheatricalPlayersRefactoringKata.Domain.Primitives;

namespace TheatricalPlayersRefactoringKata.Domain.Types.PlayTypes
{
    public class ComedyType : PlayType
    {
        public override decimal CalculateAmount(int audience, Play play)
        {
            return base.CalculateAmount(audience, play) + (audience > 20 ? 100 + 5 * (audience - 20) : 0) + 3 * audience;
        }

        public override decimal CalculateCredits(int audience)
        {
            return base.CalculateCredits(audience) + Math.Floor((decimal)audience / 5);
        }
    }
}
