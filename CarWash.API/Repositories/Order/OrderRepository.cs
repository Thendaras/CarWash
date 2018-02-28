using CarWash.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CarWash.Repositories
{
    public class OrderRepository : IBaseRepository<Order>
    {
        public bool Create(Order order)
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

        public bool Delete(Order order)
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

        public Order Read(int id)
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

        public List<Order> ReadAll()
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

        public bool Update(Order order)
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