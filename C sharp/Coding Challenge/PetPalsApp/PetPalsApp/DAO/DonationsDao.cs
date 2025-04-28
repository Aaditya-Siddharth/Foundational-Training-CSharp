using Microsoft.Data.SqlClient;
using PetPalsApp.Entity;
using PetPalsApp.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPalsApp.DAO
{
    public class DonationDao : IDonationsDao<Donation>
    {
        SqlConnection sqlCon = DBConnUtil.GetConnection("appSettings.json");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;

        //completed
        public bool DeleteDonationInfo(int donationID)
        {
            try
            {
                cmd.Connection = sqlCon;
                StringBuilder queryBuilder = new StringBuilder();
                queryBuilder = queryBuilder.Append($"DELETE FROM Donations WHERE DonationID = {donationID}");
                cmd.CommandText = queryBuilder.ToString();

                if (sqlCon.State == System.Data.ConnectionState.Closed)
                {
                    sqlCon.Open();
                }

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (SqlException ex)
            {
                return false;
            }
            finally
            {
                sqlCon.Close();
            }
        }

        //completed
        public List<Donation> GetAllDonations()
        {
            List<Donation> donationList = new List<Donation>();
            try
            {
                cmd.Connection = sqlCon;
                StringBuilder queryBuilder = new StringBuilder();
                queryBuilder.Append("SELECT * FROM Donations");
                cmd.CommandText = queryBuilder.ToString();

                if (sqlCon.State == System.Data.ConnectionState.Closed)
                {
                    sqlCon.Open();
                }
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Donation donation = new Donation();
                    donation.DonationID = Convert.ToInt32(dr["DonationID"]);
                    donation.DonorName = Convert.ToString(dr["DonorName"]);
                    donation.DonationType = Convert.ToString(dr["DonationType"]);
                    donation.DonationAmount = dr["DonationAmount"] != DBNull.Value ? Convert.ToDecimal(dr["DonationAmount"]) : null;
                    donation.DonationItem = dr["DonationItem"] != DBNull.Value ? Convert.ToString(dr["DonationItem"]) : null;
                    donation.DonationDate = Convert.ToDateTime(dr["DonationDate"]);
                    donation.ShelterID = dr["ShelterID"] != DBNull.Value ? Convert.ToInt32(dr["ShelterID"]) : null;
                    donationList.Add(donation);
                }
                dr.Close();
                return donationList;

            }
            catch (SqlException ex)
            {
                return null;
            }
            finally
            {
                sqlCon.Close();
            }
        }

        //completed
        public Donation GetDonationInfoByID(int donationID)
        {
            Donation donation = new Donation();
            try
            {
                cmd.Connection = sqlCon;
                StringBuilder queryBuilder = new StringBuilder();
                queryBuilder.Append($"SELECT * FROM Donations WHERE DonationID = {donationID}");
                cmd.CommandText = queryBuilder.ToString();

                if (sqlCon.State == System.Data.ConnectionState.Closed)
                {
                    sqlCon.Open();
                }

                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        
                    }
                    dr.Close();
                    return donation;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException ex)
            {
                return donation;
            }
            finally
            {
                sqlCon.Close();
            }
        }

        //completed
        public Donation SaveDonationInfo(Donation donation)
        {
            try
            {
                cmd.Connection = sqlCon;
                StringBuilder queryBuilder = new StringBuilder();
                queryBuilder.Append("INSERT INTO Donations (DonorName, DonationType, DonationAmount, DonationItem, DonationDate, ShelterID) VALUES (@DonorName, @DonationType, @DonationAmount, @DonationItem, @DonationDate, @ShelterID)");
                cmd.CommandText = queryBuilder.ToString();

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@DonorName", donation.DonorName);
                cmd.Parameters.AddWithValue("@DonationType", donation.DonationType);
                cmd.Parameters.AddWithValue("@DonationAmount", (object?)donation.DonationAmount ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@DonationItem", (object?)donation.DonationItem ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@DonationDate", donation.DonationDate);
                cmd.Parameters.AddWithValue("@ShelterID", (object?)donation.ShelterID ?? DBNull.Value);

                if (sqlCon.State == System.Data.ConnectionState.Closed)
                {
                    sqlCon.Open();
                }

                cmd.ExecuteNonQuery(); // Insert operation does not return any data, so it is not a Query to execute
                return donation;
            }
            catch (SqlException ex)
            {
                return null;
            }
            finally
            {
                sqlCon.Close();
            }
        }

        //completed
        public Donation UpdateDonationInfo(Donation donation)
        {
            try
            {
                cmd.Connection = sqlCon;
                StringBuilder queryBuilder = new StringBuilder();
                queryBuilder.Append($"UPDATE Pets SET DonorName = '{donation.DonorName}' DonationType ='{donation.DonationType}' DonationAmount={donation.DonationAmount} DonationItem='{donation.DonationItem}' DonationDate='{donation.DonationDate}' ShelterID='{donation.ShelterID}' where DonationID='{donation.DonationID}' ");
                cmd.CommandText = queryBuilder.ToString();

                if (sqlCon.State == System.Data.ConnectionState.Closed)
                {
                    sqlCon.Open();
                }
                cmd.ExecuteNonQuery();
                return donation;
            }
            catch (SqlException ex)
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
