using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        public CharacterController characterController;

        public float moveSpeed = 4.0f; //The f at the end of the number says it is a floating-point number

        public float rotateSpeed = 1.5f;

        public Animator animator;

      
        // Start is called before the first frame update
        private void Start()
        {
            Debug.Log("Player started");
            characterController = GetComponent<CharacterController>();
            animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        private void Update()
        {
            var speed = Input.GetAxis("Vertical");
            // Rotate around y-axis
            transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);


            if (speed != 0) // Is moving
            {
                animator.SetBool("forward", true);
            }
            else // Idle
            {
                animator.SetBool("forward", false);
            }
            // Forward is the forward direction for this character
            var forward = transform.TransformDirection(Vector3.forward);

            characterController.SimpleMove(forward * speed * moveSpeed);
        }
        
    }
}