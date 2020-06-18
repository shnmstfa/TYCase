using System;
using System.Net.Http.Headers;
using TyCase.Implementation;
using TyCase.Model;

namespace TyCase
{
    class Program
    {
        static void Main(string[] args)
        {
            var fruits = new Category("fruits");
            var vegetables = new Category("vegetables");

            var saltyFruits = new Category("saltyFruits", fruits);



            var apple = new Product("apple", 5, fruits);
            var tomato = new Product("tomato", 3, saltyFruits);

            var cucumber = new Product("cucumber", 4, vegetables);

            var cart = new ShoppingCart();

            cart.AddItem(apple, 10);
            cart.AddItem(tomato, 5);
            cart.AddItem(cucumber, 2);

            var campaign1 = new CategoryProductCountCampaign(fruits, 20, 3, DiscountTypeEnum.Rate);
            var campaign2 = new CategoryProductCountCampaign(saltyFruits, 5, 2, DiscountTypeEnum.Rate);
            var campaign3 = new CategoryProductCountCampaign(vegetables, 10, 5, DiscountTypeEnum.Amount);

            var coupon = new CartMinValueCoupon(10, 100, DiscountTypeEnum.Amount);

            cart.ApplyDiscounts(campaign1, campaign2, campaign3);

            cart.ApplyCoupon(coupon);

            CartDeliveryConfig config = new CartDeliveryConfig(10, 2, 2.99);

            

            cart.ApplyDeliveryCost(config.CalculateFor(cart));

            var cartOperator = new ShoppingCartOperator(cart);

            var totalAmount = cartOperator.GetTotalAmount();
            var totalAmountAfterDiscounts = cartOperator.GetTotalAmountAfterDiscount();
            var couponDiscounts = cartOperator.GetCouponDiscounts();
            var campaignDiscount = cartOperator.GetCampaignDiscount();
            var deliveryCost = cartOperator.GetDeliveryCost();

            var productsByCategory = cartOperator.GetProductsByCategory(fruits);


        }
    }
}
