using Client.Core.Data;
using idn.AnPhu.Biz.Models;
using System;
using System.Collections.Generic;
using idn.AnPhu.Biz.Persistance.Interface;
namespace idn.AnPhu.Biz.Services
{
    public class BankDiscountManager : DataManagerBase<BankDiscount>
    {
        public BankDiscountManager()
            : base()
        { }

        public BankDiscountManager(IDataProvider<BankDiscount> provider)
            : base(provider)
        {
        }

        private IBankDiscountProvider BankDiscountProvider
        {
            get { return (IBankDiscountProvider)Provider; }
        }


        public List<BankDiscount> Search(int startIndex, int lenght, ref int totalItem, string culture)
        {
            return BankDiscountProvider.Search(startIndex, lenght, ref totalItem, culture);
        }
        public List<BankDiscount> GetAllActive(string culture)
        {
            return BankDiscountProvider.GetAllActive(culture);
        }
        public void Add(BankDiscount model, string culture)
        {
            BankDiscountProvider.Add(model, culture);
        }
    }
}
