using Core.Spawners;
using UnityEngine;

namespace Core.Enemies
{
    public interface IEnemyFactory
    {
        BaseEnemy CreateEnemy(EnemyType type, Vector3 spawnPosition, EnemySpawner parent);
    }
}