using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AIPlayerControl : MonoBehaviour
{
    private LeaderboardManager leaderboardManager;
    private FoodSpawner foodSpawner;
    [SerializeField] private float speed = 1f;
    private Vector3 targetPosition;
    private float perceptionRadius = 10f; // The radius within which the AI player can perceive food

    private float foodCheckCooldown = 5f; // Cooldown time in seconds
    private float foodCheckTimer; // Timer to keep track of cooldown
    private bool isTargetingFood;
    public string uniqueID;  // Unique ID for tracking score
    public string displayName;  // User-friendly name for display in the UI

    private static int aiCounter = 0;  // Counter for all AI players

    void Start()
    {
        leaderboardManager = FindObjectOfType<LeaderboardManager>();
        foodSpawner = GameObject.FindObjectOfType<FoodSpawner>();
        targetPosition = NewTargetPosition();
        foodCheckTimer = foodCheckCooldown; // Initialize the timer

        // Generate a unique ID for this AI
        uniqueID = System.Guid.NewGuid().ToString();

        // Create a PlayerData object for this AI
        PlayerData aiData = new PlayerData(uniqueID, "AI", 0, "AI " + uniqueID.Substring(0, 5));  // Use the first 5 characters of the uniqueID for the display name

        // Add the AI's data to the leaderboard
        leaderboardManager.AddPlayerData(aiData);
    }


    void Update()
    {
        foodCheckTimer -= Time.deltaTime; // Decrease the timer

        if (foodCheckTimer <= 0) // If the timer has run out...
        {
            CheckForFood(); // Check for food
            foodCheckTimer = foodCheckCooldown; // Reset the timer
        }

        CheckForPlayer();
        MoveTowardsTarget();

        // Draw a line from the AI player to its target position
        Debug.DrawLine(transform.position, targetPosition, Color.red);

        // Draw the perception radius around the AI player
        Debug.DrawRay(transform.position, Vector3.right * perceptionRadius, Color.blue);
        Debug.DrawRay(transform.position, -Vector3.right * perceptionRadius, Color.blue);
        Debug.DrawRay(transform.position, Vector3.forward * perceptionRadius, Color.blue);
        Debug.DrawRay(transform.position, -Vector3.forward * perceptionRadius, Color.blue);
    }

    private void CheckForFood()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, perceptionRadius);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.CompareTag("Food") && hitCollider.transform.localScale.magnitude <= transform.localScale.magnitude)
            {
                targetPosition = hitCollider.transform.position;
                isTargetingFood = true;  // Set flag to true
                return;
            }
        }
        isTargetingFood = false;  // If no food is targeted, set flag to false
    }


    private void MoveTowardsTarget()
    {
        Vector3 direction = targetPosition - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime);

        if (!isTargetingFood && Vector3.Distance(transform.position, targetPosition) < 1f)
        {
            targetPosition = NewTargetPosition();
        }
    }


    private void CheckForPlayer()
    {
        RaycastHit hit;
        PlayerControl player = FindObjectOfType<PlayerControl>();
        if (player == null) return; // Return if no player is found

        Vector3 directionToPlayer = (player.transform.position - transform.position).normalized;

        if (Physics.Raycast(transform.position, directionToPlayer, out hit, perceptionRadius))
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                if (hit.collider.transform.localScale.magnitude < transform.localScale.magnitude)
                {
                    // Chase the player if they are smaller
                    targetPosition = hit.collider.transform.position;
                }
                else
                {
                    // Run away from the player if they are bigger
                    targetPosition = transform.position - directionToPlayer * perceptionRadius;
                }
            }
        }
    }
    private Vector3 NewTargetPosition()
    {
        // Find the ground object
        GameObject ground = GameObject.FindWithTag("Ground");

        // Get the size of the ground object
        Vector3 groundSize = ground.GetComponent<Renderer>().bounds.size;

        // Generate a random position within the ground's dimensions
        float x = Random.Range(-groundSize.x / 2, groundSize.x / 2);
        float y = 1f; // Adjust this value as per your need
        float z = Random.Range(-groundSize.z / 2, groundSize.z / 2);

        // Return the new random position
        return new Vector3(x, y, z);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Food"))
        {
            if (other.transform.localScale.magnitude <= transform.localScale.magnitude)
            {
                transform.localScale += other.transform.localScale * 0.1f;
                leaderboardManager.UpdatePlayerScore(uniqueID, 1); // Update the score before destroying the food
                Destroy(other.gameObject);
                foodSpawner.SpawnFood();
                isTargetingFood = false;  // Set flag to false after eating food
                targetPosition = NewTargetPosition();
            }
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            if (other.transform.localScale.magnitude < transform.localScale.magnitude)
            {
                transform.localScale += other.transform.localScale * 0.5f;
                leaderboardManager.UpdatePlayerScore(uniqueID, 5); // Update the score before destroying the player
                Destroy(other.gameObject);
                SceneManager.LoadScene("StartScene");

                // Update the target position to a new random position after eating the player
                targetPosition = NewTargetPosition();
            }
        }
        else if (other.gameObject.CompareTag("AI"))
        {
            if (other.transform.localScale.magnitude < transform.localScale.magnitude)
            {
                transform.localScale += other.transform.localScale * 0.5f;
                leaderboardManager.UpdatePlayerScore(uniqueID, 5); // Update the score before destroying the AI
                Destroy(other.gameObject);

                // Update the target position to a new random position after eating the player
                targetPosition = NewTargetPosition();
            }
        }
    }


}
