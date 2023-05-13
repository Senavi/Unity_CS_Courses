[System.Serializable]
public class PlayerData
{
    public string uniqueID;  // Unique ID for each player and AI
    public string playerName;
    public int score;
    public string displayName;  // User-friendly name for display in the UI

    public PlayerData(string _uniqueID, string _playerName, int _score, string _displayName)
    {
        uniqueID = _uniqueID;
        playerName = _playerName;
        score = _score;
        displayName = _displayName;  // Assign the display name
    }
}
