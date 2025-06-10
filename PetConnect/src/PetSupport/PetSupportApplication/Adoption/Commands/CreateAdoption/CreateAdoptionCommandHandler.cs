using MediatR;
using PetSupportDomain.Adoption.Interfaces;
using PetSupportDomain.Adoption.Models;
using PetSupportDomain.Shared.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetSupportApplication.Adoption.Commands.CreateAdoption;

public class CreateAdoptionCommandHandler : IRequestHandler<CreateAdoptionCommand, string>
{
    private readonly IAdoptionCommandRepository _repository;

    public CreateAdoptionCommandHandler(IAdoptionCommandRepository repository)
    {
        _repository = repository;
    }

    public async Task<string> Handle(CreateAdoptionCommand request, CancellationToken cancellationToken)
    {
        var adoption = new AdoptionPetAggregate(
            id: Guid.NewGuid().ToString()
            //petId: request.PetId,
            //adopterName: request.AdopterName,
            //contactInfo: request.ContactInfo,
            //adoptionDate: DateTime.UtcNow
        );

        await _repository.InsertAsync(adoption);

        return adoption.Id;
    }
}
