using System;
using System.Collections.Generic;
using Core.Spawners;
using UnityEngine;

namespace Core.Enemies
{
    public enum EnemyType
    {
        Fast,
        Tank
    }
    
    public class EnemyFactory : IEnemyFactory
    {
        private readonly Dictionary<EnemyType, GameObject> _enemyPrefabs;

        public EnemyFactory(Dictionary<EnemyType, GameObject> enemyPrefabs)
        {
            _enemyPrefabs = enemyPrefabs;
        }

        public BaseEnemy CreateEnemy(EnemyType type, Vector3 spawnPosition, EnemySpawner parent)
        {
            if (!_enemyPrefabs.TryGetValue(type, out var enemyPrefab))
            {
                throw new ArgumentException($"Неизвестный тип врага: {type}");
            }

            GameObject enemyObject = UnityEngine.Object.Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            BaseEnemy newEnemy = enemyObject.GetComponent<BaseEnemy>();
            return newEnemy;
        }
    }
}