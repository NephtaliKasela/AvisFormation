namespace Data
{
    public interface IAvisRepository
    {
        public void SaveAvis(string commentaire, string nom, string idFormation, string note);
    }
}