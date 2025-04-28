using AssetManagementApp.Entity;
using AssetManagementApp.Util;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementApp.DAO
{
    public class AssetDAO : IAssetDao<Assets>
    {
        SqlConnection sqlCon = DBConnUtil.GetConnection("appSettings.json");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        public Assets AddAsset(Assets asset)
        {
            try
            {
                cmd.Connection = sqlCon;
                StringBuilder queryBuilder = new StringBuilder();
                queryBuilder.Append("INSERT INTO assets (name, Type, serial_number, purchasedate, location, status, owner_id) ");
                queryBuilder.Append("VALUES (@name, @type, @serial_number, @purchasedate, @location, @status, @owner_id)");
                cmd.CommandText = queryBuilder.ToString();

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@name", asset.name);
                cmd.Parameters.AddWithValue("@type", asset.Type);
                cmd.Parameters.AddWithValue("@serial_number", asset.serial_number);
                cmd.Parameters.AddWithValue("@purchasedate", asset.purchasedate);
                cmd.Parameters.AddWithValue("@location", asset.location);
                cmd.Parameters.AddWithValue("@status", asset.status);
                cmd.Parameters.AddWithValue("@owner_id", asset.owner_id);

                if (sqlCon.State == System.Data.ConnectionState.Closed)
                    sqlCon.Open();

                cmd.ExecuteNonQuery();
                return asset;
            }
            catch
            {
                return null;
            }
            finally
            {
                sqlCon.Close();
            }
        }

        public bool DeleteAsset(int asset_id)
        {
            try
            {
                cmd.Connection = sqlCon;
                cmd.CommandText = $"DELETE FROM assets WHERE asset_id = {asset_id}";

                if (sqlCon.State == System.Data.ConnectionState.Closed)
                    sqlCon.Open();

                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlCon.Close();
            }
        }

        public List<Assets> GetAllAssets()
        {
            List<Assets> assetList = new List<Assets>();
            try
            {
                cmd.Connection = sqlCon;
                cmd.CommandText = "SELECT * FROM assets";

                if (sqlCon.State == System.Data.ConnectionState.Closed)
                    sqlCon.Open();

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Assets asset = new Assets()
                    {
                        asset_id = Convert.ToInt32(dr["asset_id"]),
                        name = dr["name"].ToString(),
                        Type = dr["Type"].ToString(),
                        serial_number = Convert.ToInt32(dr["serial_number"]),
                        purchasedate = Convert.ToDateTime(dr["purchasedate"]),
                        location = dr["location"].ToString(),
                        status = dr["status"].ToString(),
                        owner_id = Convert.ToInt32(dr["owner_id"])
                    };
                    assetList.Add(asset);
                }
                dr.Close();
                return assetList;
            }
            catch
            {
                return null;
            }
            finally
            {
                sqlCon.Close();
            }
        }

        public Assets GetAssetById(int asset_id)
        {
            try
            {
                cmd.Connection = sqlCon;
                cmd.CommandText = "SELECT * FROM assets WHERE asset_id = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", asset_id);

                if (sqlCon.State == System.Data.ConnectionState.Closed)
                    sqlCon.Open();

                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    Assets asset = new Assets()
                    {
                        asset_id = Convert.ToInt32(dr["asset_id"]),
                        name = dr["name"].ToString(),
                        Type = dr["Type"].ToString(),
                        serial_number = Convert.ToInt32(dr["serial_number"]),
                        purchasedate = Convert.ToDateTime(dr["purchasedate"]),
                        location = dr["location"].ToString(),
                        status = dr["status"].ToString(),
                        owner_id = Convert.ToInt32(dr["owner_id"])
                    };
                    dr.Close();
                    return asset;
                }
                dr.Close();
                return null;
            }
            catch
            {
                return null;
            }
            finally
            {
                sqlCon.Close();
            }
        }

        public Assets UpdateAsset(Assets asset)
        {
            try
            {
                cmd.Connection = sqlCon;
                StringBuilder queryBuilder = new StringBuilder();
                queryBuilder.Append("UPDATE assets SET name = @name, Type = @type, serial_number = @serial_number, ");
                queryBuilder.Append("purchasedate = @purchasedate, location = @location, status = @status, owner_id = @owner_id WHERE asset_id = @id");
                cmd.CommandText = queryBuilder.ToString();

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@name", asset.name);
                cmd.Parameters.AddWithValue("@type", asset.Type);
                cmd.Parameters.AddWithValue("@serial_number", asset.serial_number);
                cmd.Parameters.AddWithValue("@purchasedate", asset.purchasedate);
                cmd.Parameters.AddWithValue("@location", asset.location);
                cmd.Parameters.AddWithValue("@status", asset.status);
                cmd.Parameters.AddWithValue("@owner_id", asset.owner_id);
                cmd.Parameters.AddWithValue("@id", asset.asset_id);

                if (sqlCon.State == System.Data.ConnectionState.Closed)
                    sqlCon.Open();

                cmd.ExecuteNonQuery();
                return asset;
            }
            catch
            {
                return null;
            }
            finally
            {
                sqlCon.Close();
            }
        }
    }
}
