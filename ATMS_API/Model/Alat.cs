using System;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace ATMS_API.Models
{
    public class Alat
    {
        // alamat koneksi database
        private readonly string _connectionString;

        // koneksi Sql
        private readonly SqlConnection _connection;

        // constructor kelas yang akan kita gunakan untuk mengsetup connection string
        public Alat(IConfiguration configuration)
        {
            // mengambil konfigurasi connection string dari appsettings.json
            _connectionString = configuration.GetConnectionString("DefaultConnection");

            // koneksi sql menggunakan connection string
            _connection = new SqlConnection(_connectionString);
        }

        // menambahkan method untuk melakukan CRUD
        public List<AlatModel> GetAllData()
        {
            List<AlatModel> alatList = new List<AlatModel>();
            try
            {
                string query = "select * from atm_msalat";
                using SqlCommand command = new SqlCommand(query, _connection);
                _connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    AlatModel alat = new AlatModel
                    {
                        id = Convert.ToInt32(reader["ala_id"]),
                        jen_id = Convert.ToInt32(reader["jen_id"]),
                        ala_nama = reader["ala_nama"].ToString(),
                        ala_tanggal = Convert.ToDateTime(reader["ala_tanggal"]),
                        ala_jmlmasuk = Convert.ToInt32(reader["ala_jmlmasuk"]),
                        ala_jmlkeluar = Convert.ToInt32(reader["ala_jmlkeluar"]),
                        ala_sisaalat = Convert.ToInt32(reader["ala_sisaalat"]),
                        ala_status = Convert.ToInt32(reader["ala_status"]),
                        ala_created_by = reader["ala_created_by"].ToString(),
                        ala_created_date = Convert.ToDateTime(reader["ala_created_date"]),
                        ala_modified_by = reader["ala_modified_by"].ToString(),
                        ala_modified_date = Convert.ToDateTime(reader["ala_modified_date"])
                    };
                    alatList.Add(alat);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                _connection.Close();
            }
            return alatList;
        }

        public AlatModel GetData(int id)
        {
            AlatModel alatModel = new AlatModel();
            try
            {
                string query = "select * from atm_msalat where ala_id = @p1";
                using SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@p1", id);
                _connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    alatModel.id = Convert.ToInt32(reader["ala_id"]);
                    alatModel.jen_id = Convert.ToInt32(reader["jen_id"]);
                    alatModel.ala_nama = reader["ala_nama"].ToString();
                    alatModel.ala_tanggal = Convert.ToDateTime(reader["ala_tanggal"]);
                    alatModel.ala_jmlmasuk = Convert.ToInt32(reader["ala_jmlmasuk"]);
                    alatModel.ala_jmlkeluar = Convert.ToInt32(reader["ala_jmlkeluar"]);
                    alatModel.ala_sisaalat = Convert.ToInt32(reader["ala_sisaalat"]);
                    alatModel.ala_status = Convert.ToInt32(reader["ala_status"]);
                    alatModel.ala_created_by = reader["ala_created_by"].ToString();
                    alatModel.ala_created_date = Convert.ToDateTime(reader["ala_created_date"]);
                    alatModel.ala_modified_by = reader["ala_modified_by"].ToString();
                    alatModel.ala_modified_date = Convert.ToDateTime(reader["ala_modified_date"]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                _connection.Close();
            }
            return alatModel;
        }

        public void InsertData(AlatModel alatModel)
        {
            try
            {
                string query = "insert into atm_msalat values(@p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10, @p11)";
                using SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@p1", alatModel.jen_id);
                command.Parameters.AddWithValue("@p2", alatModel.ala_nama);
                command.Parameters.AddWithValue("@p3", alatModel.ala_tanggal);
                command.Parameters.AddWithValue("@p4", alatModel.ala_jmlmasuk);
                command.Parameters.AddWithValue("@p5", alatModel.ala_jmlkeluar);
                command.Parameters.AddWithValue("@p6", alatModel.ala_sisaalat);
                command.Parameters.AddWithValue("@p7", alatModel.ala_status);
                command.Parameters.AddWithValue("@p8", alatModel.ala_created_by);
                command.Parameters.AddWithValue("@p9", alatModel.ala_created_date);
                command.Parameters.AddWithValue("@p10", alatModel.ala_modified_by);
                command.Parameters.AddWithValue("@p11", alatModel.ala_modified_date);

                _connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in InsertData: {ex.Message}");
                throw; // Rethrow the exception to propagate it to the caller
            }
            finally
            {
                _connection.Close();
            }
        }


        public void UpdateData(AlatModel alatModel)
        {
            try
            {
                string query = "Update atm_msalat " +
                    "set ala_nama = @p2, jen_id = @p3, ala_tanggal = @p4, ala_jmlmasuk = @p5, ala_jmlkeluar = @p6, ala_sisaalat = @p7, ala_status = @p8, ala_created_by = @p9, ala_created_date = @p10, ala_modified_by = @p11, ala_modified_date = @p12 " +
                    "where ala_id = @p1";

                using SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@p1", alatModel.id);
                command.Parameters.AddWithValue("@p2", alatModel.jen_id);
                command.Parameters.AddWithValue("@p3", alatModel.ala_nama);
                command.Parameters.AddWithValue("@p4", alatModel.ala_tanggal);
                command.Parameters.AddWithValue("@p5", alatModel.ala_jmlmasuk);
                command.Parameters.AddWithValue("@p6", alatModel.ala_jmlkeluar);
                command.Parameters.AddWithValue("@p7", alatModel.ala_sisaalat);
                command.Parameters.AddWithValue("@p8", alatModel.ala_status);
                command.Parameters.AddWithValue("@p9", alatModel.ala_created_by);
                command.Parameters.AddWithValue("@p10", alatModel.ala_created_date);
                command.Parameters.AddWithValue("@p11", alatModel.ala_modified_by);
                command.Parameters.AddWithValue("@p12", alatModel.ala_modified_date);

                _connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                _connection.Close();
            }
        }

        public void DeleteData(int id)
        {
            try
            {
                string query = "delete from atm_msalat where ala_id = @p1";
                using SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@p1", id);

                _connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                _connection.Close();
            }
        }
    }
}
