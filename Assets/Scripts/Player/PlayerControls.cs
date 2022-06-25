using UnityEngine;

namespace FarmValley.Player
{
    public class PlayerControls : MonoBehaviour
    {
        public float moveSpeed = 5f;

        public Rigidbody2D rb;

        Vector2 movement;

        private void Update()
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
        }

        private void FixedUpdate()
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
    }
}