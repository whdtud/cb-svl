using Frwk;

public class SceneSwitchManager : FrwkSceneSwitchMgr
{
    private static SceneSwitchManager mInstance;
    public static SceneSwitchManager Instance
    {
        get
        {
            if (mInstance == null)
            {
                mInstance = SingleGOBuilder.Build<SceneSwitchManager>();

                GameManager.Instance.AddChild(mInstance.gameObject);
            }

            return mInstance;
        }
    }
}
