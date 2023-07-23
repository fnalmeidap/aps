namespace Olimpo;

public class Participante
{
    public Participante(int id, string tokenId, string name, string email, string university, DateTime birthDay)
    {
        Id = id;
        TokenId = tokenId;
        Name = name;
        Email = email;
        University = university;
        BirthDay = birthDay;
    }

    public int Id { get;private set; }
    public string TokenId { get;private set; }
    public string Name { get;private set; }
    public string Email { get;private set; }
    public string University { get;private set; }
    public DateTime BirthDay { get;private set; }
}
