using UnityEngine;

namespace Core.Enemies
{
    public class FastEnemy : BaseEnemy
    {
        public override void Move()
        {
            if (player != null)
            {
                transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
        }

        public override void Attack()
        {
            Debug.Log("FastEnemy атакует быстро, но слабо!");
        }
    }
}