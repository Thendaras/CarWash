using CarWash.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CarWash.Repositories
{
    public class ProcessRepository : IBaseRepository<Process>
    {
        public bool Create(Process process)
        {
            var db = new CarWashContext();
            try
            {
                db.Processes.Add(process);
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

        public bool Delete(Process process)
        {
            var db = new CarWashContext();

            try
            {
                var processObj = db.Processes.FirstOrDefault(x => x.ID == process.ID);

                if (processObj != null)
                {
                    db.Processes.Remove(processObj);
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

        public Process Read(int id)
        {
            var db = new CarWashContext();

            try
            {
                return db.Processes.AsNoTracking().FirstOrDefault(x => x.ID == id);
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

        public List<Process> ReadAll()
        {
            var db = new CarWashContext();

            try
            {
                return db.Processes.AsNoTracking().ToList();
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

        public bool Update(Process process)
        {
            var db = new CarWashContext();

            try
            {
                db.Entry(process).State = EntityState.Modified;
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