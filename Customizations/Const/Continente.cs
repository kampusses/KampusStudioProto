namespace KampusStudioProto.Customizations.Const
{
    public class Continente
    {
        public string GetNomeContinente(int id)
        {   
            string nomeContinente = null;
            switch (id)
            {
                case 1:
                    nomeContinente = "Europa";
                    break;
                case 2:
                    nomeContinente = "Africa";
                    break;
                case 3:
                    nomeContinente = "Asia";
                    break;
                case 4:
                    nomeContinente = "America";
                    break;
                case 5:
                    nomeContinente = "Oceania";
                    break;
            };
            return nomeContinente;
        }
    }
}