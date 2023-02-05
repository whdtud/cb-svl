using UnityEngine;

namespace Frwk
{
    public class UICanvas : MonoBehaviour
    {
        public string SceneName;

        private static UICanvas mInstance;
        public static UICanvas Instance
        {
            get
            {
                if (mInstance == null)
                    mInstance = SingleGOBuilder.Build<UICanvas>();

                return mInstance;
            }
        }

        void Awake()
        {
            OnSceneContentLoaded();
        }

        void Start()
        {
            if (Instance != this)
                Destroy(gameObject);
        }

        public void OnSceneContentLoaded()
        {
            IPageView[] pages = GetComponentsInChildren<IPageView>(true);
            for (int i = 0; i < pages.Length; i++)
            {
                SceneLoadManager.Instance.AddPageToScene(SceneName, pages[i]);
                SceneSwitchManager.Instance.AddKeepPage(pages[i]);

                if (Instance != this)
                    Instance.AddPageObj(pages[i]);
            }
        }

        private void AddPageObj(IPageView page)
        {
            var obj = page.GetGameObject();
            obj.SetActive(false);

            var tempScale = obj.transform.localScale;

            obj.transform.SetParent(Instance.transform);

            obj.transform.localScale = tempScale;
        }
    }
}