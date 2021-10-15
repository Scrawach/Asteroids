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
        private readonly IAsset _asset;
        private readonly IStaticDatabase _staticDatabase;
        private readonly IObjectFactory _bulletFactory;

        public PlayerFactory(IAsset asset, IStaticDatabase staticDatabase, IObjectFactory bulletFactory)
        {
            _asset = asset;
            _staticDatabase = staticDatabase;
            _bulletFactory = bulletFactory;
        }

        public GameObject Create()
        {
            var player = _asset.Instantiate<GameObject>();

            var playerData = _staticDatabase.ForPlayerInput();
            var playerInput = new PlayerInput(playerData.HorizontalAxis, playerData.VerticalAxis, playerData.Fire,
                playerData.AltFire);
            player.GetComponent<PlayerMove>().Construct(playerInput);
            player.GetComponent<RotateToMouse>().Construct(playerInput);
            player.GetComponent<PlayerAttack>().Construct(playerInput);

            var engineData = _staticDatabase.ForEngine(EngineId.Player);
            player.GetComponent<Engine>().Construct(engineData.MoveSpeed, 
                engineData.RotateSpeed, engineData.AccelerationModifier);
            player.GetComponent<Weapon>().Construct(_bulletFactory, 2f);
            return player;
        }
    }
}