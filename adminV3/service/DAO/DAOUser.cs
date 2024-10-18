using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using adminV3.smart_displayDB;

namespace adminV3.service.DAO
{
    class DAOUser
    {
        NaolSmartDisplayContext Context;
        public DAOUser()
        {
            Context = new NaolSmartDisplayContext();
        }
        public List<User> GetUsers()
        {
            return Context.Users.ToList();
        }
        public User GetUserById(int id)
        {
            return Context.Users.Find(id);
        }
        //avoir les user selon le statut
        public List<User> GetUsersByStatut(string statut)
        {
            return Context.Users.Where(u => u.Statut == statut).ToList();
        }
        //fonction permettant de détruire un user
        public void RemoveUser(int id)
        {
            User user = Context.Users.Find(id);
            Context.Users.Remove(user);
            Context.SaveChanges();
        }
        //fonction permettant d'ajouter un user
        public void AddUser(User user)
        {
            Context.Users.Add(user);
            Context.SaveChanges();
        }
    }
}
