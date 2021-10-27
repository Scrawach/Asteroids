using System;
using System.Collections.Generic;
using Infrastructure.AssetManagement;
using Infrastructure.AssetManagement.ConcreteAssets;
using Infrastructure.Factory;
using Infrastructure.Factory.Abstract;
using Infrastructure.Factory.Concrete;
using Infrastructure.InputLogic;
using Infrastructure.SceneManagement;
using Infrastructure.States;
using Infrastructure.States.Abstract;
using Infrastructure.States.Implementation;
using Infrastructure.StaticData;
using StaticData;
using UnityEngine;

namespace Infrastructure
{
    public class GameBootstrap : MonoBehaviour, ICoroutineRunner
    {
        private void Awake()
        {
            NewGame().Run();
            DontDestroyOnLoad(this);
        }

        private Game NewGame()
        {
            var sceneStorage = new SceneStorage
            (
                new CachedAvailableScenes
                (
                    new AvailableScenes
                    (
                        new BuildSceneNames(),
                        new SceneFactory(this)
                    )
                )
            );
            
            var assets = new AssetsDatabase();
            var playerFactory = new PlayerFactory
            (
                new EngineFactory
                (
                    new WeaponFactory
                    (
                        new MortalObjectFactory
                        (
                            new InstantiateFactory(new PlayerAsset(assets)),
                            new InstantiateFactory(new VfxDeathAsset(assets))
                        ),
                        new BulletFactory
                        (
                            new MortalObjectFactory
                            (
                                new InstantiateFactory(new PlayerBulletAsset(assets)),
                                new InstantiateFactory(new VfxDeathAsset(assets))
                            )
                        ),
                        new PlayerWeaponConfig(assets)
                    ), 
                    new PlayerEngineConfig(assets)
                ),
                new PlayerInputConfig(assets)
            );

            var uiRootFactory = new CachedFactory(new InstantiateFactory(new UIRootAsset(assets)));
            var asteroidSpawnFactory = new CachedFactory
            (
                new SpawnerFactory
                (
                    new InstantiateFactory(new AsteroidSpawnMarkAsset(assets)),
                    new MortalObjectFactory
                    (
                        new InstantiateFactory(new AsteroidAsset(assets)),
                        new InstantiateFactory(new VfxDeathAsset(assets))
                    ),
                    cooldown: .5f
                )
            );
            
            var gameFactory = new GameFactory
            (
                new Dictionary<ObjectId, IObjectFactory>
                {
                    [ObjectId.Player] = playerFactory,
                    [ObjectId.Asteroid] = asteroidSpawnFactory,
                    [ObjectId.UIRoot] = uiRootFactory
                }
            );

            return new Game
            (
                new StateMachine
                (
                    new Dictionary<Type, IState>
                    {
                        [typeof(BootstrapState)] = new BootstrapState(sceneStorage),
                        [typeof(LoadLevelState)] = new LoadLevelState(sceneStorage, gameFactory),
                        [typeof(GameLoopState)] = new GameLoopState()
                    }
                )
            );
        }
    }
}