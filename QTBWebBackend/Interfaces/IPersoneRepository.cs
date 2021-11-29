using QTBWebBackend.ViewModels;
using System.Collections.Generic;

namespace QTBWebBackend.Interfaces
{
    public interface IPersoneRepository
    {
        IEnumerable<PersonaViewModel> GetPersone();
        PersonaViewModel? GetPersona(long idPersona);
    }
}