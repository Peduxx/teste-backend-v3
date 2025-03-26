using TheatricalPlayersRefactoringKata.Domain.Enums;

namespace TheatricalPlayersRefactoringKata.Domain.Entities;

public class Play
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Lines { get; set; }
    public EPlayType Type { get; set; }

    protected Play() { }

    public Play(string name, int lines, EPlayType type)
    {
        Id = Guid.NewGuid();
        Name = name;
        Lines = lines;
        Type = type;
    }
}
