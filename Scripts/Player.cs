using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;            // The player's movement speed
    public int startingHealth = 100;   // The player's starting health

    private int currentHealth;         // The player's current health

    private void Start()
    {
        // Set the player's starting health
        currentHealth = startingHealth;
    }

    private void Update()
    {
        // Get input from the horizontal and vertical axes
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the movement vector
        Vector2 movement = new Vector2(horizontalInput, verticalInput).normalized * speed * Time.deltaTime;

        // Move the player
        transform.position += new Vector3(movement.x, movement.y, 0);
    }

    // Function to take damage and update health UI
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // TODO: Update health UI element here
    }
}
