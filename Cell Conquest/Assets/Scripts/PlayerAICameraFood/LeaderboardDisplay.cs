using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
using System.Linq;

public class LeaderboardDisplay : MonoBehaviour
{
    public LeaderboardManager leaderboardManager;
    public TextMeshProUGUI leaderboardText;

    void Update()
    {
        UpdateLeaderboardDisplay();
    }

    public void UpdateLeaderboardDisplay()
    {
        // Sort the player scores
        var sortedScores = leaderboardManager.GetPlayerScores().OrderByDescending(player => player.score).Take(5).ToList();

        // Clear the existing text
        leaderboardText.text = "Leaderboard:\n";

        // Add each player's score to the text
        foreach (var playerData in sortedScores)
        {
            leaderboardText.text += playerData.displayName + ": " + playerData.score + "\n";  // Use displayName instead of playerName
        }
    }
}
