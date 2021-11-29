using QTBWebBackend.Interfaces;
using QTBWebBackend.Models;
using QTBWebBackend.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace QTBWebBackend.Repositories
{
    public class AeroportiRepository: IAeroportiRepository
    {
        private QTBWebDBContext _contesto;
        public AeroportiRepository(QTBWebDBContext contesto)
        {
            _contesto = contesto;
        }

        public IEnumerable<AeroportoViewModel> GetAeroporti()
        {
            return _contesto.Aeroportis
                .Select(aeroporto => new AeroportoViewModel
                {
                    Id = aeroporto.Id,
                    Nome = aeroporto.Nome,
                    Identificativo = aeroporto.Identificativo,
                    Coordinate = aeroporto.Coordinate
                }).OrderBy(aeroporto => aeroporto.Nome);
        }

        public AeroportoViewModel? GetAeroporto(long idAeroporto)
        {
            return _contesto.Aeroportis
                .Where(aeroporto => aeroporto.Id == idAeroporto)
                .Select(aeroporto => new AeroportoViewModel
                {
                    Id = aeroporto.Id,
                    Nome = aeroporto.Nome,
                    Identificativo = aeroporto.Identificativo,
                    Coordinate = aeroporto.Coordinate
                })
                .FirstOrDefault();
        }
    }
}
