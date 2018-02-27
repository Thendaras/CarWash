using CarWash.API.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.API.Repositories
{
    public class WashTypeRepository : IBaseRepository<WashType>
    {
        public bool Create(WashType washType)
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

        public bool Delete(WashType washType)
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

        public WashType Read(int id)
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

        public List<WashType> ReadAll()
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

        public bool Update(WashType washType)
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