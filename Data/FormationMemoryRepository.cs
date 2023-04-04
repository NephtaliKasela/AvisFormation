using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class FormationMemoryRepository: IFormationRepository
    {
        private List<Formation> _formations = new List<Formation>();
        public FormationMemoryRepository()
        {
            _formations.Add(new Formation { Id = 1, name = "C#", nameSeo = "----", Descriotion = "C# (C-Sharp) is a programming language developed by Microsoft that runs on the .NET Framework. C# is used to develop web apps, desktop apps, mobile apps, games and much more. Start learning C# now »" });
            _formations.Add(new Formation { Id = 2, name = "C++", nameSeo = "----", Descriotion = "Le C++ est un langage compilé : pour écrire un tel programme, il faut commencer par écrire un ou plusieurs fichiers source. Ensuite, il faut compiler ces fichiers source grâce à un programme appelé compilateur afin d'obtenir un programme exécutable. Cette phase s'appelle la compilation." });
            _formations.Add(new Formation { Id = 3, name = "Python", nameSeo = "----", Descriotion = "Python is a computer programming language often used to build websites and software, automate tasks, and conduct data analysis. Python is a general-purpose language, meaning it can be used to create a variety of different programs and isn't specialized for any specific problems." });
            _formations.Add(new Formation { Id = 4, name = "JavaScript", nameSeo = "----", Descriotion = "JavaScript (JS) is a lightweight, interpreted, or just-in-time compiled programming language with first-class functions. While it is most well-known as the scripting language for Web pages, many non-browser environments also use it, such as Node.js, Apache CouchDB and Adobe Acrobat." });
            _formations.Add(new Formation { Id = 5, name = "Java", nameSeo = "----", Descriotion = "What is Java? Java is a widely used object-oriented programming language and software platform that runs on billions of devices, including notebook computers, mobile devices, gaming consoles, medical devices and many others. The rules and syntax of Java are based on the C and C++ languages." });
        }

        public List<Formation> GetAllFormations()
        {
            return _formations;
        }

        public List<Formation> GetFormations(int number)
        {
            // Get n formations randomly
            return _formations.OrderBy(qu => Guid.NewGuid()).Take(number).ToList();
        }

        public Formation GetFormationById(int iIdFormation)
        {
            return _formations.FirstOrDefault(f => f.Id == iIdFormation);
        }
    }
}
