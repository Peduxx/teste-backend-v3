namespace TheatricalPlayersRefactoringKata.Domain.Entities;

public class Invoice
{
    public Guid Id { get; set; }
    public string Customer { get; set; }
    public List<Performance> Performances { get; set; }
    public List<(Play Play, Performance Performance, decimal Amount, decimal Credits)> Items { get; set; }
    public decimal TotalAmount { get; set; }
    public decimal TotalCredits { get; set; }

    protected Invoice() { }

    public Invoice(string customer, List<Performance> performance)
    {
        Id = Guid.NewGuid();
        Customer = customer;
        Performances = performance;
        Items = new List<(Play Play, Performance Performance, decimal Amount, decimal Credits)>();
        TotalAmount = 0;
        TotalCredits = 0;
    }
}
