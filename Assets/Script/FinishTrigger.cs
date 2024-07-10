using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    // Reference to the PlayerController script
    private PlayerController playerController;

    private void Start()
    {
        // Find the player and get the PlayerController component
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerController = player.GetComponent<PlayerController>();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Call the method to handle finish on the player controller
            if (playerController != null)
            {
                playerController.HandleFinish();
            }
        }
    }
}
