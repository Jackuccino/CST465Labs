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
    public class MatchDBRepository : IMatchDBRepository
    {
        public IConfiguration _Configuration;

        public MatchDBRepository(IConfiguration configuration)
        {
            _Configuration = configuration;
        }

        public virtual async Task<List<Match>> GetMatchesAsync()
        {
            List<Match> matchList = new List<Match>();
            using (SqlConnection connection = new SqlConnection(_Configuration["LoginContextConnection"]))
            {
                using (SqlCommand command = new SqlCommand("Match_GetMatches", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    await connection.OpenAsync();
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            Match match = new Match
                            {
                                Id = (int)reader["ID"],
                                HomeTeamId = (int)reader["HomeTeamId"],
                                HomeGoals = (int)reader["HomeGoals"],
                                AwayTeamId = (int)reader["AwayTeamId"],
                                AwayGoals = (int)reader["AwayGoals"],
                                MatchDate = reader["MatchDate"].ToString(),
                                MatchTime = reader["MatchTime"].ToString(),
                                MatchDayNumber = (int)reader["MatchDayNumber"]
                            };
                            matchList.Add(match);
                        }
                    }
                }
            }
            return matchList;
        }

        public virtual async void Insert(Match match)
        {
            using (SqlConnection connection = new SqlConnection(_Configuration["LoginContextConnection"]))
            {
                using (SqlCommand command = new SqlCommand("Match_InsertUpdate", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    await connection.OpenAsync();
                    if (match.Id != 0)
                    {
                        command.Parameters.AddWithValue("@ID", match.Id);
                    }
                    command.Parameters.AddWithValue("@HomeTeamId", match.HomeTeamId);
                    command.Parameters.AddWithValue("@HomeGoals", match.HomeGoals);
                    command.Parameters.AddWithValue("@AwayTeamId", match.AwayTeamId);
                    command.Parameters.AddWithValue("@AwayGoals", match.AwayGoals);
                    command.Parameters.AddWithValue("@MatchDate", match.MatchDate);
                    command.Parameters.AddWithValue("@MatchTime", match.MatchTime);
                    command.Parameters.AddWithValue("@MatchDayNumber", match.MatchDayNumber);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public virtual async void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(_Configuration["LoginContextConnection"]))
            {
                using (SqlCommand command = new SqlCommand("Match_Delete", connection))
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
