using System.Collections.Generic;
using UnityEngine;

public class LeaderboardManager : MonoBehaviour
{
    public Dictionary<string, PlayerData> playerScores = new Dictionary<string, PlayerData>();

    public void AddPlayerData(PlayerData playerData)
    {
        if (playerScores.ContainsKey(playerData.uniqueID))
        {
            playerScores[playerData.uniqueID].score = playerData.score;
        }
        else
        {
            playerScores.Add(playerData.uniqueID, playerData);
        }
    }

    public void UpdatePlayerScore(string uniqueID, int scoreIncrement)
    {
        if (playerScores.ContainsKey(uniqueID))
        {
            playerScores[uniqueID].score += scoreIncrement;
            FindObjectOfType<LeaderboardDisplay>().UpdateLeaderboardDisplay();  // Update the display
        }
    }

    public List<PlayerData> GetTopPlayers(int topCount)
    {
        // Transform the dictionary values to a list and sort it
        List<PlayerData> sortedList = new List<PlayerData>(playerScores.Values);
        sortedList.Sort((a, b) => b.score.CompareTo(a.score));
        return sortedList.GetRange(0, Mathf.Min(topCount, sortedList.Count));
    }

    public List<PlayerData> GetPlayerScores()
    {
        // Transform the dictionary values to a list
        return new List<PlayerData>(playerScores.Values);
    }
}
