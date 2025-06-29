using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using System;

namespace IdentityCore.Domain.Entities;

public abstract class ApplicationUser : IdentityUser<Guid>
{
    public DateTime CreatedAt { get; protected set; }

    protected ApplicationUser()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
    }

    protected ApplicationUser(string email) : this()
    {
        SetEmail(email);
    }

    public void SetEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
            throw new ArgumentException("E-mail inválido.");

        Email = email.ToLower();
        UserName = Email;
        NormalizedEmail = email.ToUpperInvariant();
        NormalizedUserName = UserName.ToUpperInvariant();
    }

    public void SetPasswordHash(string hash)
    {
        if (string.IsNullOrWhiteSpace(hash))
            throw new ArgumentException("Hash de senha inválido.");
        PasswordHash = hash;
    }
}
