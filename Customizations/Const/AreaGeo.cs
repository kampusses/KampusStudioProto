namespace KampusStudioProto.Customizations.Const
{
    public class AreaGeo
    {
        public string GetNomeArea(int id)
        {   
            string nomeArea = null;
            switch (id)
            {
                case 11:
                    nomeArea = "Unione europea";
                    break;
                case 12:
                    nomeArea = "Europa centro orientale";
                    break;
                case 13:
                    nomeArea = "Altri paesi europei";
                    break;
                case 21:
                    nomeArea = "Africa settentrionale";
                    break;
                case 22:
                    nomeArea = "Africa occidentale";
                    break;
                case 23:
                    nomeArea = "Africa orientale";
                    break;
                case 24:
                    nomeArea = "Africa centro meridionale";
                    break;
                case 31:
                    nomeArea = "Asia occidentale";
                    break;
                case 32:
                    nomeArea = "Asia centro meridionale";
                    break;
                case 33:
                    nomeArea = "Asia orientale";
                    break;
                case 41:
                    nomeArea = "America settentrionale";
                    break;
                case 42:
                    nomeArea = "America centro meridionale";
                    break;
                case 50:
                    nomeArea = "Oceania";
                    break;
            };
            return nomeArea;
        }
    }
}