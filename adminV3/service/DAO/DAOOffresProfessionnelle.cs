using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using adminV3.smart_displayDB;

namespace adminV3.service.DAO
{
    class DAOOffresProfessionnelle
    {
        NaolSmartDisplayContext Context;
        public DAOOffresProfessionnelle()
        {
            Context = new NaolSmartDisplayContext();
        }
        //fonction qui récupère toutes les offres professionnelles
        public List<OffresProfessionnelle> GetAllOffresProfessionnelles()
        {
            Context.OffresProfessionnelles.ToList();
            return Context.OffresProfessionnelles.ToList();
        }
        //fonction permettant d'ajouter des offres professionnelles
        public void AddOffreProfessionnelle(OffresProfessionnelle offreProfessionnelle)
        {
            Context.OffresProfessionnelles.Add(offreProfessionnelle);
            Context.SaveChanges();
        }

        //fonction permettant de modifier des offres professionnelles
        public void UpdateOffreProfessionnelle(OffresProfessionnelle offreProfessionnelle)
        {
            Context.OffresProfessionnelles.Update(offreProfessionnelle);
            Context.SaveChanges();
        }
        //fonction permettant de supprimer des offres professionnelles
        public void RemoveOffreProfessionnelle(int id)
        {
            OffresProfessionnelle offreProfessionnelle = Context.OffresProfessionnelles.Find(id);
            Context.OffresProfessionnelles.Remove(offreProfessionnelle);
            Context.SaveChanges();
        }
    }
}
