using Core.StateMachine;
using UI;
using UI.Model;
using UI.View;
using UI.ViewModel;
using Zenject;

namespace Core
{
    public class Bootstrapper : MonoInstaller
    {
        public override void InstallBindings()
        {
            RegisterUI();
            BindGameStateMachine();
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
    }
}