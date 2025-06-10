using MediatR;
using PetSupportDomain.Adoption.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetSupportApplication.Adoption.Queries;

public class GetAllAdoptionsQueryHandler : IRequestHandler<GetAllAdoptionsQuery, List<AdoptionPetAggregate>>
{
    private readonly IBaseQueryRepository<AdoptionPetAggregate> _repository;

    public GetAllAdoptionsQueryHandler(IBaseQueryRepository<AdoptionPetAggregate> repository)
    {
        _repository = repository;
    }

    public async Task<List<AdoptionPetAggregate>> Handle(GetAllAdoptionsQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetAllAsync();
    }
}