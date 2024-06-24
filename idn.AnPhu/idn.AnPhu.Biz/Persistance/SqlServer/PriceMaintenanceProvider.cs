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
    public class PriceMaintenanceProvider : DataAccessBase, IPriceMaintenanceProvider
    {
        public PriceMaintenance Get(PriceMaintenance dummy)
        {
            var comm = this.GetCommand("sp_PriceMaintenancesGet");
            if (comm == null)
            {
                return null;
            }
            comm.AddParameter<int>(this.Factory, "PriceMaintenanceId", dummy.PriceMaintenanceId);
            var dt = this.GetTable(comm);
            var sliderBanner = EntityBase.ParseListFromTable<PriceMaintenance>(dt).FirstOrDefault();
            return sliderBanner ?? null;
            //throw new NotImplementedException();
        }

        public void Add(PriceMaintenance item)
        {
            //var comm = this.GetCommand("sp_PriceMaintenance_Insert");
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

        public void Add(PriceMaintenance item, string culture)
        {
            var comm = this.GetCommand("sp_PriceMaintenance_Insert");
            if (comm == null) return;
            comm.AddParameter<string>(this.Factory, "PriceMaintenanceName", item.PriceMaintenanceName);
            comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            comm.AddParameter<string>(this.Factory, "CreateBy", item.CreateBy);
            comm.AddParameter<decimal>(this.Factory, "PriceMaintenanceValue", item.PriceMaintenanceValue);
            comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);
            comm.SafeExecuteNonQuery();
            //throw new NotImplementedException();
        }
        public void Update(PriceMaintenance @new, PriceMaintenance old)
        {
            var item = @new;
            item.PriceMaintenanceId = old.PriceMaintenanceId;
            var comm = this.GetCommand("sp_PriceMaintenance_Update");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "PriceMaintenanceId", item.PriceMaintenanceId);
            comm.AddParameter<string>(this.Factory, "PriceMaintenanceName", item.PriceMaintenanceName);
            comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            comm.AddParameter<decimal>(this.Factory, "PriceMaintenanceValue", item.PriceMaintenanceValue);
            comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);
            comm.SafeExecuteNonQuery();
            //throw new NotImplementedException();
        }

        public void Remove(PriceMaintenance item)
        {
            var comm = this.GetCommand("sp_PriceMaintenance_Delete");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "PriceMaintenanceId", item.PriceMaintenanceId);
            comm.SafeExecuteNonQuery();
            //throw new NotImplementedException();
        }

        public List<PriceMaintenance> GetAll(int startIndex, int count, ref int totalItems)
        {
            throw new NotImplementedException();
        }


        public List<PriceMaintenance> Search(int startIndex, int lenght, ref int totalItem, string culture)
        {
            var comm = this.GetCommand("sp_PriceMaintenancesSearch");
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
            return EntityBase.ParseListFromTable<PriceMaintenance>(dt);
        }
        public List<PriceMaintenance> GetAllActive(string culture)
        {
            var comm = this.GetCommand("sp_PriceMaintenancesGetAllActive");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<PriceMaintenance>(dt);
        }
    }
}
