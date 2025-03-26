using TheatricalPlayersRefactoringKata.Domain.Entities;
using TheatricalPlayersRefactoringKata.Domain.Primitives;

namespace TheatricalPlayersRefactoringKata.Domain.Types.PlayTypes
{
    public class TragedyType : PlayType
    {
        override public decimal CalculateAmount(int audience, Play play)
        {
            return base.CalculateAmount(audience, play) + (audience > 30 ? 10 * (audience - 30) : 0);
        }
    }
}
