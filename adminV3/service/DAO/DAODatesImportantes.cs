using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using adminV3.smart_displayDB;

namespace adminV3.service.DAO
{
    class DAODatesImportantes
    {
        NaolSmartDisplayContext Context;
        public DAODatesImportantes()
        {
            Context = new NaolSmartDisplayContext();
        }
        //fonction permettant de récupérer toutes les dates importantes
        public List<DateImportante> GetAllDatesImportantes()
        {
            Context.DateImportantes.ToList();
            return Context.DateImportantes.ToList();
        }
        //fonction permettant de supprimer des dates importantes
        public void RemoveDateImportante(int id)
        {
            DateImportante dateImportante = Context.DateImportantes.Find(id);
            Context.DateImportantes.Remove(dateImportante);
            Context.SaveChanges();

        }
        //fonction permettant d'ajouter une date importante
        public void AddDateImportante(DateImportante dateImportante)
        {
            Context.DateImportantes.Add(dateImportante);
            Context.SaveChanges();
        }

        //fonction permettant de modifier une date importante selon l'id
        public void UpdateDateImportante(DateImportante dateImportante)
        {
            Context.DateImportantes.Update(dateImportante);
            Context.SaveChanges();
        }

    }
}
