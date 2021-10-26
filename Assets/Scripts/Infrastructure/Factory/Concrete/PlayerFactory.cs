using Components.Player;
using Infrastructure.AssetManagement;
using Infrastructure.Factory.Abstract;
using Infrastructure.InputLogic;
using Infrastructure.StaticData;
using StaticData;
using UnityEngine;

namespace Infrastructure.Factory.Concrete
{
    public class PlayerFactory : IObjectFactory
    {
        private readonly IObjectFactory _factory;
        private readonly IAsset<PlayerInputData> _config;

        public PlayerFactory(IObjectFactory factory, IAsset<PlayerInputData> config)
        {
            _factory = factory;
            _config = config;
        }

        public GameObject Create()
        {
            var player = _factory.Create();
            var data = _config.Load();
            var input = new PlayerInput(data.HorizontalAxis, data.VerticalAxis, data.Fire, data.AltFire);
            player.GetComponent<PlayerMove>().Construct(input);
            player.GetComponent<RotateToMouse>().Construct(input);
            player.GetComponent<PlayerAttack>().Construct(input);
            return player;
        }
    }
}