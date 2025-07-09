using MediatR;
using Microsoft.EntityFrameworkCore;
using MyProfileAPI.Application.ExcpetionsCommon;
using MyProfileAPI.Application.PhotosWidget.DTOs;
using MyProfileAPI.Infra.Persistence;

namespace MyProfileAPI.Application.PhotosWidget.Querys;

public class GetPhotosByOngHandler : IRequestHandler<GetPhotosByOngQuery, IEnumerable<PhotoWidgetDto>>
{
    private readonly MyProfileDbContext _context;

    public GetPhotosByOngHandler(MyProfileDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<PhotoWidgetDto>> Handle(GetPhotosByOngQuery request, CancellationToken cancellationToken)
    {
        var profile = await _context.Profiles
            .FirstOrDefaultAsync(p => p.OngId == request.OngId, cancellationToken);

        if (profile is null)
            throw new NotFoundException("Perfil da ONG não encontrado.");

        var photos = await _context.Entry(profile)
            .Collection(p => p.Photos)
            .Query()
            .ToListAsync(cancellationToken);

        return photos.Select(p => new PhotoWidgetDto(p.Id, p.Url, p.Description, p.CreatedAt));
    }
}