namespace MyProfileAPI.Application.ExcpetionsCommon;

public class NotFoundException : Exception
{
    public NotFoundException(string message) : base(message)
    {
    }

    public NotFoundException(string entityName, object key)
        : base($"'{entityName}' com chave '{key}' não foi encontrado.")
    {
    }
}