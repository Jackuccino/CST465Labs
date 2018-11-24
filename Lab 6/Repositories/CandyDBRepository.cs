using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Lab_5.Models;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace Lab_5.Repositories
{
    public class CandyDBRepository : ICandyRepository
    {
        public string GetConnectionString()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            var configuration = builder.Build();

            return configuration.GetConnectionString("DB_Halloween");
        }

        public List<Candy> GetList()
        {
            List<Candy> candyList = new List<Candy>();
            string connString = GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connString))
            {
                using (SqlCommand command = new SqlCommand("Candy_GetList", connection))
                {                    
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Candy candy = new Candy
                            {
                                Id = (int)reader["Id"],
                                ProductName = reader["ProductName"].ToString()
                            };
                            candyList.Add(candy);
                        }
                    }
                }
            }
            return candyList;
        }

        public void Insert(string name)
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("Candy_Insert", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    command.Parameters.AddWithValue("@ProductName", name);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("Candy_Delete", connection))
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
