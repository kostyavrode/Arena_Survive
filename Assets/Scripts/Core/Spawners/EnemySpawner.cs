using System;
using System.Collections;
using System.Collections.Generic;
using Core.Enemies;
using Core.StateMachine;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Core.Spawners
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Transform[] spawnPoints;
        [SerializeField] private float spawnRate = 2f;

        private IEnemyFactory _enemyFactory;
        
        private List<BaseEnemy> _enemies = new List<BaseEnemy>();
        
        private bool _isSpawning;
        private bool _isPaused;

        [Inject]
        public void Construct(IEnemyFactory enemyFactory)
        {
            _enemyFactory = enemyFactory;
        }

        public void StartSpawning()
        {
            if (_isSpawning) return;
            _isSpawning = true;
            _isPaused = false;
            StartCoroutine(SpawnEnemies());
        }

        public void StopSpawning()
        {
            _isSpawning = false;
            _isPaused = false;
            StopAllCoroutines();
            ClearEnemies();
        }

        public void PauseSpawning()
        {
            _isPaused = true;
        }

        public void ResumeSpawning()
        {
            _isPaused = false;
        }

        private IEnumerator SpawnEnemies()
        {
            while (_isSpawning)
            {
                yield return new WaitForSeconds(spawnRate);
                if (!_isPaused)
                {
                    SpawnEnemy();
                }
            }
        }

        private void SpawnEnemy()
        {
            if (!_isSpawning || _isPaused) return;

            EnemyType randomType = (Random.value > 0.5f) ? EnemyType.Fast : EnemyType.Tank;
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            _enemies.Add(_enemyFactory.CreateEnemy(randomType, spawnPoint.position, this));
        }

        private void ClearEnemies()
        {
            foreach (var enemy in _enemies)
            {
                Destroy(enemy.gameObject);
            }
            _enemies.Clear();
        }
    }
}