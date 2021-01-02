using System;
using System.Collections.Generic;
using KampusStudioProto.Models.ViewModels;

namespace KampusStudioProto.Models.Services.Application
{
    public class ComuneService
    {
        public List<ComuneViewModel> GetComuni()
        {
            var elencoComuni = new List<ComuneViewModel>();
            var rand = new Random();
            for (int i=0; i<20; i++)
            {
                var comune = new ComuneViewModel
                {
                    Comune = $"Margherita di Savoia {i}",
                    Abitanti = (int) (rand.NextDouble() * 10000),
                    Regione = $"Puglia {i}",
                    Provincia = $"Barletta-Andria-Trani {i}",
                    Cap = $"7601{i}",
                    Prefisso =$"088{i}"
                };
                elencoComuni.Add(comune);
            }
            return elencoComuni;
        }
    }
}