using PetSupportDomain.Adoption.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetSupportDomain.Adoption.Interfaces;

public interface IAdoptionCommandRepository
{
    Task InsertAsync(AdoptionPetAggregate aggregate);
}
