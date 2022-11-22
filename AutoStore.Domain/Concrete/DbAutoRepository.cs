using AutoMapper;
using AutoStore.Domain.Abstract;
using AutoStore.Domain.Entities;
using System.Collections.Generic;
using System.Data.Entity;

namespace AutoStore.Domain.Concrete
{
    public class DbAutoRepository : IAutoRepository
    {
        AutoContext context = new AutoContext();
        public IEnumerable<Auto> Autos
        {
            get { return context.Autos; }
        }

        

        public void SaveAuto(Auto auto)
        {
            if (auto.AutoId == 0)
            {
                context.Autos.Add(auto);
            }
            else
            {
                Auto dbEntry = context.Autos.Find(auto.AutoId);
                if (dbEntry != null)
                {
                    //var config= new MapperConfiguration (cfg=>cfg.CreateMap<Auto,dbEntry>)
                    //context.Entry(dbEntry).State = EntityState.Modified;
                    dbEntry.Name = auto.Name;
                    dbEntry.Country = auto.Country;
                    dbEntry.Category = auto.Category;
                    dbEntry.Price = auto.Price;
                    dbEntry.ImageData = auto.ImageData;
                    dbEntry.ImageMimeType = auto.ImageMimeType;
                }
            }
            context.SaveChanges();
        }
        public Auto DeleteAuto(int autoId)
        {
            Auto auto = context.Autos.Find(autoId);
            if (auto != null)
            {
                context.Autos.Remove(auto);
                context.SaveChanges();
            }
            return auto;
        }
    }
}
