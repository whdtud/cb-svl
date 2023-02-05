using UnityEngine;
using UnityEngine.SceneManagement;

using System.Collections.Generic;

using Frwk;

public class Scene : MonoBehaviour
{
    private Dictionary<UIPageKind, IPageView> mGameObjectDic = new Dictionary<UIPageKind, IPageView>();

    public void LoadScene()
    {
        SceneManager.LoadScene(name, LoadSceneMode.Additive);
    }

    public void AddPage(UIPageKind kind, IPageView page)
    {
        if (mGameObjectDic.ContainsKey(kind) == false)
            mGameObjectDic.Add(kind, page);
    }
}
