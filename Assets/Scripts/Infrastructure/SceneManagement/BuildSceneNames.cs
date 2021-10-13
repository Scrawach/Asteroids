using System.Collections.Generic;
using System.IO;
using UnityEngine.SceneManagement;

namespace Infrastructure.SceneManagement
{
    public class BuildSceneNames : ISceneNames
    {
        public IEnumerable<string> Names()
        {
            var sceneCount = SceneManager.sceneCountInBuildSettings;
            var scenes = new string[sceneCount];
            for (var i = 0; i < sceneCount; i++)
                scenes[i] = Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(i));
            return scenes;
        }
    }
}