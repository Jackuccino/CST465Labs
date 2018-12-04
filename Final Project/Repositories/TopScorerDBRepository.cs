using FinalProject.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Repositories
{
    public class TopScorerDBRepository : ITopScorerDBRepository
    {
        public IConfiguration _Configuration;

        public TopScorerDBRepository(IConfiguration configuration)
        {
            _Configuration = configuration;
        }

        public virtual async Task<List<Player>> GetPlayersAsync()
        {
            List<Player> playerList = new List<Player>();
            using (SqlConnection connection = new SqlConnection(_Configuration["LoginContextConnection"]))
            {
                using (SqlCommand command = new SqlCommand("Player_GetPlayers", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    await connection.OpenAsync();
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            Player player = new Player
                            {
                                Id = (int)reader["ID"],
                                Name = reader["Name"].ToString(),
                                Position = reader["Position"].ToString(),
                                Nationality = reader["Nationality"].ToString(),
                                JerseyNumber = (int)reader["JerseyNumber"],
                                GoalScored = (int)reader["GoalScored"],
                                TeamId = (int)reader["TeamId"]
                            };
                            playerList.Add(player);
                        }
                    }
                }
            }
            return playerList;
        }

        public virtual async Task<Player> GetPlayerAsync(int id)
        {
            Player player = null;
            using (SqlConnection connection = new SqlConnection(_Configuration["LoginContextConnection"]))
            {
                using (SqlCommand command = new SqlCommand("Player_GetPlayer", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID", id);
                    await connection.OpenAsync();
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (reader.Read())
                        {
                            player = new Player
                            {
                                Id = (int)reader["ID"],
                                Name = reader["Name"].ToString(),
                                Position = reader["Position"].ToString(),
                                Nationality = reader["Nationality"].ToString(),
                                JerseyNumber = (int)reader["JerseyNumber"],
                                GoalScored = (int)reader["GoalScored"],
                                TeamId = (int)reader["TeamId"]
                            };
                        }
                    }
                }
            }
            return player;
        }

        public virtual async void Insert(Player player)
        {
            using (SqlConnection connection = new SqlConnection(_Configuration["LoginContextConnection"]))
            {
                using (SqlCommand command = new SqlCommand("Player_InsertUpdate", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    await connection.OpenAsync();
                    if (player.Id != 0)
                    {
                        command.Parameters.AddWithValue("@ID", player.Id);
                    }
                    command.Parameters.AddWithValue("@Name", player.Name);
                    command.Parameters.AddWithValue("@Position", player.Position);
                    command.Parameters.AddWithValue("@Nationality", player.Nationality);
                    command.Parameters.AddWithValue("@JerseyNumber", player.JerseyNumber);
                    command.Parameters.AddWithValue("@GoalScored", player.GoalScored);
                    command.Parameters.AddWithValue("@TeamId", player.TeamId);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public virtual async void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(_Configuration["LoginContextConnection"]))
            {
                using (SqlCommand command = new SqlCommand("Player_Delete", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    await connection.OpenAsync();
                    command.Parameters.AddWithValue("@ID", id);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
