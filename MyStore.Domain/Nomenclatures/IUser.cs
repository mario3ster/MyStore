namespace MyStore.Domain.Nomenclatures
{
    public interface IUser
    {
        int Id { get; set; }
        string Name { get; set; }
        string Email { get; set; }
        string Username { get; set; }
        string Password { get; set; }
    }
}