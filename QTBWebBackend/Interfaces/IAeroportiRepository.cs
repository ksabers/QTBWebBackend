﻿using QTBWebBackend.Models;
using QTBWebBackend.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QTBWebBackend.Interfaces
{
    public interface IAeroportiRepository
    {
        IEnumerable<AeroportoViewModel> GetAeroporti();
        AeroportoViewModel? GetAeroporto(long idAeroporto);

        Task<Aeroporti?> PostAeroporto(AeroportoViewModel aeroporto);
    }
}