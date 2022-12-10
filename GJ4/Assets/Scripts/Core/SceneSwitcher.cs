using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace GJ4.Core
{
    public class SceneSwitcher 
    {
        private Scene _currentScene;

        public SceneSwitcher(Scene startScene) 
        {
            _currentScene = startScene;
        }

        public async UniTask ChangeSceneAsync(Scene nextScene)
        {
            var loadOperation = SceneManager.LoadSceneAsync(nextScene.buildIndex, LoadSceneMode.Additive);
            loadOperation.allowSceneActivation = true;

            await loadOperation;

            loadOperation.completed += (operation) => SceneManager.UnloadSceneAsync(_currentScene);
        }
    }
}