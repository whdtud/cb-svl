using UnityEngine;
using UnityEngine.SceneManagement;

using System.Collections.Generic;

namespace Frwk
{
    public class FrwkSceneLoadMgr : MonoBehaviour
    {
        private Dictionary<string, Scene> mLoadedScene = new Dictionary<string, Scene>();

        protected virtual string[] GetDefaultUISceneNames()
        {
            return new string[] {
                "UISample"
            };
        }

        public void PrepareUIScenes()
        {
            string[] UISceneNames = GetDefaultUISceneNames();

            for (int i = 0; i < UISceneNames.Length; i++)
            {
                CreateSceneObj(UISceneNames[i]);
            }
        }

        private string[] GetLoadedSceneNames()
        {
            var names = new string[SceneManager.sceneCount];

            for (int i = 0; i < SceneManager.sceneCount; i++)
            {
                names[i] = SceneManager.GetSceneAt(i).name;
            }

            return names;
        }

        private bool IsLoadedScene(string sceneName)
        {
            string[] loadedSceneName = GetLoadedSceneNames();
            foreach (var item in loadedSceneName)
            {
                if (item == sceneName)
                    return true;
            }
            return false;
        }

        private Scene CreateSceneObj(string sceneName)
        {
            var obj = new GameObject(sceneName, typeof(Scene));

            obj.transform.parent = transform;

            Scene scene = obj.GetComponent<Scene>();

            if (IsLoadedScene(sceneName) == false)
                scene.LoadScene();

            mLoadedScene.Add(sceneName, scene);

            return scene;
        }

        public Scene GetScene(string sceneName)
        {
            Scene scene;
            if (mLoadedScene.TryGetValue(sceneName, out scene) == false)
            {
                scene = CreateSceneObj(sceneName);
            }
            return scene;
        }

        public void AddPageToScene(string sceneName, IPageView page)
        {
            Scene scene = GetScene(sceneName);
            scene.AddPage(page.GetPageKind(), page);
        }
    }
}