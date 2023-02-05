using Frwk;

public class ResourceManager : FrwkRsrcMgr
{
    private static ResourceManager mInstance;
    public static ResourceManager Instance
    {
        get
        {
            if (mInstance == null)
                mInstance = SingleGOBuilder.Build<ResourceManager>();

            return mInstance;
        }
    }
}
