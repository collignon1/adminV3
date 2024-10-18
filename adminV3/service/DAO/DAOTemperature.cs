using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using adminV3.smart_displayDB;


namespace adminV3.service.DAO
{
    class DAOTemperature
    {
        NaolSmartDisplayContext Context;
        public DAOTemperature()
        {
            Context = new NaolSmartDisplayContext();
        }
        //fonction qui récupère toutes les températures
        public List<Temperature> GetAllTemperatures()
        {
            Context.Temperatures.ToList();
            return Context.Temperatures.ToList();
        }
        //fonction qui renvoie la température selon l'id d'afficheur
        public List<Temperature> GetTemperatureByAfficheurId(int id)
        {
            return Context.Temperatures.Where(t => t.AfficheurIdcapteur == id).ToList();
        }
        //fonction qui récupère la température selon l'id de afficheur et la date
        public List<Temperature> GetTemperatureByAfficheurIdAndDate(int id, DateOnly date)
        {
            return Context.Temperatures.Where(t => t.AfficheurIdcapteur == id && t.Date == date).ToList();
        }
        //fonction qui récupère la température selon la date
        public List<Temperature> GetTemperatureByDate(DateOnly date)
        {
            return Context.Temperatures.Where(t => t.Date == date).ToList();
        }
    }
}
