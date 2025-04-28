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
    public class ReservationDAO : IReservationDao<Reservation>
    {
        SqlConnection sqlCon = DBConnUtil.GetConnection("appSettings.json");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        public bool CancelReservation(int reservation_id)
        {
            try
            {
                cmd.Connection = sqlCon;
                StringBuilder queryBuilder = new StringBuilder();
                queryBuilder.Append("UPDATE reservations SET status = @status WHERE reservation_id = @reservation_id");
                cmd.CommandText = queryBuilder.ToString();

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@reservation_id", reservation_id);
                cmd.Parameters.AddWithValue("@status", "Cancelled");

                if (sqlCon.State == System.Data.ConnectionState.Closed)
                    sqlCon.Open();

                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (SqlException)
            {
                return false;
            }
            finally
            {
                sqlCon.Close();
            }
        }

        public Reservation CreateReservation(Reservation reservation)
        {
            try
            {
                cmd.Connection = sqlCon;
                StringBuilder queryBuilder = new StringBuilder();
                queryBuilder.Append("INSERT INTO reservations (asset_id, employee_id, reservation_date, status) ");
                queryBuilder.Append("VALUES (@asset_id, @employee_id, @reservation_date, @status)");
                cmd.CommandText = queryBuilder.ToString();

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@asset_id", reservation.asset_id);
                cmd.Parameters.AddWithValue("@employee_id", reservation.employee_id);
                cmd.Parameters.AddWithValue("@reservation_date", reservation.reservation_date);
                cmd.Parameters.AddWithValue("@status", reservation.status);

                if (sqlCon.State == System.Data.ConnectionState.Closed)
                    sqlCon.Open();

                cmd.ExecuteNonQuery();
                return reservation;
            }
            catch (SqlException)
            {
                return null;
            }
            finally
            {
                sqlCon.Close();
            }
        }

        public List<Reservation> GetAllReservations()
        {
            List<Reservation> reservationList = new List<Reservation>();
            try
            {
                cmd.Connection = sqlCon;
                cmd.CommandText = "SELECT * FROM reservations";

                if (sqlCon.State == System.Data.ConnectionState.Closed)
                    sqlCon.Open();

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Reservation res = new Reservation()
                    {
                        reservation_id = Convert.ToInt32(dr["reservation_id"]),
                        asset_id = Convert.ToInt32(dr["asset_id"]),
                        employee_id = Convert.ToInt32(dr["employee_id"]),
                        reservation_date = Convert.ToDateTime(dr["reservation_date"]),
                        status = Convert.ToString(dr["status"])
                    };
                    reservationList.Add(res);
                }

                dr.Close();
                return reservationList;
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

        public Reservation GetReservationById(int reservation_id)
        {
            try
            {
                cmd.Connection = sqlCon;
                cmd.CommandText = "SELECT * FROM reservations WHERE reservation_id = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", reservation_id);

                if (sqlCon.State == System.Data.ConnectionState.Closed)
                    sqlCon.Open();

                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    Reservation res = new Reservation()
                    {
                        reservation_id = Convert.ToInt32(dr["reservation_id"]),
                        asset_id = Convert.ToInt32(dr["asset_id"]),
                        employee_id = Convert.ToInt32(dr["employee_id"]),
                        reservation_date = Convert.ToDateTime(dr["reservation_date"]),
                        status = Convert.ToString(dr["status"])
                    };
                    dr.Close();
                    return res;
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

        public Reservation UpdateReservation(Reservation reservation)
        {
            try
            {
                cmd.Connection = sqlCon;
                StringBuilder queryBuilder = new StringBuilder();
                queryBuilder.Append("UPDATE reservations SET asset_id = @asset_id, employee_id = @employee_id, ");
                queryBuilder.Append("reservation_date = @reservation_date, status = @status ");
                queryBuilder.Append("WHERE reservation_id = @reservation_id");
                cmd.CommandText = queryBuilder.ToString();

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@asset_id", reservation.asset_id);
                cmd.Parameters.AddWithValue("@employee_id", reservation.employee_id);
                cmd.Parameters.AddWithValue("@reservation_date", reservation.reservation_date);
                cmd.Parameters.AddWithValue("@status", reservation.status);
                cmd.Parameters.AddWithValue("@reservation_id", reservation.reservation_id);

                if (sqlCon.State == System.Data.ConnectionState.Closed)
                    sqlCon.Open();

                cmd.ExecuteNonQuery();
                return reservation;
            }
            catch (SqlException)
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
