using TheatricalPlayersRefactoringKata.Domain.Enums;
using TheatricalPlayersRefactoringKata.Domain.Primitives;
using TheatricalPlayersRefactoringKata.Domain.Types.PlayTypes;

namespace TheatricalPlayersRefactoringKata.Infrastructure.Factories
{
    public class PlayTypeFactory
    {
        public static PlayType CreatePlayType(EPlayType playtype)
        {
            return playtype switch
            {
                EPlayType.Comedy => new ComedyType(),
                EPlayType.Tragedy => new TragedyType(),
                EPlayType.Historical => new HistoricalType(),
                _ => throw new ArgumentException("Invalid playtype."),
            };
        }
    }
}
