namespace IdentityCore.Login.Interfaces;

public interface ILoginService<TDto>
{
    Task LoginAsync(TDto dto);
}

