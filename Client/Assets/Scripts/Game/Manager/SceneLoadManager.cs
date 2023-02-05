using UnityEngine;

using Frwk;

public class SceneLoadManager : FrwkSceneLoadMgr
{
    private static SceneLoadManager mInstance;
    public static SceneLoadManager Instance
    {
        get
        {
            if (mInstance == null)
            {
                mInstance = SingleGOBuilder.Build<SceneLoadManager>();

                GameManager.Instance.AddChild(mInstance.gameObject);
            }

            return mInstance;
        }
    }

    protected override string[] GetDefaultUISceneNames()
    {
        return new string[] {
            "UITitle",
            "UIWorld",
         };
    }
}
