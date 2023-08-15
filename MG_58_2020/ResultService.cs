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
            list.Add(new ScoreResult
            {
                Id = 1,
                Ime = "Pera Peric",
                BrojPoteza = 30,
                Vreme = "00:30"
            });
            return list;
        }
    }
}