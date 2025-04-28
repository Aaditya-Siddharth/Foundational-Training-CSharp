using Microsoft.Data.SqlClient;
using PetPalsApp.Entity;
using PetPalsApp.Exceptions;
using PetPalsApp.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPalsApp.DAO
{
    public class PetsDao : IPetsDao<Pets>
    {
        SqlConnection sqlCon = DBConnUtil.GetConnection("appSettings.json");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;

        //completed
        public bool DeletePetInfo(int petID)
        {
            try
            {
                cmd.Connection = sqlCon;
                StringBuilder queryBuilder = new StringBuilder();
                queryBuilder = queryBuilder.Append($"DELETE FROM Pets WHERE PetID = {petID}");
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


        //To be checked
        public List<Pets> GetAllPets()
        {
            List<Pets> petList = new List<Pets>();
            try
            {
                cmd.Connection = sqlCon;
                StringBuilder queryBuilder = new StringBuilder();
                queryBuilder.Append("SELECT * FROM Pets");
                cmd.CommandText = queryBuilder.ToString();

                if (sqlCon.State == System.Data.ConnectionState.Closed)
                {
                    sqlCon.Open();
                }
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Pets pet = new Pets();

                    pet.PetID = dr["PetID"] != DBNull.Value ? Convert.ToInt32(dr["PetID"]) : 0;
                    pet.Name = dr["Name"] != DBNull.Value ? Convert.ToString(dr["Name"]) : string.Empty;
                    pet.Age = dr["Age"] != DBNull.Value ? Convert.ToInt32(dr["Age"]) : 0;
                    pet.Breed = dr["Breed"] != DBNull.Value ? Convert.ToString(dr["Breed"]) : string.Empty;
                    pet.Type = dr["Type"] != DBNull.Value ? Convert.ToString(dr["Type"]) : string.Empty;
                    pet.AvailableForAdoption = dr["AvailableForAdoption"] != DBNull.Value ? Convert.ToBoolean(dr["AvailableForAdoption"]) : false;
                    pet.ShelterID = dr["ShelterID"] != DBNull.Value ? Convert.ToInt32(dr["ShelterID"]) : 0;

                    petList.Add(pet);
                }
                dr.Close();
                return petList;
            }
            catch (SqlException ex)
            {
                return petList; // Return empty list in case of an exception
            }
            finally
            {
                sqlCon.Close();
            }
        }

        //completed
        public Pets GetPetInfoByID(int petID)
        {
            Pets pets = new Pets();
            try
            {
                cmd.Connection = sqlCon;
                StringBuilder queryBuilder = new StringBuilder();
                queryBuilder = queryBuilder.Append($"SELECT * FROM Pets where PetID={petID}");
                cmd.CommandText = queryBuilder.ToString();

                if (sqlCon.State == System.Data.ConnectionState.Closed)
                {
                    sqlCon.Open();
                }
                dr=cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        pets.PetID = dr["PetID"] != DBNull.Value ? Convert.ToInt32(dr["PetID"]) : 0;
                        pets.Name = dr["Name"] != DBNull.Value ? Convert.ToString(dr["Name"]) : string.Empty;
                        pets.Age = dr["Age"] != DBNull.Value ? Convert.ToInt32(dr["Age"]) : 0;
                        pets.Breed = dr["Breed"] != DBNull.Value ? Convert.ToString(dr["Breed"]) : string.Empty;
                        pets.Type = dr["Type"] != DBNull.Value ? Convert.ToString(dr["Type"]) : string.Empty;
                        pets.AvailableForAdoption = dr["AvailableForAdoption"] != DBNull.Value ? Convert.ToBoolean(dr["AvailableForAdoption"]) : false;
                        pets.ShelterID = dr["ShelterID"] != DBNull.Value ? Convert.ToInt32(dr["ShelterID"]) : 0;
                    }
                    dr.Close();
                    return pets;
                }
                else
                {
                    return null;
                }

            }
            catch (SqlException ex)
            {
                return pets;
            }
            catch(PetNotFoundException ex)
            {
                return null;
            }
            finally
            {
                sqlCon.Close();
            }
        }



        //Completed
        public Pets SavePetInfo(Pets pet)
        {
            try
            {
                cmd.Connection = sqlCon;
                StringBuilder queryBuilder = new StringBuilder();
                queryBuilder.Append("INSERT INTO Pets(Name, Age, Breed, Type, AvailableForAdoption, ShelterID) VALUES(@Name, @Age, @Breed, @Type, @AvailableForAdoption, @ShelterID)");
                cmd.CommandText = queryBuilder.ToString();

                cmd.Parameters.AddWithValue("@Name", pet.Name);
                cmd.Parameters.AddWithValue("@Age", pet.Age);
                cmd.Parameters.AddWithValue("@Breed", pet.Breed);
                cmd.Parameters.AddWithValue("@Type", pet.Type);
                cmd.Parameters.AddWithValue("@AvailableForAdoption", pet.AvailableForAdoption);
                cmd.Parameters.AddWithValue("@ShelterID", pet.ShelterID);

                if (sqlCon.State == System.Data.ConnectionState.Closed)
                {
                    sqlCon.Open();
                }
                cmd.ExecuteNonQuery(); //Since we are Inserting a record, we don't need to read anything back. It is not a query
                return pet;
            }
            catch (SqlException ex)
            {
                // Log exception (not done here for simplicity)
                return null;
            }
            finally
            {
                sqlCon.Close();
            }
        
        }

        //completed
        public Pets UpdatePetInfo(Pets pet)
        {
            try
            {
                cmd.Connection = sqlCon;
                StringBuilder queryBuilder = new StringBuilder();
                queryBuilder.Append($"UPDATE Pets SET Name = '{pet.Name}', Age = '{pet.Age}', Breed = '{pet.Breed}', Type = '{pet.Type}', AvailableForAdoption = '{pet.AvailableForAdoption}' WHERE PetID = '{pet.PetID}'");
                cmd.CommandText = queryBuilder.ToString();

                if (sqlCon.State == System.Data.ConnectionState.Closed)
                {
                    sqlCon.Open();
                }
                cmd.ExecuteNonQuery();
                return pet;
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
