using UnityEngine;

namespace Core.Enemies
{
    public class FastEnemy : BaseEnemy
    {
        public override void Move()
        {
            if (_target != null)
            {
                transform.position = Vector3.MoveTowards(transform.position, _target.position, speed * Time.deltaTime);
            }
        }

        public override void Attack()
        {
            Debug.Log("FastEnemy атакует быстро, но слабо!");
        }
    }
}