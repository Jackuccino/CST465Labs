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
    public class TreaterDBRepository : ITreaterRepository
    {
        public string GetConnectionString()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            var configuration = builder.Build();

            return configuration.GetConnectionString("DB_Halloween");
        }

        public List<Treater> GetList()
        {
            List<Treater> treaterList = new List<Treater>();
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("Treaters_GetList", connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Treater treater = new Treater
                            {
                                Id = (int)reader["Id"],
                                Name = reader["Name"].ToString(),
                                FavoriteCandyID = (int)reader["FavoriteCandyID"],
                                CostumeID = (int)reader["CostumeID"]
                            };
                            treaterList.Add(treater);
                        }
                    }
                }
            }
            return treaterList;
        }

        public void Insert(Treater treater)
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("Treaters_Insert", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    command.Parameters.AddWithValue("@Name", treater.Name);
                    command.Parameters.AddWithValue("@FavoriteCandyID", treater.FavoriteCandyID);
                    command.Parameters.AddWithValue("@CostumeID", treater.CostumeID);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
