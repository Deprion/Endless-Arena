using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private InputField NickName;
    [SerializeField]
    private Toggle Windowed;
    [SerializeField]
    private Dropdown Dropdown;
    [SerializeField]
    private GameObject Menu, AlphaPanel, SettingsPanel, Mage, Paladin, Rogue, Warrior;
    [SerializeField]
    private Image AlphaImage;
    [SerializeField]
    private Text InfoText;
    private void Start()
    {
        try
        {
            AlphaImage = AlphaPanel.GetComponent<Image>();
        }
        catch { }
    }
    public void Settings()
    {
        try
        {
            Menu.SetActive(false);
        }
        catch { }
        SettingsPanel.SetActive(true);
    }
    public void Back()
    {
        try
        {
            Menu.SetActive(true);
        }
        catch { }
        SettingsPanel.SetActive(false);
    }
    public void Save()
    {
        if(NickName.text.Length >= 5) PhotonNetwork.NickName = NickName.text;
        Screen.fullScreen = !Windowed.isOn;
        if (Dropdown.value == 0) Screen.SetResolution(1920, 1080, !Windowed.isOn);
        else if (Dropdown.value == 1) Screen.SetResolution(1280, 720, !Windowed.isOn);
    }
    public void MenuReveal()
    {
        if (AlphaImage.color.a == 0.0f) AlphaImage.color = new Color(0, 0, 0, 0.30f);
        else AlphaImage.color = new Color(0, 0, 0, 0);
        if (SettingsPanel.activeSelf) SettingsPanel.SetActive(false);
        else Menu.SetActive(!Menu.activeSelf);
    }
    public void MageButton()
    {
        InfoText.text = "Work";
        GameManager.PlayerPrefab = Mage;
        PlayerControls.PlayerCharacter = 0;
    }
    public void PaladinButton()
    {
        InfoText.text = "Don't Work";
        GameManager.PlayerPrefab = Paladin;
        PlayerControls.PlayerCharacter = 1;
    }
    public void RogueButton()
    {
        InfoText.text = "Work";
        GameManager.PlayerPrefab = Rogue;
        PlayerControls.PlayerCharacter = 2;
    }
    public void WarriorButton()
    {
        InfoText.text = "Don't Work";
        GameManager.PlayerPrefab = Warrior;
        PlayerControls.PlayerCharacter = 3;
    }
}
