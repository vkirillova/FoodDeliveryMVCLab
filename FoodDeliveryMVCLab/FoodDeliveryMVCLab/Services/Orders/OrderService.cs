using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FoodDeliveryMVCLab.DAL.DbContext;
using FoodDeliveryMVCLab.DAL.Entities;
using FoodDeliveryMVCLab.Models.Dishes;
using FoodDeliveryMVCLab.Models.Orders;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace FoodDeliveryMVCLab.Services.Orders
{
    public class OrderService : IOrderService
    {
        private IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly UserManager<User> _userManager;

        public OrderService(UserManager<User> userManager, IUnitOfWorkFactory unitOfWorkFactory)
        {
            _userManager = userManager;
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task CleanShoppingCartAsync(int dishId, User user)
        {
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                var dish = unitOfWork.Dishes.GetById(dishId);
                if (dish != null)
                {
                    var bucketItems = string.IsNullOrWhiteSpace(user.ShoppingCart);
                    user.ShoppingCart = JsonConvert.SerializeObject(bucketItems);
                    await _userManager.UpdateAsync(user);
                }
            }
        }

        public OrderCreateModel GetOrderCreateModel(int dishId)
        {
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                var product = unitOfWork.Dishes.GetAllDishes();

                var orderCreateModel = new OrderCreateModel()
                {
                    DishtId = dishId,
                    Product = Mapper.Map<DishViewModel>(product),
                };

                return orderCreateModel;
            }
        }

        public FoodDeliveryMVCLab.DAL.Entities.Order CreateOrder(OrderCreateModel model)
        {
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                var order = Mapper.Map<FoodDeliveryMVCLab.DAL.Entities.Order>(model);
                order.CreatedOn = DateTime.Now;
                var dish = unitOfWork.Dishes.GetById(order.Id);
                order.TotalPrice = model.Amount * dish.Price;

                order = unitOfWork.Orders.Create(order);

                return order;
            }
        }

        public List<OrderViewModel> GetOrdersList()
        {
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                var orders = unitOfWork.Orders.GetAll().ToList();

                return Mapper.Map<List<OrderViewModel>>(orders);
            }
        }
    }
}