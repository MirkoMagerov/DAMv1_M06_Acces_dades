﻿using cat.itb.M6UF2EA3;
using cat.itb.M6UF2Pr.Model;

namespace cat.itb.M6UF2Pr.Cruds
{
    public class OrderCRUD
    {
        public Order SelectById(int id)
        {
            Order order;
            using (var session = SessionFactoryCloud.Open())
            {
                order = session.Get<Order>(id);
            }
            return order;
        }
    }
}
