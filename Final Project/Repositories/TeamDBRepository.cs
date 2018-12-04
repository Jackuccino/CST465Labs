using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Models;
using Microsoft.Extensions.Configuration;

namespace FinalProject.Repositories
{
    public class TeamDBRepository : ITeamDBRepository
    {
        public IConfiguration _Configuration;

        public TeamDBRepository(IConfiguration configuration)
        {
            _Configuration = configuration;
        }

        public virtual async Task<List<Team>> GetTeamsAsync()
        {
            List<Team> teamList = new List<Team>();
            using (SqlConnection connection = new SqlConnection(_Configuration["LoginContextConnection"]))
            {
                using (SqlCommand command = new SqlCommand("Team_GetTeams", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    await connection.OpenAsync();
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            Team team = new Team
                            {
                                Id = (int)reader["ID"],
                                TeamName = reader["TeamName"].ToString(),
                                Badge = reader["Badge"].ToString(),
                                Wins = (int)reader["Wins"],
                                Draws = (int)reader["Draws"],
                                Loses = (int)reader["Loses"],
                                GoalsFor = (int)reader["GoalsFor"],
                                GoalsAgainst = (int)reader["GoalsAgainst"],
                                Group = reader["Group"].ToString()[0]
                            };
                            teamList.Add(team);
                        }
                    }
                }
            }
            return teamList;
        }

        public virtual async Task<Team> GetTeamAsync(int id)
        {
            Team team = null;
            using (SqlConnection connection = new SqlConnection(_Configuration["LoginContextConnection"]))
            {
                using (SqlCommand command = new SqlCommand("Team_GetTeam", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID", id);
                    await connection.OpenAsync();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            team = new Team
                            {
                                Id = (int)reader["ID"],
                                TeamName = reader["TeamName"].ToString(),
                                Badge = reader["Badge"].ToString(),
                                Wins = (int)reader["Wins"],
                                Draws = (int)reader["Draws"],
                                Loses = (int)reader["Loses"],
                                GoalsFor = (int)reader["GoalsFor"],
                                GoalsAgainst = (int)reader["GoalsAgainst"],
                                Group = reader["Group"].ToString()[0]
                            };
                        }
                    }
                }
            }
            return team;
        }

        public virtual async void Insert(Team team)
        {
            using (SqlConnection connection = new SqlConnection(_Configuration["LoginContextConnection"]))
            {
                using (SqlCommand command = new SqlCommand("Team_InsertUpdate", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    await connection.OpenAsync();
                    if (team.Id != 0)
                    {
                        command.Parameters.AddWithValue("@ID", team.Id);
                    }
                    command.Parameters.AddWithValue("@TeamName", team.TeamName);
                    if (team.Badge != null)
                    {
                        command.Parameters.AddWithValue("@Badge", team.Badge);
                    }
                    command.Parameters.AddWithValue("@Wins", team.Wins);
                    command.Parameters.AddWithValue("@Draws", team.Draws);
                    command.Parameters.AddWithValue("@Loses", team.Loses);
                    command.Parameters.AddWithValue("@GoalsFor", team.GoalsFor);
                    command.Parameters.AddWithValue("@GoalsAgainst", team.GoalsAgainst);
                    command.Parameters.AddWithValue("@Group", team.Group);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public virtual async void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(_Configuration["LoginContextConnection"]))
            {
                using (SqlCommand command = new SqlCommand("Team_Delete", connection))
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
