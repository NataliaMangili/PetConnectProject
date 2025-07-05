using MediatR;
using Microsoft.EntityFrameworkCore;
using MyProfileAPI.Application.ExcpetionsCommon;
using MyProfileAPI.Infra.Persistence;

namespace MyProfileAPI.Application.PhotoWidget.Commands;

public class CreatePhotoWidgetHandler : IRequestHandler<CreatePhotoWidgetCommand, Guid>
{
    private readonly MyProfileDbContext _context;

    public CreatePhotoWidgetHandler(MyProfileDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreatePhotoWidgetCommand request, CancellationToken cancellationToken)
    {
        var profile = await _context.Profiles
            .FirstOrDefaultAsync(p => p.OngId == request.OngId, cancellationToken);

        if (profile is null)
            throw new NotFoundException("Perfil da ONG não encontrado.");

        profile.AddPhoto(request.Url, request.Description);
        await _context.SaveChangesAsync(cancellationToken);

        return profile.Id;
    }
}

