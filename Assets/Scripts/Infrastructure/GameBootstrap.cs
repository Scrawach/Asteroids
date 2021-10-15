using System;
using System.Collections.Generic;
using Infrastructure.AssetManagement;
using Infrastructure.Factory;
using Infrastructure.Factory.Abstract;
using Infrastructure.InputLogic;
using Infrastructure.SceneManagement;
using Infrastructure.States;
using Infrastructure.States.Abstract;
using Infrastructure.States.Implementation;
using Infrastructure.StaticData;
using UnityEngine;

namespace Infrastructure
{
    public class GameBootstrap : MonoBehaviour, ICoroutineRunner
    {
        private void Awake()
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
            var staticDatabase = new StaticDatabase(assets);
            var playerFactory =
                new PlayerFactory
                (
                    new DeathObjectFactory
                    (
                        new EngineFactory
                        (
                            new WeaponFactory
                            (
                                new ObjectFactory(new Asset(assets, "Player/PlayerShip")),
                                new BulletFactory(new Asset(assets, "Weapon/Bullet"))
                            ), 
                            staticDatabase
                        ), 
                        new ObjectFactory(new Asset(assets, "VFX/PlayerDeath_VFX"))
                    ), 
                    staticDatabase
                );
            
            var gameFactory = new GameFactory
            (
                new Dictionary<ObjectId, IObjectFactory>
                {
                    [ObjectId.Player] = playerFactory,
                    [ObjectId.UIRoot] = new CachedFactory(new UIRootFactory(new Asset(assets, "UI/UIRoot")))
                }
            );

            var game = new Game
            (
                new StateMachine
                (
                    new Dictionary<Type, IState>
                    {
                        [typeof(BootstrapState)] = new BootstrapState(sceneStorage, staticDatabase),
                        [typeof(LoadLevelState)] = new LoadLevelState(sceneStorage, gameFactory),
                        [typeof(GameLoopState)] = new GameLoopState()
                    }
                )
            );
            
            game.Run();
            DontDestroyOnLoad(this);
        }
    }
}