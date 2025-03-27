using UnityEngine;

public class WelcomePage : Page
{
    private void Awake()
    {
        _root = doc.rootVisualElement;
    }
    public override void UpdateControls()
    {
        if (Input.GetKeyDown(KeyCode.L))
            UIManager.Instance.SetCurrentPage(UIManager.Instance._optionsPage);
    }
}
