using CarWash.API.Repositories.WashType;
using CarWash.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.Repositories.WashType
{
    public class WashTypeRepository : IWashTypeRepository
    {
        public bool Create(Entities.WashType washType)
        {
            var db = new CarWashContext();
            try
            {
                db.WashTypes.Add(washType);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                db.Dispose();
            }
        }
        public bool Delete(Entities.WashType washType)
        {
            var db = new CarWashContext();

            try
            {
                var washTypeObj = db.WashTypes.FirstOrDefault(x => x.ID == washType.ID);

                if (washTypeObj != null)
                {
                    db.WashTypes.Remove(washTypeObj);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                db?.Dispose();
            }
        }

        public Entities.WashType Read(int id)
        {
            var db = new CarWashContext();

            try
            {
                return db.WashTypes.AsNoTracking().FirstOrDefault(x => x.ID == id);
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                db?.Dispose();
            }
        }


        public List<Entities.WashType> ReadAll()
        {
            var db = new CarWashContext();

            try
            {
                return db.WashTypes.AsNoTracking().ToList();
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                db?.Dispose();
            }
        }

        public bool Update(Entities.WashType washType)
        {
            var db = new CarWashContext();

            try
            {
                db.Entry(washType).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            finally
            {
                db?.Dispose();
            }
        }
    }
}