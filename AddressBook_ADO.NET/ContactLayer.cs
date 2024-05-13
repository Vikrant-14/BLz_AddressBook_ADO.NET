using System;
using System.Data.SqlClient;

namespace AddressBook_ADO.NET
{
    public class ContactLayer
    {
        private string _connectionString;

        public ContactLayer() 
        {
            _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AddressBook_Practice;User Id=sa;Password=cdac123;";
        }

        public void SelectRecord()
        {
            SqlConnection con = null;

            try
            {
                using(con = new SqlConnection( _connectionString )) 
                {
                    string query = "select * from contacts";

                    SqlCommand cmd = new SqlCommand( query, con );

                    con.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    while ( dr.Read() )
                    {
                        Console.WriteLine(dr["first_name"] + " " + dr["last_name"] + " - " + dr["email"]);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public void Insert(Contact contact)
        {
            SqlConnection con = null;

            try
            {
                using(con = new SqlConnection(_connectionString))
                {
                    string query = $"insert into Contacts(first_name,last_name,email,address,city,state,zip,phone_number) values(@ContactFirstName,@ContactLastName,@ContactEmail, @ContactAddress, @ContactCity, @ContactState, @ContactZipCode, @ContactNumber)";
                    
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@ContactFirstName", contact.FirstName);
                    cmd.Parameters.AddWithValue("@ContactLastName", contact.LastName);
                    cmd.Parameters.AddWithValue("@ContactEmail", contact.Email);
                    cmd.Parameters.AddWithValue("@ContactAddress", contact.Address);
                    cmd.Parameters.AddWithValue("@ContactCity", contact.City);
                    cmd.Parameters.AddWithValue("@ContactState", contact.State);
                    cmd.Parameters.AddWithValue("@ContactZipCode", contact.Zip);
                    cmd.Parameters.AddWithValue("@ContactNumber", contact.PhoneNumber);

                    con.Open();

                    cmd.ExecuteNonQuery();

                    Console.WriteLine("Data Inserted Successfully.");
                }
            }
            catch(SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public void Update() 
        {
            SqlConnection con = null;

            try
            {
                using (con = new SqlConnection(_connectionString))
                {
                    Console.Write("Enter your First Name : ");
                    string name = Console.ReadLine();

                    Console.Write("Enter Email Id to be Updated : ");
                    string email = Console.ReadLine();

                    string query = $"update Contacts set email = @ContactEmail where first_name = @ContactFirstName;";

                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@ContactFirstName", name);
                    cmd.Parameters.AddWithValue("@ContactEmail", email);

                    con.Open();

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if(rowsAffected > 0)
                    {
                        Console.WriteLine("Data Updated Successfully.");
                    }
                    else
                    {
                        Console.WriteLine("No data exists");
                    }

                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public void Delete()
        {
            

            SqlConnection con = null;

            try
            {
                using (con = new SqlConnection(_connectionString))
                {
                    Console.Write("Enter your First Name to be deleted: ");
                    string name = Console.ReadLine();


                    string query = $"delete contacts where first_name = @ContactFirstName";

                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@ContactFirstName", name);

                    con.Open();

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Data deleted Successfully.");
                    }
                    else
                    {
                        Console.WriteLine("No data exists");
                    }

                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

    }
}
