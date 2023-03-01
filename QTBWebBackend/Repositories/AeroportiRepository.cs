using Microsoft.EntityFrameworkCore;
using QTBWebBackend.Interfaces;
using QTBWebBackend.Models;
using QTBWebBackend.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            return _contesto.Aeroporti
                .Select(aeroporto => new AeroportoViewModel
                {
                    Id = aeroporto.Id,
                    Nome = aeroporto.Nome,
                    Denominazione = aeroporto.Denominazione,
                    IdTipoAeroporto = aeroporto.TipoAeroportoNavigation.Id,
                    TipoAeroporto = aeroporto.TipoAeroportoNavigation.Descrizione,
                    Identificativo = aeroporto.Identificativo,
                    Coordinate = aeroporto.Coordinate,
                    Icao = aeroporto.Icao,
                    Iata = aeroporto.Iata,
                    QNH = aeroporto.Qnh,
                    QFU = aeroporto.Qfu,
                    Lunghezza = aeroporto.Lunghezza,
                    Asfalto = aeroporto.Asfalto,
                    Radio = aeroporto.Radio,
                    Indirizzo = aeroporto.Indirizzo,
                    Telefono = aeroporto.Telefono,
                    Email = aeroporto.Email,
                    Web = aeroporto.Web,
                    Note = aeroporto.Note
                }).OrderBy(aeroporto => aeroporto.Nome);
        }

        public AeroportoViewModel? GetAeroporti(long idAeroporto)
        {
            return _contesto.Aeroporti
                .Where(aeroporto => aeroporto.Id == idAeroporto)
                .Select(aeroporto => new AeroportoViewModel
                {
                    Id = aeroporto.Id,
                    Nome = aeroporto.Nome,
                    Denominazione = aeroporto.Denominazione,
                    IdTipoAeroporto = aeroporto.TipoAeroportoNavigation.Id,
                    TipoAeroporto = aeroporto.TipoAeroportoNavigation.Descrizione,
                    Identificativo = aeroporto.Identificativo,
                    Coordinate = aeroporto.Coordinate,
                    Icao = aeroporto.Icao,
                    Iata = aeroporto.Iata,
                    QNH = aeroporto.Qnh,
                    QFU = aeroporto.Qfu,
                    Lunghezza = aeroporto.Lunghezza,
                    Asfalto = aeroporto.Asfalto,
                    Radio = aeroporto.Radio,
                    Indirizzo = aeroporto.Indirizzo,
                    Telefono = aeroporto.Telefono,
                    Email = aeroporto.Email,
                    Web = aeroporto.Web,
                    Note = aeroporto.Note
                })
                .FirstOrDefault();
        }

        public IEnumerable<TipoAeroportoViewModel> GetTipiAeroporti()
        {
            return _contesto.TipiAeroporti
                .Select(tipoAeroporto => new TipoAeroportoViewModel
                {
                    Id = tipoAeroporto.Id,
                    Descrizione = tipoAeroporto.Descrizione

                }).OrderBy(tipoAeroporto => tipoAeroporto.Id);
        }

        public TipoAeroportoViewModel? GetTipiAeroporti(long idTipoAeroporto)
        {
            return _contesto.TipiAeroporti
                .Where(tipoAeroporto => tipoAeroporto.Id == idTipoAeroporto)
                .Select(tipoAeroporto => new TipoAeroportoViewModel
                {
                    Id = tipoAeroporto.Id,
                    Descrizione = tipoAeroporto.Descrizione

                }).FirstOrDefault();
        }

        public async Task<Aeroporti?> PostAeroporto(AeroportoViewModel aeroportoModel)
        {
            var nuovoAeroporto = new Aeroporti();

            nuovoAeroporto.Nome = aeroportoModel.Nome;
            nuovoAeroporto.Denominazione = aeroportoModel.Denominazione;
            nuovoAeroporto.TipoAeroporto = aeroportoModel.IdTipoAeroporto;
            nuovoAeroporto.Identificativo = aeroportoModel.Identificativo;
            nuovoAeroporto.Coordinate = aeroportoModel.Coordinate;
            nuovoAeroporto.Icao = aeroportoModel.Icao;
            nuovoAeroporto.Iata = aeroportoModel.Iata;
            nuovoAeroporto.Qnh = aeroportoModel.QNH;
            nuovoAeroporto.Qfu = aeroportoModel.QFU;
            nuovoAeroporto.Asfalto = aeroportoModel.Asfalto;
            nuovoAeroporto.Lunghezza = aeroportoModel.Lunghezza;
            nuovoAeroporto.Radio = aeroportoModel.Radio;
            nuovoAeroporto.Indirizzo = aeroportoModel.Indirizzo;
            nuovoAeroporto.Telefono = aeroportoModel.Telefono;
            nuovoAeroporto.Email = aeroportoModel.Email;
            nuovoAeroporto.Web = aeroportoModel.Web;
            nuovoAeroporto.Note = aeroportoModel.Note;

            try
            {
                _contesto.Add(nuovoAeroporto);
                if ((await _contesto.SaveChangesAsync()) > 0)
                {
                    return nuovoAeroporto;
                }
                else
                {
                    return null;
                }
            }
            catch (DbUpdateException)
            {
                return null;
            }

        }
    }
}
