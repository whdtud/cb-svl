using UnityEngine;
using UnityEngine.SceneManagement;

using System.Collections;

using Frwk;

public class GameManager : FrwkGameMgr
{
    private static GameManager mInstance;
    public static GameManager Instance
    {
        get
        {
            if (mInstance == null)
                mInstance = SingleGOBuilder.Build<GameManager>();

            return mInstance;
        }
    }

    public void AddChild(GameObject child)
    {
        child.transform.SetParent(transform);
    }

    public IEnumerator Co_LoadWorld()
    {
        SceneManager.LoadScene("World", LoadSceneMode.Additive);

        yield return null;

        SceneSwitchManager.Instance.ClearAndPushPage(UIPageKind.Page_World);
    }
}
