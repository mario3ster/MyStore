namespace MyStore.Domain.Nomenclatures
{
    public class User : NomenclatureEntity
    {

        public string Email { get; set; }
        public virtual string Username { get; set; }
        public virtual string Password { get; set; } 
        public virtual string Role { get; set; }   
    }
}