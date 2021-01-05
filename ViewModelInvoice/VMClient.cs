using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ViewInvoice;

namespace ViewModelInvoice
{
    public class VMClient
    {
        public Client GetClientFromName(string clientName)
        {
            Client objClient = new Client();
            string query = "select ClientId,ClientName,ManagerName,Address,ContactNumber,EmailId,GSTNo,Discount,IGST from ClientMaster where clientName='" + clientName + "'";
            DataSet ds = Common.GetDataSet(query);
            if (ds != null && ds.Tables.Count > 0)
            {
                foreach (var dr in ds.Tables[0].AsEnumerable())
                {
                    objClient.ClientId = Convert.ToInt32(dr["ClientId"]);
                    objClient.ClientName = Convert.ToString(dr["ClientName"]);
                    objClient.ManagerName = Convert.ToString(dr["ManagerName"]);
                    objClient.Address = Convert.ToString(dr["Address"]);
                    objClient.ContactNumber = Convert.ToString(dr["ContactNumber"]);
                    objClient.EmailId = Convert.ToString(dr["EmailId"]);
                    objClient.GstNo = Convert.ToString(dr["GSTNo"]);
                    objClient.Discount = Convert.ToDouble(dr["Discount"]);
                    //objClient.CGST = Convert.ToDouble(dr["CGST"]);
                    //objClient.SGST = Convert.ToDouble(dr["SGST"]);
                    objClient.IGST = Convert.ToDouble(dr["IGST"]);
                }
            }
            return objClient;
        }

        public List<Shade> GetShades(int clientId)
        {
            List<Shade> shades = new List<Shade>();
            string query = "select ShadeId,ShadeCode,ItemName,Rate from ShadeMaster where ClientId=" + clientId + " order by ShadeId";
            DataSet ds = Common.GetDataSet(query);
            if (ds != null && ds.Tables.Count > 0)
            {
                foreach (var dr in ds.Tables[0].AsEnumerable())
                {
                    Shade objShade = new Shade();
                    objShade.ShadeId = Convert.ToInt32(dr["ShadeId"]);
                    objShade.ShadeCode = Convert.ToString(dr["ShadeCode"]);
                    objShade.ItemName = Convert.ToString(dr["ItemName"]);
                    objShade.Rate = Convert.ToDouble(dr["Rate"]);
                    shades.Add(objShade);
                }
            }
            return shades;
        }

        public List<Client> GetAllClients()
        {
            List<Client> clients = new List<Client>();
            string query = "select ClientId,ClientName,ManagerName,Address,ContactNumber,EmailId,GSTNo,Discount,IGST from ClientMaster order by ClientName";
            DataSet ds = Common.GetDataSet(query);
            if (ds != null && ds.Tables.Count > 0)
            {
                foreach (var dr in ds.Tables[0].AsEnumerable())
                {
                    Client objClient = new Client();
                    objClient.ClientId = Convert.ToInt32(dr["ClientId"]);
                    objClient.ClientName = Convert.ToString(dr["ClientName"]);
                    objClient.ManagerName = Convert.ToString(dr["ManagerName"]);
                    objClient.Address = Convert.ToString(dr["Address"]);
                    objClient.ContactNumber = Convert.ToString(dr["ContactNumber"]);
                    objClient.EmailId = Convert.ToString(dr["EmailId"]);
                    objClient.GstNo = Convert.ToString(dr["GSTNo"]);
                    objClient.Discount = Convert.ToDouble(dr["Discount"]);
                    //objClient.CGST = Convert.ToDouble(dr["CGST"]);
                    //objClient.SGST = Convert.ToDouble(dr["SGST"]);
                    objClient.IGST = Convert.ToDouble(dr["IGST"]);
                    clients.Add(objClient);
                }
            }
            return clients;
        }

        public void AddOrUpdateClientDetails(Client client)
        {
            if (client.ClientId > 0)
            {
                StringBuilder sbQuery = new StringBuilder();
                sbQuery.Append("Update ClientMaster Set ");
                sbQuery.Append("ClientName = '" + client.ClientName + "',");
                sbQuery.Append("ManagerName = '" + client.ManagerName + "',");
                sbQuery.Append("Address = '" + client.Address + "',");
                sbQuery.Append("ContactNumber = '" + client.ContactNumber + "',");
                sbQuery.Append("EmailId = '" + client.EmailId + "',");
                sbQuery.Append("GSTNo = '" + client.GstNo + "',");
                sbQuery.Append("Discount = " + client.Discount + ",");
                //sbQuery.Append("CGST = " + client.CGST + ",");
                //sbQuery.Append("SGST = " + client.SGST + ",");
                sbQuery.Append("IGST = " + client.IGST + ",");
                sbQuery.Append("UpdatedBy = " + Common.UserId + ", UpdatedOn = getDate() ");
                sbQuery.Append("where ClientId=" + client.ClientId);

                Common.ExecuteNonQuery(sbQuery.ToString());
            }
            else
            {
                StringBuilder sbQuery = new StringBuilder();
                sbQuery.Append("Insert into ClientMaster(ClientName,ManagerName,Address,ContactNumber,");
                sbQuery.Append("EmailId,GSTNo,Discount,IGST,UpdatedBy,UpdatedOn) Values (");
                sbQuery.Append("'" + client.ClientName + "','" + client.ManagerName + "','" + client.Address + "','" + client.ContactNumber + "',");
                sbQuery.Append("'" + client.EmailId + "','" + client.GstNo + "'," + client.Discount + "," + client.IGST + ",");
                sbQuery.Append(Common.UserId + ", getDate())");

                Common.ExecuteNonQuery(sbQuery.ToString());
            }
        }
    }
}
