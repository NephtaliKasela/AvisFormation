namespace Data
{
    internal interface IFormationRepository
    {
        public List<Formation> GetAllFormations();
        public List<Formation> GetFormations(int number);
        public Formation GetFormationById(int iIdFormation);
    }
}