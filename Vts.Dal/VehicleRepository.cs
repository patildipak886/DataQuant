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
    public class VehicleRepository : IVehicleRepository
    {


        public DataTable GetVehicles()
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
                            CMD.CommandText = "GetAllVehicle";
                            MySqlDataReader DR = CMD.ExecuteReader();
                            DataTable userTable = new DataTable("Vehicle");
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

        public Vehicle GetVehicles(int VehicleNumber)
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
                            CMD.CommandText = "GetVehicleById";
                            CMD.Parameters.AddWithValue("P_VehicleNumber", VehicleNumber);
                            MySqlDataReader DR = CMD.ExecuteReader();
                            DR.Read();
                            return new Vehicle
                            {
                                VehicleNumber = Convert.ToInt32(DR[0]),
                                VehicleType = DR[1].ToString(),
                                ChassisNumber = DR[2].ToString(),
                                EngineNumber = DR[3].ToString(),
                                ManufacturingYear = DR[4].ToString(),
                                LoadcarryingCapacity = Convert.ToInt32(DR[5]),
                                MakeOfVehicle = ((DR[6]).ToString()),
                                ModelNumber = DR[7].ToString(),
                                BodyType = DR[8].ToString(),
                                OrganizationName = DR[9].ToString(),
                                DeviceId = Convert.ToInt32(DR[10]),
                                UserId = Convert.ToInt32(DR[11])


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

        public int InsertVehicle(Vehicle vehicle)
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
                            CMD.CommandText = "InsertVehicle";
                            CMD.Parameters.AddWithValue("p_VehicleNumber", vehicle.VehicleNumber);
                            CMD.Parameters.AddWithValue("p_VehicleType", vehicle.VehicleType);
                            CMD.Parameters.AddWithValue("p_ChassisNumber", vehicle.ChassisNumber);
                            CMD.Parameters.AddWithValue("p_EngineNumber", vehicle.EngineNumber);
                            CMD.Parameters.AddWithValue("p_ManufacturingYear", vehicle.ManufacturingYear);
                            CMD.Parameters.AddWithValue("p_LoadcarryingCapacity", vehicle.LoadcarryingCapacity);
                            CMD.Parameters.AddWithValue("p_MakeOfVehicle", vehicle.MakeOfVehicle);
                            CMD.Parameters.AddWithValue("p_ModelNumber", vehicle.ModelNumber);
                            CMD.Parameters.AddWithValue("p_BodyType", vehicle.BodyType);
                            CMD.Parameters.AddWithValue("p_OrganizationName", vehicle.OrganizationName);
                            CMD.Parameters.AddWithValue("p_DeviceId", vehicle.DeviceId);
                            CMD.Parameters.AddWithValue("p_UserId", vehicle.UserId);


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

        public int UpdateVehicle(Vehicle vehicle)
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
                            CMD.CommandText = "UpdateVehicle";
                            CMD.Parameters.AddWithValue("p_VehicleNumber", vehicle.VehicleNumber);
                            CMD.Parameters.AddWithValue("p_VehicleType", vehicle.VehicleType);
                            CMD.Parameters.AddWithValue("p_ChassisNumber", vehicle.ChassisNumber);
                            CMD.Parameters.AddWithValue("p_EngineNumber", vehicle.ManufacturingYear);
                            CMD.Parameters.AddWithValue("p_LoadcarryingCapacity", vehicle.LoadcarryingCapacity);
                            CMD.Parameters.AddWithValue("p_MakeOfVehicle", vehicle.MakeOfVehicle);
                            CMD.Parameters.AddWithValue("p_ModelNumber", vehicle.ModelNumber);
                            CMD.Parameters.AddWithValue("p_BodyType", vehicle.BodyType);
                            CMD.Parameters.AddWithValue("p_OrganizationName", vehicle.OrganizationName);
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
            throw new NotImplementedException();
        }

        public int DeleteVehicle(int VehicleNumber)
        {
            throw new NotImplementedException();
        }
    }
}
