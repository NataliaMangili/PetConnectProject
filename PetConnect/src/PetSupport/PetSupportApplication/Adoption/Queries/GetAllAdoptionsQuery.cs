using MediatR;
using PetSupportDomain.Adoption.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetSupportApplication.Adoption.Queries;

public class GetAllAdoptionsQuery : IRequest<List<AdoptionPetAggregate>>
{
}
