using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetSupportApplication.Adoption.Commands.CreateAdoption;

public class CreateAdoptionCommand : IRequest<string>
{
    public string Name { get; set; }
    public string Description { get; set; }
}
