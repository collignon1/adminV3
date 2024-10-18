using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using adminV3.smart_displayDB;

namespace adminV3.service.DAO
{
    class DAOLuminosite
    {
        NaolSmartDisplayContext Context;
        public DAOLuminosite()
        {
            Context = new NaolSmartDisplayContext();
        }
        //fonction qui récupère toutes les luminosités
        public List<Luminosite> GetAllLuminosites()
        {
            Context.Luminosites.ToList();
            return Context.Luminosites.ToList();
        }
        //fonction qui récupère la luminosité selon l'id d'afficheur
        public List<Luminosite> GetLuminositeByAfficheurId(int id)
        {
            return Context.Luminosites.Where(l => l.AfficheurIdcapteur == id).ToList();
        }
        //fonction qui récupère la luminosité selon l'id de afficheur et la date
        public List<Luminosite> GetLuminositeByAfficheurIdAndDate(int id, DateOnly date)
        {
            return Context.Luminosites.Where(l => l.AfficheurIdcapteur == id && l.Date == date).ToList();
        }
        //fonction qui récupère la luminosité selon la date
        public List<Luminosite> GetLuminositeByDate(DateOnly date)
        {
            return Context.Luminosites.Where(l => l.Date == date).ToList();
        }


    }
}
