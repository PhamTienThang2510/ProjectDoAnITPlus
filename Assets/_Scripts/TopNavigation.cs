using UnityEngine;
using UnityEngine.UI;

public class TopNavigation : MonoBehaviour
{
    [SerializeField] private GameObject AvatarPanel;
    [SerializeField] private Button AvatarButton;
    [SerializeField] private Button AvatarButtonClose;
    public void Start()
    {
        // Set up button listener
        AvatarButton.onClick.AddListener(OnAvatarButtonClicked);
        AvatarButtonClose.onClick.AddListener(CloseAvatarPanel);
    }

    private void OnAvatarButtonClicked()
    {
        AvatarPanel.SetActive(true);
    }
    
    public void CloseAvatarPanel()
    {
        AvatarPanel.SetActive(false);
    }

}
