namespace Optima.Domain.Users.Entities
{
    public class User
    {
        public User(string name, string email)
        {
            Id = Guid.NewGuid();
            SetName(name);
            SetEmail(email);
            CreatedAt = DateTime.UtcNow;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool IsActive { get; private set; } = true;

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Nome não pode ser vazio", nameof(name));
            
            if (name.Length < 2)
                throw new ArgumentException("Nome deve ter pelo menos 2 caracteres", nameof(name));
            
            Name = name.Trim();
        }

        public void SetEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email não pode ser vazio", nameof(email));
            
            if (!email.Contains("@"))
                throw new ArgumentException("Email deve conter @", nameof(email));
            
            Email = email.Trim().ToLower();
        }

        public void Deactivate()
        {
            IsActive = false;
        }

        public void Activate()
        {
            IsActive = true;
        }
    }
}