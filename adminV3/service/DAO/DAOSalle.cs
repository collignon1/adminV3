using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using adminV3.smart_displayDB;

namespace adminV3.service.DAO
{
    class DAOSalle
    {
        NaolSmartDisplayContext Context;
        public DAOSalle()
        {
            Context = new NaolSmartDisplayContext();
        }
        //liste des salles ne donnant que leur nom et l'id de batiment
        public List<Salle> GetSalles()
        {
            using (NaolSmartDisplayContext context = new NaolSmartDisplayContext())
            {
                return context.Salles.ToList();
            }
        }
        //ajouter une salle
        public void AddSalle(Salle salle)
        {
            using (NaolSmartDisplayContext context = new NaolSmartDisplayContext())
            {
                context.Salles.Add(salle);
                context.SaveChanges();
            }
        }
        //supprimer une salle
        public void RemoveSalle(int id)
        {
            using (NaolSmartDisplayContext context = new NaolSmartDisplayContext())
            {
                Salle salle = context.Salles.Find(id);
                context.Salles.Remove(salle);
                context.SaveChanges();
            }
        }
    }
}
