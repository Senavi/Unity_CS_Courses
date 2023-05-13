using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class StartMenuController : MonoBehaviour
{
    [SerializeField] public TMP_InputField nameInputField; // Changed from InputField to TMP_InputField
    [SerializeField] public TMP_Dropdown colorDropdown; // Changed from Dropdown to TMP_Dropdown
    [SerializeField] public Button startButton;


    public static string playerName;
    public static Color playerColor;

    void Start()
    {
        startButton.onClick.AddListener(StartGame);
    }

    void Update()
    {
        playerName = nameInputField.text;
        playerColor = GetColorFromDropdown(); // Implement this function based on your color picker UI
    }

    void StartGame()
    {
        // Assuming your main game scene is named "GameScene"
        SceneManager.LoadScene("GameScene");
    }

    private Color GetColorFromDropdown()
    {
        // Assuming your dropdown has options like "Red", "Blue", "Green", etc.
        string colorName = colorDropdown.options[colorDropdown.value].text;

        switch (colorName)
        {
            case "Red":
                return Color.red;
            case "Blue":
                return Color.blue;
            case "Green":
                return Color.green;
            case "Yellow":
                return Color.yellow;
            case "White":
                return Color.white;
            case "Black":
                return Color.black;
            default:
                // Return a default color if the colorName does not match any case
                return Color.white;
        }
    }

}
