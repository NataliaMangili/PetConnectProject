using System;

namespace IdentityCore.Domain.Entities;

public class User : ApplicationUser
{
    public string FullName { get; private set; }

    public User() { }

    public User(string email, string fullName) : base(email)
    {
        SetFullName(fullName);
    }

    public void SetFullName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Nome inválido.");
        FullName = name;
    }
}