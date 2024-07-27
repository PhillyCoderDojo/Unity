using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour
{
    public float spinSpeed = 0.5f;
    public AudioClip collectSound;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * spinSpeed); // Rotate about the y (up) axis
    }

    void OnTriggerEnter(Collider other)
    {
        // Check the tag of the colliding object
        if (other.CompareTag("Player"))
        {
            StarPlayer player = other.gameObject.GetComponent<StarPlayer>();
            if (player != null)
            {
                player.stars += 1; // Increase by 1
                GameManager.Instance.CollectStar(); // Notify GameManager
                GameManager.Instance.ShowStarCollectedMessage(); // Display message
            }
            AudioSource.PlayClipAtPoint(collectSound, transform.position);
            gameObject.SetActive(false);
        }
    }
}