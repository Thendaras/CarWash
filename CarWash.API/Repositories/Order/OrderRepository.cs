using CarWash.Entities;
using CarWash.Repositories.Order;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CarWash.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public bool Create(Entities.Order order)
        {
            var db = new CarWashContext();
            try
            {
                db.Orders.Add(order);
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

        public bool Delete(Entities.Order order)
        {
            var db = new CarWashContext();

            try
            {
                var orderObj = db.Orders.FirstOrDefault(x => x.ID == order.ID);

                if (orderObj != null)
                {
                    db.Orders.Remove(orderObj);
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

        public Entities.Order Read(int id)
        {
            var db = new CarWashContext();

            try
            {
                return db.Orders.AsNoTracking().FirstOrDefault(x => x.ID == id);
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

        public List<Entities.Order> ReadAll()
        {
            var db = new CarWashContext();

            try
            {
                return db.Orders.AsNoTracking().ToList();
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

        public bool Update(Entities.Order order)
        {
            var db = new CarWashContext();

            try
            {
                db.Entry(order).State = EntityState.Modified;
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