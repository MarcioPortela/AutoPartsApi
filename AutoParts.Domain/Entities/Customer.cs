namespace AutoParts.Domain.Entities
{
    public class Customer
    {
        public Guid Id { get; private set; }
        public string FullName { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string Phone { get; private set; } = string.Empty;
        public string Cpf { get; private set; } = string.Empty;
        public string BirthDate { get; private set; } = string.Empty;

        public Customer(string fullName, string email, string phone, string cpf, string birthDate)
        {
            Id = Guid.NewGuid();
            FullName = fullName;
            Email = email;
            Phone = phone;
            Cpf = cpf;
            BirthDate = birthDate;
        }
    }
}
