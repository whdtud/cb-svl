using UnityEngine.UI;

using Frwk;

public class PageTitle : PageView
{
    public Button StartButton;

    public override UIPageKind GetPageKind()
    {
        return UIPageKind.Page_Title;
    }

    public override void OnPreEnable()
    {
    }

    void Awake()
    {
        StartButton.onClick.AddListener(OnStartButtonClick);
    }

    private void OnStartButtonClick()
    {
        StartCoroutine(GameManager.Instance.Co_LoadWorld());
    }
}
