using UnityEngine;

namespace Infrastructure
{
    public class GameRun : MonoBehaviour
    {
        public GameBootstrap Bootstrap;
        
        private void Awake()
        {
            if (BootstrapNotFound())
                CreateBootstrap();
        }

        private static bool BootstrapNotFound() => 
            FindObjectOfType<GameBootstrap>() == null;

        private void CreateBootstrap() => 
            Instantiate(Bootstrap);
    }
}