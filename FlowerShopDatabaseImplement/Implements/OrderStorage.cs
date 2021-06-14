﻿using FlowerShopBusinessLogic.BindingModel;
using FlowerShopBusinessLogic.Enums;
using FlowerShopBusinessLogic.Interfaces;
using FlowerShopBusinessLogic.ViewModels;
using FlowerShopDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlowerShopDatabaseImplement.Implements
{
    public class OrderStorage : IOrderStorage
    {
        public void Delete(OrderBindingModel model)
        {
            using (var context = new FlowerShopDatabase())
            {
                Order element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Orders.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        public OrderViewModel GetElement(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new FlowerShopDatabase())
            {
                var order = context.Orders.Include(rec => rec.Flower)
                .Include(rec => rec.Client)
                .Include(rec => rec.Implementer)
                .FirstOrDefault(rec => rec.Id == model.Id);
                return order != null ?
                CreateModel(order) : null;
            }
        }

        public List<OrderViewModel> GetFilteredList(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new FlowerShopDatabase())
            {
                return context.Orders
                .Include(rec => rec.Flower)
                .Include(rec => rec.Client)
                .Include(rec => rec.Implementer)
                .Where(rec => (!model.DateFrom.HasValue && !model.DateTo.HasValue && rec.DateCreate.Date == model.DateCreate.Date) ||
                (model.DateFrom.HasValue && model.DateTo.HasValue && rec.DateCreate.Date >= model.DateFrom.Value.Date && rec.DateCreate.Date <= model.DateTo.Value.Date) ||
                (model.ClientId.HasValue && rec.ClientId == model.ClientId) ||
                (model.FreeOrders.HasValue && model.FreeOrders.Value && rec.Status == OrderStatus.Принят) ||
                (model.ImplementerId.HasValue && rec.ImplementerId == model.ImplementerId && rec.Status == OrderStatus.Выполняется) ||
                (model.ImplementerId.HasValue && rec.ImplementerId == model.ImplementerId && rec.Status == OrderStatus.Требуются_материалы))
                .Select(CreateModel).ToList();
            }
        }


        public List<OrderViewModel> GetFullList()
        {
            using (var context = new FlowerShopDatabase())
            {
                return context.Orders.Include(rec => rec.Flower)
                    .Include(rec => rec.Client)
                    .Include(rec => rec.Implementer)
                    .Select(CreateModel).ToList();
            }
        }

        public void Insert(OrderBindingModel model)
        {
            if (!model.ClientId.HasValue)
            {
                throw new Exception("Клиент не выбран");
            }
            using (var context = new FlowerShopDatabase())
            {
                context.Orders.Add(CreateModel(model, new Order()));
                context.SaveChanges();
            }
        }

        public void Update(OrderBindingModel model)
        {
            using (var context = new FlowerShopDatabase())
            {
                var element = context.Orders.Include(rec => rec.Client)
                    .Include(rec => rec.Flower)
                    .Include(rec => rec.Implementer)
                    .FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                if (!model.ClientId.HasValue)
                {
                    model.ClientId = element.ClientId;
                }
                if (!model.ImplementerId.HasValue)
                {
                    model.ImplementerId = element.ImplementerId;
                }
                CreateModel(model, element);
                context.SaveChanges();
            }
        }

        private OrderViewModel CreateModel(Order order)
        {
            return new OrderViewModel
            {
                Id = order.Id,
                Count = order.Count,
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement,
                FlowerId = order.FlowerId,
                FlowerName = order.Flower.FlowerName,
                ClientId = order.ClientId,
                ClientFIO = order.Client.ClientFIO,
                ImplementerId = order.ImplementerId,
                ImplementerFIO = order.ImplementerId.HasValue ? order.Implementer.ImplementerFIO : string.Empty,
                Status = order.Status,
                Sum = order.Sum
            };
        }

        private Order CreateModel(OrderBindingModel model, Order order)
        {
            order.FlowerId = model.FlowerId;
            order.ClientId = Convert.ToInt32(model.ClientId);
            order.Count = model.Count;
            order.Status = model.Status;
            order.Sum = model.Sum;
            order.ImplementerId = model.ImplementerId;
            order.DateCreate = model.DateCreate;
            order.DateImplement = model.DateImplement;
            return order;
        }
    }
}
