using UnityEngine;

namespace Player
{
    public class PlayerInput
    {
        public Vector3 GetMovementInput()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            return new Vector3(horizontal, 0, vertical).normalized;
        }
    }
}