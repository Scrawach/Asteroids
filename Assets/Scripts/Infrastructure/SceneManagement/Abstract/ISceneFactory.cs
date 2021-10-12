namespace Infrastructure.SceneManagement.Abstract
{
    public interface ISceneFactory
    {
        ILoadingScene Create(string name);
    }
}