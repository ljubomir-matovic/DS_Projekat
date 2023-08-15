using MG_58_2020.Models;
using System.Collections.Generic;

namespace MG_58_2020
{
    public interface IResultsService
    {
        List<ScoreResult> GetResults(string podela, string slika);
        void InsertNewResult(CreateScoreResult createScoreResult);
    }
}