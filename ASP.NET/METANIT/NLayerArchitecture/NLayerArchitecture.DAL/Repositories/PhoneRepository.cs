using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using NLayerArchitecture.DAL.Interfaces;
using NLayerArchitecture.DAL.Entities;
using NLayerArchitecture.DAL.EntityFramework;

namespace NLayerArchitecture.DAL.Repositories
{
    public class PhoneRepository : IRepository<Phone>
    {
        private MobileContext db;

        public PhoneRepository(MobileContext context)
        {
            db = context;
        }

        public void Create(Phone item)
        {
            db.Phones.Add(item);
        }

        public void Delete(int id)
        {
            Phone item = db.Phones.Find(id);
            if (item != null)
                db.Phones.Remove(item);
        }

        public IEnumerable<Phone> Find(Func<Phone, bool> predicate)
        {
            return db.Phones.Where(predicate).ToList();
        }

        public Phone Get(int id)
        {
            return db.Phones.Find(id);
        }

        public IEnumerable<Phone> GetAll()
        {
            return db.Phones;
        }

        public void Update(Phone item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}