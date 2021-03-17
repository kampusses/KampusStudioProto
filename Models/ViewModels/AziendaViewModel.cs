using System;
using System.Data;

namespace KampusStudioProto.Models.ViewModels
{
    public class AziendaViewModel
    {
        public string NomeAzienda {get; set;}
        public string ToponimoAzienda { get; set; }
        public string IndirizzoAzienda { get; set; }
        public int CivicoAzienda { get; set; }
        public string LetteraAzienda { get; set; }
        public string LocalitaAzienda { get; set; }
        public string CittaAzienda { get; set; }
        public string PartitaIvaAzienda { get; set; }
        public string CodiceFiscaleAzienda { get; set; }
        public string TelefonoAzienda { get; set; }
        public string FaxAzienda { get; set; }
        public string EmailAzienda { get; set; }
        public string PecAzienda { get; set; }
        public string ToponimoAgenzia { get; set; }
        public string IndirizzoAgenzia { get; set; }
        public int CivicoAgenzia { get; set; }
        public string LetteraAgenzia { get; set; }
        public string LocalitaAgenzia { get; set; }
        public string TelefonoAgenzia { get; set; }
        public string FaxAgenzia { get; set; }
        public string EmailAgenzia { get; set; }
        public string PecAgenzia { get; set; }
        public string Card {get; set;}
        public static AziendaViewModel FromDataRow(DataRow aziendaRow)
        {
            var aziendaViewModel = new AziendaViewModel
            {
                NomeAzienda = Convert.ToString(aziendaRow["nomeAzienda"]),
                ToponimoAzienda = Convert.ToString(aziendaRow["toponimoAzienda"]),
                IndirizzoAzienda = Convert.ToString(aziendaRow["indirizzoAzienda"]),
                CivicoAzienda = Convert.ToInt16(aziendaRow["civicoAzienda"]),
                LetteraAzienda = Convert.ToString(aziendaRow["letteraAzienda"]),
                LocalitaAzienda = Convert.ToString(aziendaRow["localitaAzienda"]),
                CittaAzienda = Convert.ToString(aziendaRow["cittaAzienda"]),
                PartitaIvaAzienda = Convert.ToString(aziendaRow["partitaIvaAzienda"]),
                CodiceFiscaleAzienda = Convert.ToString(aziendaRow["codiceFiscaleAzienda"]),
                TelefonoAzienda = Convert.ToString(aziendaRow["telefonoAzienda"]),
                FaxAzienda = Convert.ToString(aziendaRow["faxAzienda"]),
                EmailAzienda = Convert.ToString(aziendaRow["emailAzienda"]),
                PecAzienda = Convert.ToString(aziendaRow["pecAzienda"]),
                ToponimoAgenzia = Convert.ToString(aziendaRow["toponimoAgenzia"]),
                IndirizzoAgenzia = Convert.ToString(aziendaRow["indirizzoAgenzia"]),
                CivicoAgenzia = Convert.ToInt16(aziendaRow["civicoAgenzia"]),
                LetteraAgenzia = Convert.ToString(aziendaRow["letteraAgenzia"]),
                LocalitaAgenzia = Convert.ToString(aziendaRow["localitaAgenzia"]),
                TelefonoAgenzia = Convert.ToString(aziendaRow["telefonoAgenzia"]),
                FaxAgenzia = Convert.ToString(aziendaRow["faxAgenzia"]),
                EmailAgenzia = Convert.ToString(aziendaRow["emailAgenzia"]),
                PecAgenzia = Convert.ToString(aziendaRow["pecAgenzia"]),
                Card = ""
            };
            return aziendaViewModel;
        }
    }
}