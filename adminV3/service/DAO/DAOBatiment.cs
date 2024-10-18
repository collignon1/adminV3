using adminV3.smart_displayDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adminV3.service.DAO
{
    class DAOBatiment
    {
        NaolSmartDisplayContext context;
        public DAOBatiment()
        {
            context = new NaolSmartDisplayContext();
        }
        public List<Batiment> GetBatiments()
        {
            return context.Batiments.ToList();
        }
        //fonction permettant de détruire un batiment
        public void RemoveBatiment(int id)
        {
            Batiment batiment = context.Batiments.Find(id);
            context.Batiments.Remove(batiment);
            context.SaveChanges();
        }

        //fonction permettant de répertorier toutes les salles dans le batiment
        public List<Salle> GetSallesByBatiment(int idBatiment)
        {
            return context.Salles.Where(s => s.BatimentIdbatiment == idBatiment).ToList();
        }
    }
}
