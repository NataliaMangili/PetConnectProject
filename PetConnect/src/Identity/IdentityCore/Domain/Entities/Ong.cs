using System;

namespace IdentityCore.Domain.Entities;

public class Ong : ApplicationUser
{
    public string OrganizationName { get; private set; }
    public string CNPJ { get; private set; }

    public Ong() { }

    public Ong(string email, string organizationName, string cnpj) : base(email)
    {
        SetOrganization(organizationName);
        SetCnpj(cnpj);
    }

    public void SetOrganization(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Nome da ONG inválido.");
        OrganizationName = name;
    }

    public void SetCnpj(string cnpj)
    {
        if (string.IsNullOrWhiteSpace(cnpj))
            throw new ArgumentException("CNPJ inválido.");
        CNPJ = cnpj;
    }
}
