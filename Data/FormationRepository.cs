using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class FormationRepository: IFormationRepository
    {
        MonDBContext _context;

        public FormationRepository(MonDBContext context)
        {
            _context= context;
        }

        public List<Formation> GetAllFormations()
        {
            return _context.Formations.Include("Avis").ToList();
        }

        public List<Formation> GetFormations(int number)
        {
            return _context.Formations.Include("Avis").OrderBy(qu => Guid.NewGuid()).Take(number).ToList();
        }

        public Formation GetFormationById(int iIdFormation)
        {
            return _context.Formations.Include("Avis").FirstOrDefault(f => f.Id == iIdFormation);
        }
    }
}
