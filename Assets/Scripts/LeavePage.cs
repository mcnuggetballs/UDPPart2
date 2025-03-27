using UnityEngine;

public class LeavePage : Page
{
    private void Awake()
    {
        _root = doc.rootVisualElement;
    }
    public override void UpdateControls()
    {
        if (Input.GetKeyDown(KeyCode.L))
            UIManager.Instance.SetCurrentPage(UIManager.Instance._welcomePage);
    }
}
