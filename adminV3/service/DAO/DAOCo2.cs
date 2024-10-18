using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using adminV3.smart_displayDB;

namespace adminV3.service.DAO
{
    class DAOCo2
    {
        NaolSmartDisplayContext Context;
        public DAOCo2()
        {
            Context = new NaolSmartDisplayContext();
        }
        //fonction qui récupère toutes les co2
        public List<Co2> GetAllCo2()
        {
            Context.Co2s.ToList();
            return Context.Co2s.ToList();
        }
        //fonction qui récupère le co2 selon l'id d'afficheur
        public List<Co2> GetCo2ByAfficheurId(int id)
        {
            return Context.Co2s.Where(c => c.AfficheurIdcapteur == id).ToList();
        }
        //fonction qui récupère le co2 selon l'id de afficheur et la date
        public List<Co2> GetCo2ByAfficheurIdAndDate(int id, DateOnly date)
        {
            return Context.Co2s.Where(c => c.AfficheurIdcapteur == id && c.Date == date).ToList();
        }
        //fonction qui récupère le co2 selon la date
        public List<Co2> GetCo2ByDate(DateOnly date)
        {
            return Context.Co2s.Where(c => c.Date == date).ToList();
        }

        //fonction qui récupère le co2 selon la date et la fonction GetAfficheurBySalleId
        public List<Co2> GetCo2ByDateAndSalleId(DateOnly date, int id)
        {
            return Context.Co2s.Where(c => c.Date == date && c.AfficheurIdcapteur == id).ToList();
        }
    }
}
