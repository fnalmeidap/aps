namespace NetApi;

public class Participante
{
    public required int Id { get; set; }
    public required string TokenId { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string University { get; set; }
    public required DateTime BirthDay { get; set; }
}
