using Infrastructure.Factory;
using Infrastructure.Factory.Abstract;
using Infrastructure.SceneManagement.Abstract;
using Infrastructure.States.Abstract;
using UnityEngine;

namespace Infrastructure.States.Implementation
{
    public class LoadLevelState : IPayloadState<string>
    {
        private readonly ISceneStorage _sceneStorage;
        private readonly IGameFactory _gameFactory;
        private IStateMachine _stateMachine;

        public LoadLevelState(ISceneStorage sceneStorage, IGameFactory gameFactory)
        {
            _sceneStorage = sceneStorage;
            _gameFactory = gameFactory;
        }

        public void Enter(IStateMachine stateMachine, string sceneName)
        {
            _stateMachine = stateMachine;
            _sceneStorage.Get(sceneName).Load(OnLoaded);
        }

        public void Exit()
        {

        }

        private void OnLoaded()
        {
            var player = _gameFactory.Create(ObjectId.Player);
            var uiRoot = _gameFactory.Create(ObjectId.UIRoot);
            _stateMachine.Enter<GameLoopState, GameObject>(player);
        }
    }
}