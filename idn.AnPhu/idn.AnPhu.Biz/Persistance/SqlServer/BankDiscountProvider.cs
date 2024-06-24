using Client.Core.Data.DataAccess;
using Client.Core.Data.Entities;
using idn.AnPhu.Biz.Models;
using idn.AnPhu.Biz.Persistance.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Persistance.SqlServer
{
    public class BankDiscountProvider : DataAccessBase, IBankDiscountProvider
    {
        public BankDiscount Get(BankDiscount dummy)
        {
            var comm = this.GetCommand("sp_BankDiscountsGet");
            if (comm == null)
            {
                return null;
            }
            comm.AddParameter<int>(this.Factory, "BankDiscountId", dummy.BankDiscountId);
            var dt = this.GetTable(comm);
            var sliderBanner = EntityBase.ParseListFromTable<BankDiscount>(dt).FirstOrDefault();
            return sliderBanner ?? null;
            //throw new NotImplementedException();
        }

        public void Add(BankDiscount item)
        {
            //var comm = this.GetCommand("sp_BankDiscount_Insert");
            //if (comm == null) return;
            //comm.AddParameter<string>(this.Factory, "Url", item.Url);
            //comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            ////comm.AddParameter<DateTime>(this.Factory, "CreateDate", item.CreateDate);
            ////comm.AddParameter<DateTime>(this.Factory, "EditDate", item.EditDate);
            //comm.AddParameter<string>(this.Factory, "CreateBy", item.CreateBy);
            //comm.AddParameter<string>(this.Factory, "Image", item.Image);
            //comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);
            //comm.SafeExecuteNonQuery();
            throw new NotImplementedException();
        }

        public void Add(BankDiscount item, string culture)
        {
            var comm = this.GetCommand("sp_BankDiscount_Insert");
            if (comm == null) return;
            comm.AddParameter<string>(this.Factory, "BankDiscountName", item.BankDiscountName);
            comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            comm.AddParameter<decimal>(this.Factory, "BankValue", item.BankValue);
            comm.AddParameter<string>(this.Factory, "CreateBy", item.CreateBy);
            comm.AddParameter<double>(this.Factory, "BankDiscountValue", item.BankDiscountValue);
            comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);
            comm.SafeExecuteNonQuery();
            //throw new NotImplementedException();
        }
        public void Update(BankDiscount @new, BankDiscount old)
        {
            var item = @new;
            item.BankDiscountId = old.BankDiscountId;
            var comm = this.GetCommand("sp_BankDiscount_Update");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "BankDiscountId", item.BankDiscountId);
            comm.AddParameter<string>(this.Factory, "BankDiscountName", item.BankDiscountName);
            comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            comm.AddParameter<double>(this.Factory, "BankDiscountValue", item.BankDiscountValue);
            comm.AddParameter<decimal>(this.Factory, "BankValue", item.BankValue);
            comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);
            comm.SafeExecuteNonQuery();
            //throw new NotImplementedException();
        }

        public void Remove(BankDiscount item)
        {
            var comm = this.GetCommand("sp_BankDiscount_Delete");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "BankDiscountId", item.BankDiscountId);
            comm.SafeExecuteNonQuery();
            //throw new NotImplementedException();
        }

        public List<BankDiscount> GetAll(int startIndex, int count, ref int totalItems)
        {
            throw new NotImplementedException();
        }


        public List<BankDiscount> Search(int startIndex, int lenght, ref int totalItem, string culture)
        {
            var comm = this.GetCommand("sp_BankDiscountsSearch");
            if (comm == null) return null;
            comm.AddParameter<int>(this.Factory, "StartIndex", startIndex);
            comm.AddParameter<int>(this.Factory, "Length", lenght);
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            var totalItemsParam = comm.AddParameter(this.Factory, "TotalItems", DbType.Int32, null);
            totalItemsParam.Direction = ParameterDirection.Output;
            var dt = this.GetTable(comm);
            if (totalItemsParam.Value != DBNull.Value)
            {
                totalItem = Convert.ToInt32(totalItemsParam.Value);
            }
            return EntityBase.ParseListFromTable<BankDiscount>(dt);
        }
        public List<BankDiscount> GetAllActive(string culture)
        {
            var comm = this.GetCommand("sp_BankDiscountsGetAllActive");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<BankDiscount>(dt);
        }
    }
}
