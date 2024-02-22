using System;
using System.Collections;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        var competions = new List<List<string>>
        {
            new List<string> {"HTML","C#"},
            new List<string> {"C#","Python"},
            new List<string> {"Python","HTML"},
        };

        var result = new List<int> { 0, 0, 1 };
        string winner = SolutionTwo(competions, result);
        Console.WriteLine(result);
    }
    public static string SolutionTwo(List<List<string>> competitions, List<int> results)
    {
        //Temporal complexity = O(N) where N nb of games  
        //Spatial complexity = O(K) K nb of teams
        string currentBestTeam = "";
        int homeTeamWon = 1;
        var teamPoints = new Dictionary<string, int>();
        teamPoints.Add("", 0);

        for (int i = 0; i < competitions.Count; i++)
        {
            if (results[i] == homeTeamWon)
            {
                if (!teamPoints.ContainsKey(competitions[i][0]))
                    teamPoints.Add(competitions[i][0], 3);
                else
                    teamPoints[competitions[i][0]] += 3;
                if (teamPoints[competitions[i][0]] > teamPoints[currentBestTeam])
                    currentBestTeam = competitions[i][0];
            }
            else
            {
                if (!teamPoints.ContainsKey(competitions[i][1]))
                    teamPoints.Add(competitions[i][1], 3);
                else
                    teamPoints[competitions[i][1]] += 3;

                if (teamPoints[competitions[i][1]] > teamPoints[currentBestTeam])
                    currentBestTeam = competitions[i][1];
            }
        }
        return currentBestTeam;
    }

    public static string SolutionOne(List<List<string>> competitions, List<int> results)
    {
        //Temporal complexity = O(N+M) = O(N) where M nb of games N nb of teams  
        //Spatial complexity = O(K) K nb of teams
        var teamsPoints = new Dictionary<string, int>();
        int compNumberOfGames = results.Count;
        for (int i = 0; i < compNumberOfGames; i++)
        {
            if (results[i] == 1)
            {
                if (!teamsPoints.ContainsKey(competitions[i][0]))
                {
                    teamsPoints.Add(competitions[i][0], 3);

                    if (!teamsPoints.ContainsKey(competitions[i][1]))
                        teamsPoints.Add(competitions[i][1], 0);
                }
                else
                    teamsPoints[competitions[i][0]] += 3;
            }
            else
            {
                if (!teamsPoints.ContainsKey(competitions[i][1]))
                {
                    teamsPoints.Add(competitions[i][1], 3);
                    if (!teamsPoints.ContainsKey(competitions[i][0]))
                        teamsPoints.Add(competitions[i][0], 0);
                }
                else
                    teamsPoints[competitions[i][1]] += 3;
            }
        }

        int winnerPoints = 0;
        string winnerTeam = "";
        foreach (var teamPoint in teamsPoints)
        {
            if (winnerPoints <= teamPoint.Value)
            {
                winnerPoints = teamPoint.Value;
                winnerTeam = teamPoint.Key;
            }
        }

        return winnerTeam;
    }
}
