using UnityEngine;

namespace Player
{
    public class PlayerSpawnPoint : MonoBehaviour
    {
        public static Vector3 SpawnPosition;

        private void Awake()
        {
            SpawnPosition = transform.position;
        }
    }
}