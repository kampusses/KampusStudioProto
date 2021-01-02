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
            for (int i=1; i<=20; i++)
            {
                var comune = new ComuneViewModel
                {
                    CodiceCatastale = $"E94{i}",
                    NomeComune = $"Margherita di Savoia {i}",
                    Abitanti = (int) (rand.NextDouble() * 10000),
                    Regione = new RegioneViewModel
                    {
                        CodiceRegione = 20,
                        NomeRegione = $"Puglia{i}",
                        RipartizioneGeografica = i,
                        CodiceCapoluogo = $"E45{i}"
                    },
                    Provincia = new ProvinciaViewModel
                    {
                        CodiceProvincia = i,
                        CodiceRegione = 125 + i,
                        NomeProvincia = $"Barletta-Andria-Trani {i}",
                        SiglaProvincia = "BT"
                    },
                    Cap = $"7601{i}",
                    Prefisso =$"088{i}",
                    CodiceIstat = "125458"
                };
                elencoComuni.Add(comune);
            }
            return elencoComuni;
        }

        public ComuneViewModel GetComune(string id)
        {
            var comune = new ComuneViewModel
            {
                CodiceCatastale = "E946",
                NomeComune = "Margherita di Savoia",
                Abitanti = 11000,
                Regione = new RegioneViewModel
                {
                    CodiceRegione = 20,
                    NomeRegione = "Puglia",
                    RipartizioneGeografica = 4,
                    CodiceCapoluogo = "E456"
                },
                
                Provincia = new ProvinciaViewModel
                {
                    CodiceProvincia = 12,
                    CodiceRegione = 20,
                    NomeProvincia = "Barletta-Andria-Trani",
                    SiglaProvincia = "BT"
                },
                Cap = "76016",
                Prefisso = "0883",
                CodiceIstat = "112554"
            };
            return comune;
        }
    }
}