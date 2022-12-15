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
    public class TrackingRapository : ITrackingRepository
    {


        public Tracking GetTracking(int DeviceId)
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
                            CMD.CommandText = "GetTrackingById";
                            CMD.Parameters.AddWithValue("P_DeviceId", DeviceId);
                            MySqlDataReader DR = CMD.ExecuteReader();
                            DR.Read();
                            return new Tracking
                            {
                                DeviceId = Convert.ToInt32(DR[0]),
                                Ignition = DR[1].ToString(),
                                PowerCut = DR[2].ToString(),
                                BoxOpen = DR[3].ToString(),
                                Odometer = Convert.ToInt32(DR[4]),
                                Speed = Convert.ToInt32(DR[5]),
                                Latitude = Convert.ToInt32(DR[6]),
                                Longitude = Convert.ToInt32(DR[7]),
                                Location = DR[8].ToString(),
                                Altitude = Convert.ToInt32(DR[9]),
                                Direction = DR[10].ToString(),
                                DeviceTime = Convert.ToDateTime(DR[11]),


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

        public DataTable GetTrackings()
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
                            CMD.CommandText = "GetAllTracking";
                            MySqlDataReader DR = CMD.ExecuteReader();
                            DataTable userTable = new DataTable("Tracking");
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

        public int InserTracking(Tracking Tracking)
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
                            CMD.CommandText = "InsertTracking";
                            CMD.Parameters.AddWithValue("P_DeviceId", Tracking.DeviceId);
                            CMD.Parameters.AddWithValue("p_Ignition", Tracking.Ignition);
                            CMD.Parameters.AddWithValue("p_PowerCut", Tracking.PowerCut);
                            CMD.Parameters.AddWithValue("p_BoxOpen", Tracking.BoxOpen);
                            CMD.Parameters.AddWithValue("p_Odometer", Tracking.Odometer);
                            CMD.Parameters.AddWithValue("p_Speed", Tracking.Speed);
                            CMD.Parameters.AddWithValue("p_Latitude", Tracking.Latitude);
                            CMD.Parameters.AddWithValue("p_Longitude", Tracking.Longitude);
                            CMD.Parameters.AddWithValue("p_Location", Tracking.Location);
                            CMD.Parameters.AddWithValue("p_Altitude", Tracking.Altitude);
                            CMD.Parameters.AddWithValue("p_Direction", Tracking.Direction);
                            CMD.Parameters.AddWithValue("p_DeviceTime", Tracking.DeviceTime);



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

        public int UpdateTracking(Tracking Tracking)
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
                            CMD.CommandText = "InsertTracking";
                            CMD.Parameters.AddWithValue("p_DeviceId", Tracking.DeviceId);
                            CMD.Parameters.AddWithValue("p_Ignition", Tracking.Ignition);
                            CMD.Parameters.AddWithValue("p_PowerCut", Tracking.PowerCut);
                            CMD.Parameters.AddWithValue("p_BoxOpen", Tracking.BoxOpen);
                            CMD.Parameters.AddWithValue("p_Odometer", Tracking.Odometer);
                            CMD.Parameters.AddWithValue("p_Speed", Tracking.Speed);
                            CMD.Parameters.AddWithValue("p_Latitude", Tracking.Latitude);
                            CMD.Parameters.AddWithValue("p_Longitude", Tracking.Longitude);
                            CMD.Parameters.AddWithValue("p_LocationName", Tracking.Location);
                            CMD.Parameters.AddWithValue("p_Altitude", Tracking.Altitude);
                            CMD.Parameters.AddWithValue("p_Direction", Tracking.Direction);
                            CMD.Parameters.AddWithValue("p_DeviceDateTime", Tracking.DeviceTime);
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
            };
        }
        public int DeleteTracking(int DeviceId)
        {
            throw new NotImplementedException();
        }
    }
}
