using System.Collections.Generic;
using Core.Enemies;
using Core.Spawners;
using Core.StateMachine;
using UI;
using UI.Model;
using UI.View;
using UI.ViewModel;
using UnityEngine;
using Zenject;

namespace Core
{
    public class Bootstrapper : MonoInstaller
    {
        public override void InstallBindings()
        {
            RegisterUI();
            BindGameStateMachine();
            BindEnemiesAndFactory();
        }

        private void RegisterUI()
        {
            Container.Bind<UIManager>().AsSingle().NonLazy();
            
            Container.Bind<MenuModel>().AsSingle();
            Container.Bind<MenuViewModel>().AsSingle();
            Container.Bind<ViewBase>().To<MenuView>().FromComponentInHierarchy().AsSingle();
            //Container.BindInterfacesAndSelfTo<MenuView>().FromComponentInHierarchy().AsSingle();
            
            Container.Bind<PlayingModel>().AsSingle();
            Container.Bind<PlayingViewModel>().AsSingle();
            Container.Bind<ViewBase>().To<PlayingView>().FromComponentInHierarchy().AsSingle();
            //Container.BindInterfacesAndSelfTo<PlayingView>().FromComponentInHierarchy().AsSingle();
            
            Container.Bind<PauseModel>().AsSingle();
            Container.Bind<PauseViewModel>().AsSingle();
            Container.Bind<ViewBase>().To<PauseView>().FromComponentInHierarchy().AsSingle();
            //Container.BindInterfacesAndSelfTo<PauseView>().FromComponentInHierarchy().AsSingle();
            
            Container.Bind<SettingsModel>().AsSingle();
            Container.Bind<SettingsViewModel>().AsSingle();
            Container.Bind<ViewBase>().To<SettingsView>().FromComponentInHierarchy().AsSingle();
            //Container.BindInterfacesAndSelfTo<SettingsView>().FromComponentInHierarchy().AsSingle();
        }

        private void BindGameStateMachine()
        {
            Container.Bind<MenuState>().AsSingle();
            Container.Bind<PlayingState>().AsSingle();
            Container.Bind<PauseState>().AsSingle();
            Container.Bind<MiniGameState>().AsSingle();
            Container.Bind<GameOverState>().AsSingle();
            
            Container.BindInterfacesAndSelfTo<GameStateMachine>().AsSingle().NonLazy();
        }

        private void BindEnemiesAndFactory()
        {
            var enemyPrefabs = new Dictionary<EnemyType, GameObject>
            {
                { EnemyType.Fast, Resources.Load<GameObject>("Enemies/FastEnemy") },
                { EnemyType.Tank, Resources.Load<GameObject>("Enemies/TankEnemy") }
            };

            Container.Bind<IEnemyFactory>().To<EnemyFactory>().AsSingle().WithArguments(enemyPrefabs);
            Container.Bind<EnemySpawner>().FromComponentInHierarchy().AsSingle();
        }
    }
}