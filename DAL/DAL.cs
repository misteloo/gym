using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Be;
using System.Data.Entity;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Net;
using System.Collections;

namespace DAL
{
    public class DataAccessLayer

    {
        

        Be.Entities1 entty = new Entities1();
      
        public bool creat(beAddAthlete addAthlete , periodRegister periodRegister)
        {
            var q = from i in entty.beAddAthletes where (i.codeMelli == addAthlete.codeMelli) select i;
            if (q.Count() > 0)
            {
                return true;
            }
            else
            {
                entty.beAddAthletes.Add(addAthlete);
                entty.periodRegisters.Add(periodRegister);

                var qq = from i in entty.debtLists join ii in entty.beAddAthletes on i.person equals ii.id select i;
 
                entty.SaveChanges();

                return false;
            }
            
            
        }

        public void updateIsCredit (int id)
        {
            var q = from i in entty.periodRegisters where i.id == id select i;
            periodRegister p = new periodRegister();
            p = q.Single();
            p.isCredit = false;

            
            entty.SaveChanges();
        }

        public bool updateCredit(string codeMelli, periodRegister periodRegister )

        {
            

            var getPersonId = from i in entty.beAddAthletes where i.codeMelli == codeMelli select i;
            
            if (getPersonId.Count()>0)
            {
                entty.periodRegisters.Add(periodRegister);
                
            }
            
            entty.SaveChanges();
            return true;
        }


        public List <periodRegister> read()
        {
            var q = from i in entty.beAddAthletes join ii in entty.periodRegisters on i.id equals ii.person select ii;

            return q.ToList();
        }

        
       
        
        
        /// <summary>
        /// Register and return today Atheletes
        /// </summary>
        /// <param name="daily"></param>
        /// <param name="date"></param>
        /// <returns></returns>
         public List<daily> daily(daily daily,string date)
        {

            var q = from i in entty.dailies where i.date == date select i;

            entty.dailies.Add(daily);
            entty.SaveChanges();

            return q.ToList();
        }
        
        
        /// <summary>
        /// update timeOut
        /// </summary>
        /// <param name="id"></param>
        /// <param name="timeOut"></param>
        /// <returns></returns>

        public void updateDaily(int id,string timeOut)
        {
            
            var q = from i in entty.dailies where i.id == id select i;
            

            if (q.Count() == 1)
            {
                daily d = new daily();
                d = q.Single();
                d.timeOut = timeOut;

                
                entty.SaveChanges();
            }
        }
        /// <summary>
        /// Just calling today Atheletes
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        
        
        
        
        
       public List<daily> daily()
        {
            
            var q = from i in entty.dailies select i;
            return q.ToList();
        } 

       
        /// <summary>
        /// Will return all of members who Registers in gym
        /// </summary>
        /// <returns></returns>
        
         
        public List<beAddAthlete> readRej()
        {
            var q = from i in entty.beAddAthletes select i;
            return q.ToList();
        }




        /// <summary>
        /// Search atheletes by codeMelli
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<beAddAthlete> readRej(string codeMelli)
        {
            var id = from i in entty.beAddAthletes where i.codeMelli == codeMelli select i;
            var q = from i in entty.periodRegisters group i by i.person into g select new { person = g.Key, debt = g.Select(f => f.cash).Sum() };
            var qq = from i in entty.beAddAthletes join ii in q on i.id equals ii.person select new { i.name , i.family , i.fatherName , ii.debt};
            var qqq = from i in id join ii in entty.periodRegisters on i.id equals ii.person select ii;

            return id.ToList();
        }




        /// <summary>
        /// Will return Id of memeber buy searching him codeMelli
        /// </summary>
        /// <returns></returns>
        public List<beAddAthlete> find(string codeMelli)
        {
            var q = from i in entty.beAddAthletes where i.codeMelli == codeMelli select i;

            return q.ToList();
        }

        
       
    }
}
