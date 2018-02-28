using CarWash.Entities;
using CarWash.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash
{
    public class StatisticControl
    {
        private OrderRepository _orderRepository;

        public StatisticControl(OrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public void ShowStatistics()
        {
            List<Order> orders = _orderRepository.ReadAll();

            int ordersAmount = orders.Count();
            double earnings = 0.00;

            foreach (Order order in orders)
            {
                earnings += order.Price;
            }

            Console.WriteLine($"There is a total of {ordersAmount} orders, and {earnings} in earnings.");
        }
    }
}
