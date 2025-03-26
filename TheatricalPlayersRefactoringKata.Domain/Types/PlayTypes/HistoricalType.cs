using TheatricalPlayersRefactoringKata.Domain.Entities;
using TheatricalPlayersRefactoringKata.Domain.Primitives;

namespace TheatricalPlayersRefactoringKata.Domain.Types.PlayTypes
{
    public class HistoricalType : PlayType
    {
        override public decimal CalculateAmount(int audience, Play play)
        {
            decimal comedyAmount = new ComedyType().CalculateAmount(audience, play);
            decimal tragedyAmount = new TragedyType().CalculateAmount(audience, play);
            return comedyAmount + tragedyAmount;
        }
    }
}
