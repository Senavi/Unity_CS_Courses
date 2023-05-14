using Mirror;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject lobbyCreationPanel;
    public GameObject joinLobbyPanel;
    private NetworkManager networkManager;


    private void Start()
    {
        ShowMainMenu();
        networkManager = GameObject.FindObjectOfType<NetworkManager>();
    }

    public void ShowMainMenu()
    {
        mainMenu.SetActive(true);
        lobbyCreationPanel.SetActive(false);
        joinLobbyPanel.SetActive(false);
    }

    public void ShowLobbyCreationPanel()
    {
        mainMenu.SetActive(false);
        lobbyCreationPanel.SetActive(true);
        joinLobbyPanel.SetActive(false);
    }

    public void ShowJoinLobbyPanel()
    {
        mainMenu.SetActive(false);
        lobbyCreationPanel.SetActive(false);
        joinLobbyPanel.SetActive(true);
    }

    public void CreateLobby()
    {
        // Here, you can get the values from your input fields (like the lobby name and password)
        // and do whatever you want with them.

        // Then, start the host:
        NetworkManager.singleton.StartHost();
    }

    public void JoinLobby()
    {
        // Input validation for lobby name, player name, and password...

        NetworkManager.singleton.networkAddress = "localhost"; // Replace with the actual server address
        NetworkManager.singleton.StartClient();
    }



}
