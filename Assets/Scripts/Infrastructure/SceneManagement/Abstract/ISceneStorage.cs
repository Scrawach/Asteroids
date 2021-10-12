namespace Infrastructure.SceneManagement.Abstract
{
    public interface ISceneStorage
    {
        ILoadingScene Get(string sceneName);
    }
}