using CarWash.Entities;
using CarWash.Repositories.Facility;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CarWash.Repositories
{
    public class FacilityRepository : IFacilityRepository
    {
        public bool Create(Entities.Facility facility)
        {
            var db = new CarWashContext();
            try
            {
                db.Facilities.Add(facility);
                db.SaveChanges();
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

        public bool Delete(Entities.Facility facility)
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

        public Entities.Facility Read(int id)
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

        public List<Entities.Facility> ReadAll()
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

        public bool Update(Entities.Facility facility)
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