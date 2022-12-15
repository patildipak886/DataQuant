using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Vts.Entites;

namespace Vts.Dal
{
    public class UserRepository : IUserRepository
    {


        public DataTable GetUsers()
        {
            try
            {
                using (MySqlConnection CN = new MySqlConnection(ConfigurationManager.ConnectionStrings["PoSystemConStr"].ConnectionString))
                {
                    using (MySqlCommand CMD = new MySqlCommand())
                    {
                        try
                        {
                            CN.Open();
                            CMD.Connection = CN;
                            CMD.CommandType = CommandType.StoredProcedure;
                            CMD.CommandText = "GetAllUser";
                            MySqlDataReader DR = CMD.ExecuteReader();
                            DataTable userTable = new DataTable("User");
                            userTable.Load(DR);
                            DR.Close();
                            CN.Close();
                            return userTable;

                        }
                        catch (Exception ex)
                        {
                            if (CN.State == ConnectionState.Open)
                            {
                                CN.Close();
                            }
                            throw new Exception(ex.Message);
                        }
                        finally
                        {
                            if (CN.State == ConnectionState.Open)
                            {
                                CN.Close();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public User GetUsers(int UserId)
        {
            try
            {
                using (MySqlConnection CN = new MySqlConnection(ConfigurationManager.ConnectionStrings["PoSystemConStr"].ConnectionString))
                {
                    using (MySqlCommand CMD = new MySqlCommand())
                    {
                        try
                        {
                            CN.Open();
                            CMD.Connection = CN;
                            CMD.CommandType = CommandType.StoredProcedure;
                            CMD.CommandText = "GetUserById";
                            CMD.Parameters.AddWithValue("p_UserId", UserId);
                            MySqlDataReader DR = CMD.ExecuteReader();
                            DR.Read();
                            return new User
                            {
                                UserId = Convert.ToInt32(DR[0]),
                                Name = DR[1].ToString(),
                                Mobile = Convert.ToInt32(DR[2]),
                                Organization = DR[3].ToString(),
                                Address = DR[4].ToString(),
                                Email = DR[5].ToString(),
                                Location = ((DR[6]).ToString()),
                                Photograph = DR[7].ToString(),

                            };
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message);
                        }
                        finally
                        {
                            if (CN.State == ConnectionState.Open)
                            {
                                CN.Close();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int InsertUser(User User)
        {
            try
            {
                using (MySqlConnection CN = new MySqlConnection(ConfigurationManager.ConnectionStrings["PoSystemConStr"].ConnectionString))
                {
                    using (MySqlCommand CMD = new MySqlCommand())
                    {
                        try
                        {
                            CN.Open();
                            CMD.Connection = CN;
                            CMD.CommandType = CommandType.StoredProcedure;
                            CMD.CommandText = "InsertUser";
                            CMD.Parameters.AddWithValue("p_Name", User.Name);
                            CMD.Parameters.AddWithValue("p_Mobile", User.Mobile);
                            CMD.Parameters.AddWithValue("p_Organization", User.Organization);
                            CMD.Parameters.AddWithValue("p_Address", User.Address);
                            CMD.Parameters.AddWithValue("p_Email", User.Email);
                            CMD.Parameters.AddWithValue("p_Location", User.Location);
                            CMD.Parameters.AddWithValue("p_Photograph", User.Photograph);
                            int result = CMD.ExecuteNonQuery();
                            if (result > 0)
                            {
                                return result;
                            }
                            else
                            {
                                return -1;
                            }




                        }
                        catch (Exception ex)
                        {
                            if (CN.State == ConnectionState.Open)
                            {
                                CN.Close();
                            }
                            throw new Exception(ex.Message);
                        }
                        finally
                        {
                            if (CN.State == ConnectionState.Open)
                            {
                                CN.Close();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public int UpdateUser(User User)
        {
            try
            {
                using (MySqlConnection CN = new MySqlConnection(ConfigurationManager.ConnectionStrings["PoSystemConStr"].ConnectionString))
                {
                    using (MySqlCommand CMD = new MySqlCommand())
                    {
                        try
                        {
                            CN.Open();
                            CMD.Connection = CN;
                            CMD.CommandType = CommandType.StoredProcedure;
                            CMD.CommandText = "UpdateUser";
                            CMD.Parameters.AddWithValue("p_UserId", User.UserId);
                            CMD.Parameters.AddWithValue("p_Name", User.Name);
                            CMD.Parameters.AddWithValue("p_Mobile", User.Mobile);
                            CMD.Parameters.AddWithValue("p_Organization", User.Organization);
                            CMD.Parameters.AddWithValue("p_Address", User.Address);
                            CMD.Parameters.AddWithValue("p_Email", User.Email);
                            CMD.Parameters.AddWithValue("p_Location", User.Location);

                            CMD.Parameters.AddWithValue("p_Photogragh", User.Photograph);
                            int result = CMD.ExecuteNonQuery();
                            if (result > 0)
                            {
                                return result;
                            }
                            else
                            {
                                return -1;
                            }




                        }
                        catch (Exception ex)
                        {
                            if (CN.State == ConnectionState.Open)
                            {
                                CN.Close();
                            }
                            throw new Exception(ex.Message);
                        }
                        finally
                        {
                            if (CN.State == ConnectionState.Open)
                            {
                                CN.Close();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public int DeleteUser(int UserId)
        {
            try
            {
                using (MySqlConnection CN = new MySqlConnection(ConfigurationManager.ConnectionStrings["PoSystemConStr"].ConnectionString))
                {
                    using (MySqlCommand CMD = new MySqlCommand())
                    {
                        try
                        {
                            CN.Open();
                            CMD.Connection = CN;
                            CMD.CommandType = CommandType.StoredProcedure;
                            CMD.CommandText = "DeleteUser";
                            CMD.Parameters.AddWithValue("p_UserId", UserId);

                            int result = CMD.ExecuteNonQuery();
                            if (result > 0)
                            {
                                return result;
                            }
                            else
                            {
                                return -1;
                            }




                        }
                        catch (Exception ex)
                        {
                            if (CN.State == ConnectionState.Open)
                            {
                                CN.Close();
                            }
                            throw new Exception(ex.Message);
                        }
                        finally
                        {
                            if (CN.State == ConnectionState.Open)
                            {
                                CN.Close();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
    }
}
