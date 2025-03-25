using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    public Page _welcomePage;
    public Page _optionsPage;
    public Page _buyPage;
    public Page _leavePage;
    private Page _currentPage = null;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        SetCurrentPage(_welcomePage);
        _optionsPage._root.style.display = DisplayStyle.None;
        _buyPage._root.style.display = DisplayStyle.None;
        _leavePage._root.style.display = DisplayStyle.None;
    }
    private void Update()
    {
        if (_currentPage)
        {
            _currentPage.UpdateControls();
        }
    }
    public void SetCurrentPage(Page newPage)
    {
        if (_currentPage != null)
        {
            _currentPage._root.style.display = DisplayStyle.None;
        }
        _currentPage = newPage;
        if (_currentPage != null)
        {
            _currentPage._root.style.display = DisplayStyle.Flex;
        }
    }
}