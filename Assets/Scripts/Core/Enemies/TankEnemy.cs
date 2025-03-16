using UnityEngine;

namespace Core.Enemies
{
    public class TankEnemy : BaseEnemy
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
            Debug.Log("TankEnemy атакует медленно, но сильно!");
        }
    }
}