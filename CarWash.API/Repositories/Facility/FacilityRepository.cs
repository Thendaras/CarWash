using CarWash.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CarWash.Repositories
{
    public class FacilityRepository : IBaseRepository<Facility>
    {
        public bool Create(Facility facility)
        {
            var db = new CarWashContext();
            try
            {
                db.Facilities.Add(facility);
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

        public bool Delete(Facility facility)
        {
            var db = new CarWashContext();

            try
            {
                var facilityObj = db.Facilities.FirstOrDefault(x => x.ID == facility.ID);

                if (facilityObj != null)
                {
                    db.Facilities.Remove(facilityObj);
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

        public Facility Read(int id)
        {
            var db = new CarWashContext();

            try
            {
                return db.Facilities.AsNoTracking().FirstOrDefault(x => x.ID == id);
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

        public List<Facility> ReadAll()
        {
            var db = new CarWashContext();

            try
            {
                return db.Facilities.AsNoTracking().ToList();
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

        public bool Update(Facility facility)
        {
            var db = new CarWashContext();

            try
            {
                db.Entry(facility).State = EntityState.Modified;
                db.SaveChanges();
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
    }
}