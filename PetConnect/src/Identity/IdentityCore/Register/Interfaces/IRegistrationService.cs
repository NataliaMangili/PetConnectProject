namespace IdentityCore.Register.Interfaces;

public interface IRegistrationService<TDto>
{
    Task RegisterAsync(TDto dto);
}
