using System;

namespace Infrastructure.SceneManagement.Abstract
{
    public interface ILoadingScene
    {
        void Load(Action onLoaded = null);
    }
}