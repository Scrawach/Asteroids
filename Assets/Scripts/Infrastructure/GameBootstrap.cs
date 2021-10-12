using System;
using System.Collections.Generic;
using Infrastructure.AssetManagement;
using Infrastructure.Factory;
using Infrastructure.Factory.Abstract;
using Infrastructure.SceneManagement;
using Infrastructure.States;
using Infrastructure.States.Abstract;
using Infrastructure.States.Implementation;
using Infrastructure.StaticData;
using InputLogic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure
{
    public class GameBootstrap : MonoBehaviour, ICoroutineRunner
    {
        private void Awake()
        {
            const string initialScene = "Initial";
            const string gameScene = "GameLoop";
            
            var sceneStorage = new SceneStorage
            (
                new CachedAvailableScenes
                (
                    new AvailableScenes
                    (
                        new[] { initialScene, gameScene },
                        new SceneFactory(this)
                    )
                )
            );

            var assetsDatabase = new AssetsDatabase();
            var staticDatabase = new StaticDatabase(assetsDatabase);
            var gameFactory = new GameFactory
            (
                new Dictionary<ObjectId, IObjectFactory>
                {
                    [ObjectId.Player] = new PlayerFactory(new Assets(assetsDatabase), new PlayerInput(), staticDatabase),
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