namespace Optima.Domain.Users.Entities
{
    public class User
    {
        public User(string name, string email)
        {
            Name = string.IsNullOrEmpty(name) ? throw new ArgumentException("Nome não pode ser vazio", nameof(name)) : name;
            Email = string.IsNullOrEmpty(email) ? throw new ArgumentException("Email não pode ser vazio", nameof(email)) : email; ;
        }

        public Guid Id { get; set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
    }
}