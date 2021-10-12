using Infrastructure.SceneManagement.Abstract;
using Infrastructure.States.Abstract;
using Infrastructure.StaticData;

namespace Infrastructure.States.Implementation
{
    public class BootstrapState : IDefaultState
    {
        private const string InitialScene = "Initial";
        private const string GameLoopScene = "GameLoop";
        private readonly ISceneStorage _sceneStorage;
        private readonly IStaticDatabase _staticDatabase;

        private IStateMachine _stateMachine;

        public BootstrapState(ISceneStorage sceneStorage, IStaticDatabase staticDatabase)
        {
            _sceneStorage = sceneStorage;
            _staticDatabase = staticDatabase;
        }
        
        public void Enter(IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
            _staticDatabase.Load();
            _sceneStorage
                .Get(InitialScene)
                .Load(onLoaded: EnterLoadLevel);
        }

        private void EnterLoadLevel() => 
            _stateMachine.Enter<LoadLevelState, string>(GameLoopScene);

        public void Exit()
        { }
    }
}