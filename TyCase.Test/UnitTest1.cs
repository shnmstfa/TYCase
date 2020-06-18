using System;
using System.Net.Http.Headers;
using TyCase.Implementation;
using TyCase.Model;
using Xunit;

namespace TyCase.Test
{
    public class UnitTest1
    {
        [Fact]
        public void CategoryWithTitle()
        {
            var cat = new Category("cat1");

            Assert.True(cat.IsValid());
            Assert.Throws<Exception>(() => new Category(""));
            Assert.Throws<Exception>(() => new Category(null));
            Assert.Throws<Exception>(() => new Category("cat1", new Category(null)));
            Assert.Throws<Exception>(() => new Category(null, cat));


        }

        [Fact]
        public void ProductValidation()
        {
            var cat = new Category("cat1");

            Assert.True(new Product("test1", 1, cat).IsValid());
            Assert.Throws<Exception>(() =>  new Product("test2", -2, cat).IsValid());
            Assert.Throws<Exception>(() =>  new Product("test3", 0,cat).IsValid());
            Assert.Throws<Exception>(() =>  new Product("test4", 4,new Category(null)).IsValid());
            Assert.Throws<Exception>(() =>  new Product("test5", 5,new Category("")).IsValid());
            Assert.Throws<Exception>(() => new Product("", 6, cat).IsValid());
        }

        [Fact]
        public void CampaignValidation()
        {
            var cat = new Category("cat1");

            Assert.True(new CategoryProductCountCampaign(cat, 10, 5, DiscountTypeEnum.Rate).IsValid());
            Assert.Throws<Exception>(() => new CategoryProductCountCampaign(cat, 0, 5, DiscountTypeEnum.Rate).IsValid());
            Assert.Throws<Exception>(() => new CategoryProductCountCampaign(cat, -1, 5, DiscountTypeEnum.Rate).IsValid());
            Assert.Throws<Exception>(() => new CategoryProductCountCampaign(cat, 10, 0, DiscountTypeEnum.Amount).IsValid());
            Assert.Throws<Exception>(() => new CategoryProductCountCampaign(cat, 10, -5, DiscountTypeEnum.Amount).IsValid());
            Assert.Throws<Exception>(() => new CategoryProductCountCampaign(cat, 101, 5, DiscountTypeEnum.Rate).IsValid());
            Assert.True(new CategoryProductCountCampaign(cat, 10, 5, DiscountTypeEnum.Amount).IsValid());
            Assert.Throws<Exception>(() => new CategoryProductCountCampaign(cat, -1, 5, DiscountTypeEnum.Rate).IsValid());
            Assert.Throws<Exception>(() => new CategoryProductCountCampaign(new Category(""), 10, 5, DiscountTypeEnum.Rate).IsValid());

        }

        [Fact]
        public void CouponValidation()
        {
            var cat = new Category("cat1");

            Assert.True(new CartMinValueCoupon(10, 5, DiscountTypeEnum.Rate).IsValid());
            Assert.Throws<Exception>(() => new CartMinValueCoupon(0, 5, DiscountTypeEnum.Rate).IsValid());
            Assert.Throws<Exception>(() => new CartMinValueCoupon(-1, 5, DiscountTypeEnum.Rate).IsValid());
            Assert.Throws<Exception>(() => new CartMinValueCoupon(10, 0, DiscountTypeEnum.Amount).IsValid());
            Assert.Throws<Exception>(() => new CartMinValueCoupon(10, -5, DiscountTypeEnum.Amount).IsValid());
            Assert.Throws<Exception>(() => new CartMinValueCoupon(101, 5, DiscountTypeEnum.Rate).IsValid());
            Assert.True(new CartMinValueCoupon(10, 5, DiscountTypeEnum.Amount).IsValid());
            Assert.Throws<Exception>(() => new CartMinValueCoupon(-1, 5, DiscountTypeEnum.Rate).IsValid());
        }
    }
}
