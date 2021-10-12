using System.Collections.Generic;

namespace Infrastructure.SceneManagement.Abstract
{
    public interface IAvailableScenes
    {
        Dictionary<string, ILoadingScene> Scenes();
    }
}