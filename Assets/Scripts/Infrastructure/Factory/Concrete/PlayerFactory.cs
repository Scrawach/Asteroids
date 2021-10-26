using Components.Player;
using Infrastructure.Factory.Abstract;
using Infrastructure.InputLogic;
using Infrastructure.StaticData;
using UnityEngine;

namespace Infrastructure.Factory.Concrete
{
    public class PlayerFactory : IObjectFactory
    {
        private readonly IObjectFactory _factory;
        private readonly IStaticDatabase _database;

        public PlayerFactory(IObjectFactory factory, IStaticDatabase database)
        {
            _factory = factory;
            _database = database;
        }

        public GameObject Create()
        {
            var player = _factory.Create();
            var playerData = _database.ForPlayerInput();
            var playerInput = new PlayerInput(playerData.HorizontalAxis, playerData.VerticalAxis, playerData.Fire,
                playerData.AltFire);
            player.GetComponent<PlayerMove>().Construct(playerInput);
            player.GetComponent<RotateToMouse>().Construct(playerInput);
            player.GetComponent<PlayerAttack>().Construct(playerInput);
            return player;
        }
    }
}