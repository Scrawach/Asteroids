using System.Collections.Generic;

namespace Infrastructure.SceneManagement
{
    public interface ISceneNames
    {
        IEnumerable<string> Names();
    }
}