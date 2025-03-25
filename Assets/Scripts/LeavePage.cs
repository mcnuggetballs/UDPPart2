using UnityEngine;

public class LeavePage : Page
{
    private void Awake()
    {
        _root = doc.rootVisualElement;
    }
    public override void UpdateControls()
    {
        if (Input.GetKeyDown(KeyCode.A))
            UIManager.Instance.SetCurrentPage(UIManager.Instance._welcomePage);
    }
}
