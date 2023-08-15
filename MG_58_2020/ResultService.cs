using MG_58_2020.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MG_58_2020
{
    public class ResultService : IResultsService
    {
        public List<ScoreResult> GetResults(string podela, string slika)
        {
            SqlConnection connection = SingletonConnection.Instance.Connection;
            List<ScoreResult> list = new List<ScoreResult>();
            connection.Open();
            SqlCommand command = new SqlCommand(@"SELECT * FROM [dbo].[GET_SCORES](@podela,NULL)", connection);
            command.Parameters.AddWithValue("@podela", podela);
            SqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                list.Add(new ScoreResult
                {
                    Id = (int) reader["id"],
                    Ime = reader["ime"].ToString(),
                    BrojPoteza = (int)reader["broj_poteza"],
                    Vreme = reader["vreme"].ToString()
                });
            }
            connection.Close();
            return list;
        }

        public void InsertNewResult(CreateScoreResult createScoreResult)
        {
            SqlConnection connection = SingletonConnection.Instance.Connection;
            connection.Open();
            string query = @"INSERT INTO rezlutati(ime,broj_poteza,vreme,podela,slika)
            VALUES(@ime,@brojPoteza,@vreme,@podela," + (createScoreResult.Slika == string.Empty ? "NULL" : "@slika") + ")";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@podela", createScoreResult.Podela);
            command.Parameters.AddWithValue("@ime", createScoreResult.Ime);
            command.Parameters.AddWithValue("@brojPoteza", createScoreResult.BrojPoteza);
            command.Parameters.AddWithValue("@vreme", createScoreResult.Vreme);
            if (createScoreResult.Slika != string.Empty)
            {
                command.Parameters.AddWithValue("@slika", createScoreResult.Slika);
            }
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}