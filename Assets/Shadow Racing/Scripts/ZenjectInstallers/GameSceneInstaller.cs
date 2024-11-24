using Shadow_Racing.Scripts.Cars;
using Shadow_Racing.Scripts.CheckpointControllers;
using Shadow_Racing.Scripts.PlayersCars;
using Shadow_Racing.Scripts.ReplayRecorders;
using UnityEngine;
using Zenject;

namespace Shadow_Racing.Scripts.ZenjectInstallers
{
    // Класс отвечает за настройку зависимостей и создание объектов сцены игры с использованием Zenject.
    public class GameSceneInstaller : MonoInstaller
    {
        [SerializeField] private Car _carPrefab;
        [SerializeField] private CarShadow _carShadowPrefab;
        [SerializeField] private Checkpoint[] _checkpoint;
        [SerializeField] private Transform _startPositionCar;
        
        public override void InstallBindings()
        {
            var carInstance = Container.InstantiatePrefabForComponent<Car>(_carPrefab); 
            Container.Bind<Car>().FromInstance(carInstance).AsSingle();
            
            var carShadowInstance = Container.InstantiatePrefabForComponent<CarShadow>(_carShadowPrefab); 
            Container.Bind<CarShadow>().FromInstance(carShadowInstance).AsSingle();
            
            Container.Bind<StartTimer>().FromComponentInHierarchy().AsSingle();
            Container.Bind<GameController>().FromComponentInHierarchy().AsSingle();
            Container.Bind<PlayerCar>().AsSingle().WithArguments(_startPositionCar);
            Container.Bind<PlayerShadowCar>().AsSingle();
            Container.Bind<PlayerRecorder>().AsSingle();
            Container.Bind<CheckpointController>().AsSingle().WithArguments(_checkpoint);
        }
    }
}