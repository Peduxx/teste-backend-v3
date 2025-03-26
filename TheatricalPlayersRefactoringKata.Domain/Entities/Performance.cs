namespace TheatricalPlayersRefactoringKata.Domain.Entities;

public class Performance
{
    public Guid Id { get; set; }
    public Guid PlayId { get; set; }
    public int Audience { get; set; }

    protected Performance() { }

    public Performance(Guid playID, int audience)
    {
        Id = Guid.NewGuid();
        PlayId = playID;
        Audience = audience;
    }
}
