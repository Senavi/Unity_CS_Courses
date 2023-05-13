using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    private FoodSpawner foodSpawner;

    private TextMeshProUGUI playerNameText;
    private Renderer playerRenderer;
    private LeaderboardManager leaderboardManager;
    private string uniqueID;  // Add this line to store the unique ID

    // Start is called before the first frame update
    void Start()
    {
        leaderboardManager = FindObjectOfType<LeaderboardManager>();
        // Find the PlayerName TextMeshProUGUI component
        playerNameText = GetComponentInChildren<TextMeshProUGUI>();
        playerRenderer = GetComponent<Renderer>();

        // Set the player's name and color
        if (playerNameText != null)
        {
            playerNameText.text = StartMenuController.playerName;
        }

        if (playerRenderer != null)
        {
            playerRenderer.material.color = StartMenuController.playerColor;
        }

        foodSpawner = GameObject.FindObjectOfType<FoodSpawner>();

        // Create a PlayerData object for this player
        uniqueID = System.Guid.NewGuid().ToString();  // Save the unique ID
        PlayerData playerData = new PlayerData(uniqueID, StartMenuController.playerName, 0, StartMenuController.playerName);

        // Add the player's data to the leaderboard
        leaderboardManager.AddPlayerData(playerData);
    }


    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        float xValue = Input.GetAxis("Horizontal");
        float zValue = Input.GetAxis("Vertical");

        // Get the direction that the camera is facing
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 moveDirection = zValue * cameraForward + xValue * Camera.main.transform.right;

        // Move the player in the direction that the camera is facing
        transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);

        // Make the player face the direction of movement
        if (moveDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, speed * Time.deltaTime);
        }
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Food"))
        {
            transform.localScale += other.transform.localScale * 0.1f;
            Destroy(other.gameObject);
            foodSpawner.SpawnFood();

            // Update the score
            leaderboardManager.UpdatePlayerScore(uniqueID, 1);  // Use uniqueID instead of playerName
        }
        else if (other.gameObject.CompareTag("AI"))
        {
            if (transform.localScale.magnitude > other.transform.localScale.magnitude)
            {
                transform.localScale += other.transform.localScale * 0.5f;
                Destroy(other.gameObject);

                // Update the score
                leaderboardManager.UpdatePlayerScore(uniqueID, 5);  // Use uniqueID instead of playerName
            }
        }
    }

}
