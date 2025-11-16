using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Driving_License_Management_DTOs;
using System.Data.SqlClient;
using System.Data.SqlTypes;


namespace Driving_License_Management_DataAccess
{
    public class clsPersonData
    {
        public static PersonDTO GetPersonByID(int PersonID)
        {
            PersonDTO person = null;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT p.*, c.CountryID, c.CountryName
                            FROM People p
                            INNER JOIN Countries c ON p.NationalityCountryID = c.CountryID
                            WHERE p.PersonID = @PersonID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    person = new PersonDTO
                    {
                        PersonID = Convert.ToInt32(reader["PersonID"]),
                        FirstName = reader["FirstName"].ToString(),
                        SecondName = reader["SecondName"].ToString(),
                        ThirdName = reader["ThirdName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        NationalNo = reader["NationalNo"].ToString(),
                        Gender = Convert.ToInt16(reader["Gender"]),
                        DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]),
                        Address = reader["Address"].ToString(),
                        Phone = reader["Phone"].ToString(),
                        Email = reader["Email"].ToString(),
                        NationalityCountryID = Convert.ToInt32(reader["NationalityCountryID"]),
                        CountryName = reader["CountryName"].ToString(),
                        ImagePath = reader["ImagePath"] == DBNull.Value ? "" : reader["ImagePath"].ToString(),
                    };
                }
                reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return person;
        }

        public static PersonDTO GetPersonByNationalNo(string NationalNo)
        {
            PersonDTO person = null;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT p.*, c.CountryID, c.CountryName
                            FROM People p
                            INNER JOIN Countries c ON p.NationalityCountryID = c.CountryID
                            WHERE p.NationalNo = @NationalNo";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    person = new PersonDTO
                    {
                        PersonID = Convert.ToInt32(reader["PersonID"]),
                        FirstName = reader["FirstName"].ToString(),
                        SecondName = reader["SecondName"].ToString(),
                        ThirdName = reader["ThirdName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        NationalNo = reader["NationalNo"].ToString(),
                        Gender = Convert.ToInt16(reader["Gender"]),
                        DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]),
                        Address = reader["Address"].ToString(),
                        Phone = reader["Phone"].ToString(),
                        Email = reader["Email"].ToString(),
                        NationalityCountryID = Convert.ToInt32(reader["NationalityCountryID"]),
                        CountryName = reader["CountryName"].ToString(),
                        ImagePath = reader["ImagePath"] == DBNull.Value ? "" : reader["ImagePath"].ToString(),
                    };
                }
                reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return person;
        }

        public static List<PersonDTO> GetAllPeople()
        {
            List<PersonDTO> people = new List<PersonDTO>();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT People.PersonID, People.NationalNo,
              People.FirstName, People.SecondName, People.ThirdName, People.LastName,
			  People.DateOfBirth, People.Gender,  
				  CASE
                  WHEN People.Gender = 0 THEN 'Male'

                  ELSE 'Female'

                  END as GenderCaption ,
			  People.Address, People.Phone, People.Email, 
              People.NationalityCountryID, Countries.CountryName, People.ImagePath
              FROM            People INNER JOIN
                         Countries ON People.NationalityCountryID = Countries.CountryID
                ORDER BY People.FirstName";
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    people.Add(new PersonDTO
                    {
                        PersonID = Convert.ToInt32(reader["PersonID"]),
                        FirstName = reader["FirstName"].ToString(),
                        SecondName = reader["SecondName"].ToString(),
                        ThirdName = reader["ThirdName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        NationalNo = reader["NationalNo"].ToString(),
                        Gender = Convert.ToInt16(reader["Gender"]),
                        DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]),
                        Address = reader["Address"].ToString(),
                        Phone = reader["Phone"].ToString(),
                        Email = reader["Email"].ToString(),
                        NationalityCountryID = Convert.ToInt32(reader["NationalityCountryID"]),
                        CountryName = reader["CountryName"].ToString(),
                        ImagePath = reader["ImagePath"] == DBNull.Value ? "" : reader["ImagePath"].ToString(),
                    });
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
            finally
            {
                connection.Close();
            }
            return people;
        }

        public static int AddNewPerson(PersonDTO person)
        {
            int PersonID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO People
                            (FirstName, SecondName, ThirdName, LastName, NationalNo, DateOfBirth, Gender, Address, Phone, Email, NationalityCountryID, ImagePath)
                            VALUES
                            (@FirstName, @SecondName, @ThirdName, @LastName, @NationalNo, @DateOfBirth, @Gender, @Address, @Phone, @Email, @NationalityCountryID, @ImagePath);
                            SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@FirstName", person.FirstName);
            command.Parameters.AddWithValue("@SecondName", person.SecondName);
            command.Parameters.AddWithValue("@ThirdName", person.ThirdName ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@LastName", person.LastName);
            command.Parameters.AddWithValue("@NationalNo", person.NationalNo);
            command.Parameters.AddWithValue("@DateOfBirth", person.DateOfBirth);
            command.Parameters.AddWithValue("@Gender", person.Gender);
            command.Parameters.AddWithValue("@Address", person.Address);
            command.Parameters.AddWithValue("@Phone", person.Phone);
            command.Parameters.AddWithValue("@Email", person.Email);
            command.Parameters.AddWithValue("@NationalityCountryID", person.NationalityCountryID);
            command.Parameters.AddWithValue("@ImagePath", person.ImagePath ?? (object)DBNull.Value);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    PersonID = insertedID;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return PersonID;
        }

        public static bool UpdatePerson(PersonDTO person)
        {
            int rowdAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"
                UPDATE People
                SET FirstName = @FirstName,
                    SecondName = @SecondName,
                    ThirdName = @ThirdName,
                    LastName = @LastName,
                    NationalNo = @NationalNo,
                    DateOfBirth = @DateOfBirth,
                    Gender = @Gender,
                    Address = @Address,
                    Phone = @Phone,
                    Email = @Email,
                    NationalityCountryID = @NationalityCountryID,
                    ImagePath = @ImagePath
                WHERE PersonID = @PersonID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", person.PersonID);
            command.Parameters.AddWithValue("@FirstName", person.FirstName);
            command.Parameters.AddWithValue("@SecondName", person.SecondName);
            command.Parameters.AddWithValue("@ThirdName", person.ThirdName ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@LastName", person.LastName);
            command.Parameters.AddWithValue("@NationalNo", person.NationalNo);
            command.Parameters.AddWithValue("@DateOfBirth", person.DateOfBirth);
            command.Parameters.AddWithValue("@Gender", person.Gender);
            command.Parameters.AddWithValue("@Address", person.Address);
            command.Parameters.AddWithValue("@Phone", person.Phone);
            command.Parameters.AddWithValue("@Email", person.Email);
            command.Parameters.AddWithValue("@NationalityCountryID", person.NationalityCountryID);
            command.Parameters.AddWithValue("@ImagePath", person.ImagePath ?? (object)DBNull.Value);

            try
            {
                connection.Open();
                rowdAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return (rowdAffected > 0);
        }

        public static bool DeletePerson(int PersonID)
        {
            int rowdAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"DELETE FROM People WHERE PersonID = @PersonID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            try
            {
                connection.Open();
                rowdAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return (rowdAffected > 0);
        }

        public static bool IsPersonExist (int PersonID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT 1 FROM People WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;
                reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return isFound;
        }

        public static bool IsPersonExist(string NationalNo)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT 1 FROM People WHERE NationalNo = @NationalNo";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;
                reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return isFound;
        }
    }
}
