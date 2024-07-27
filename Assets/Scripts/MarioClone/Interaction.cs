
    
    using UnityEngine;

    public class Interaction : MonoBehaviour
    {
        public GameObject starPrefab;
        public Transform starPosition;
        private bool isCollected = false;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") && !isCollected)
            {
                CollectStar();
            }
        }

        private void CollectStar()
        {
            isCollected = true;
            Instantiate(starPrefab, starPosition.position, starPosition.rotation);
            GameManager.Instance.CollectStar();
        }
    }
