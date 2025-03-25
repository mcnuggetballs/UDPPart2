using UnityEngine;
using UnityEngine.UIElements;

public abstract class Page : MonoBehaviour
{
    public UIDocument doc;
    public VisualElement _root;

    public abstract void UpdateControls();
}
