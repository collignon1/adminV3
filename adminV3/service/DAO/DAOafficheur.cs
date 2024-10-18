using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using adminV3.smart_displayDB;

namespace adminV3.service.DAO
{
    class DAOafficheur
    {
        NaolSmartDisplayContext Context;
        public DAOafficheur()
        {
            Context = new NaolSmartDisplayContext();
        }
        //fonction qui récupère les données d'un afficheur selon l'id de salle qui lui est associé
        public List<Afficheur> GetAfficheurBySalleId(int id)
        {
            return Context.Afficheurs.Where(a => a.SalleIdsalle == id).ToList();
        }
    }
}
