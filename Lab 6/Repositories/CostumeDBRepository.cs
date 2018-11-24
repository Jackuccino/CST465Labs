using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Lab_5.Models;
using Microsoft.Extensions.Configuration;

namespace Lab_5.Repositories
{
    public class CostumeDBRepository : ICostumeRepository
    {
        public string GetConnectionString()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            var configuration = builder.Build();

            return configuration.GetConnectionString("DB_Halloween");
        }

        public List<Costume> GetList()
        {
            List<Costume> costumeList = new List<Costume>();
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("Costumes_GetList", connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Costume costume = new Costume
                            {
                                Id = (int)reader["Id"],
                                CostumeName = reader["Costume"].ToString()
                            };
                            costumeList.Add(costume);
                        }
                    }
                }
            }
            return costumeList;
        }

        public void Insert(string name)
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("Costumes_Insert", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    command.Parameters.AddWithValue("@Costume", name);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("Costumes_Delete", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    command.Parameters.AddWithValue("@Id", id);
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        // Popup window maybe?
                    }
                }
            }
        }
    }
}
