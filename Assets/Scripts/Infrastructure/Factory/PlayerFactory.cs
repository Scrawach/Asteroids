using Components;
using Components.Player;
using Infrastructure.AssetManagement;
using Infrastructure.Factory.Abstract;
using Infrastructure.InputLogic;
using Infrastructure.StaticData;
using StaticData;
using UnityEngine;

namespace Infrastructure.Factory
{
    public class PlayerFactory : IObjectFactory
    {
        private const string Path = "Player/PlayerShip";
        private readonly IAssets _assets;
        private readonly IPlayerInput _playerInput;
        private readonly IStaticDatabase _staticDatabase;

        public PlayerFactory(IAssets assets, IPlayerInput playerInput, IStaticDatabase staticDatabase)
        {
            _assets = assets;
            _playerInput = playerInput;
            _staticDatabase = staticDatabase;
        }

        public GameObject Create()
        {
            var player = _assets.Instantiate<GameObject>(Path);
            player.GetComponent<PlayerMove>().Construct(_playerInput);
            player.GetComponent<RotateToMouse>().Construct(_playerInput);

            var engineData = _staticDatabase.ForEngine(EngineId.Player);
            player.GetComponent<Engine>().Construct(engineData.MoveSpeed, engineData.RotateSpeed, engineData.AccelerationModifier);
            return player;
        }
    }
}