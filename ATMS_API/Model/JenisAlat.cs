using System;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace ATMS_API.Models
{
    public class JenisAlat
    {
        // alamat koneksi database
        private readonly string _connectionString;

        //koneksi Sql
        private readonly SqlConnection _connection;

        // constructor kelas yang akan kita gunakan untuk mengsetup connection string
        public JenisAlat (IConfiguration configuration)
        {
            // mengambil konfigurasi connection string dari appsettings.json
            _connectionString = configuration.GetConnectionString("DefaultConnection");

            // koneksi sql menggunakan connection string
            _connection = new SqlConnection(_connectionString);
        }

        // menambahkan method untuk melakukan CRUD
        public List<JenisAlatModel> getAllData()
        {
            List<JenisAlatModel> jenisalatList = new List<JenisAlatModel>();
            try
            {
                string query = "select * from ATM_msjenisalat";
                SqlCommand command = new SqlCommand(query, _connection);
                _connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    JenisAlatModel buku = new JenisAlatModel
                    {
                        id = Convert.ToInt32(reader["jen_id"].ToString()),
                        jen_nama = reader["jen_nama"].ToString(),
                       
                    };
                    jenisalatList.Add(buku);
                }
                reader.Close();
                _connection.Close();
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return jenisalatList;
        }
        public JenisAlatModel getData(int id)
        {
            JenisAlatModel jenisalatModel = new JenisAlatModel();
            try
            {
                string query = "select * from ATM_msjenisalat where jen_id = @p1";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@p1", id);
                _connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                jenisalatModel.id = Convert.ToInt32(reader["jen_id"].ToString());
                jenisalatModel.jen_nama = reader["jen_nama"].ToString();
              
                reader.Close();
                _connection.Close();
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return jenisalatModel;
        }
     
        public void insertData(JenisAlatModel jenisalatModel)
        {
            try
            {          
                string query = "insert into ATM_msjenisalat values(@p1)";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@p1", jenisalatModel.jen_nama);
              
                _connection.Open();
                command.ExecuteNonQuery();
                _connection.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void updateData(JenisAlatModel jenisalatModel)
        {
            try
            {
                Console.WriteLine("@p1");

                string query = "Update ATM_msjenisalat " +
                    "set jen_nama = @p2" +
                    " where jen_id = @p1";
                using SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@p1", jenisalatModel.id);
                command.Parameters.AddWithValue("@p2", jenisalatModel.jen_nama);

                _connection.Open();
                command.ExecuteNonQuery();
                _connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void deleteData(int id)
        {
            try
            {
                string query = "delete from ATM_msjenisalat where jen_id = @p1";
                using SqlCommand command = new SqlCommand(query, _connection);

                command.Parameters.AddWithValue("@p1", id);
                _connection.Open();
                command.ExecuteNonQuery();
                _connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
