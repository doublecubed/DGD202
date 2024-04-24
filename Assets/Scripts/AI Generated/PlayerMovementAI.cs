using UnityEngine;

public class PlayerMovementAI : MonoBehaviour
{
    public float speed = 5.0f;  // Speed of the character's movement

    void Update()
    {
        // Get input from keyboard
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Create movement vector
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // Apply the movement to the character's position
        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }
}