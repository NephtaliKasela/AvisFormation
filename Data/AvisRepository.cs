using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class AvisRepository: IAvisRepository
    {
        MonDBContext _context;

        public AvisRepository(MonDBContext context)
        {
            this._context = context;
        }
        public void SaveAvis(string commentaire, string nom, string idFormation, string note)
        {
            //throw new NotImplementedException();
            int iIdFormation = -1;
            if(!Int32.TryParse(idFormation, out iIdFormation))
            {
                return;
            }
            double dNote = -1;
            if(!Double.TryParse(note, System.Globalization.NumberStyles.Any,CultureInfo.InvariantCulture, out dNote))
            {
                return;
            }

            var avis = new Avis();  
            avis.Commentaire= commentaire;
            avis.NomUtilisateur = nom;
            avis.FormationId = iIdFormation;
            avis.Note = dNote;

            _context.Avis.Add(avis);
            _context.SaveChanges();
        }
    }
}
