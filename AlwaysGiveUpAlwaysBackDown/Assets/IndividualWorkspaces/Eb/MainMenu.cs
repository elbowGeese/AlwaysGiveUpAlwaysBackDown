using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public enum MenuMode { NONE, HOWTO, SETTINGS, CREDITS }
    public MenuMode mode;

    public GameObject howToPanel, settingsPanel, creditsPanel;

    void Start()
    {
        mode = MenuMode.NONE;
        CloseAllPanels();
    }

    public void Play()
    {
        // change scene
        SceneManager.LoadScene(1);
    }

    public void HowTo()
    {
        if(mode != MenuMode.HOWTO)
        {
            CloseAllPanels();
            howToPanel.SetActive(true);
            mode = MenuMode.HOWTO;
        }
        else
        {
            howToPanel.SetActive(false);
            mode = MenuMode.NONE;
        }
    }

    public void Settings()
    {
        if (mode != MenuMode.SETTINGS)
        {
            CloseAllPanels();
            settingsPanel.SetActive(true);
            mode = MenuMode.SETTINGS;
        }
        else
        {
            settingsPanel.SetActive(false);
            mode = MenuMode.NONE;
        }
    }

    public void Credits()
    {
        if (mode != MenuMode.CREDITS)
        {
            CloseAllPanels();
            creditsPanel.SetActive(true);
            mode = MenuMode.CREDITS;
        }
        else
        {
            settingsPanel.SetActive(false);
            mode = MenuMode.NONE;
        }
    }

    private void CloseAllPanels()
    {
        howToPanel.SetActive(false);
        settingsPanel.SetActive(false);
        creditsPanel.SetActive(false);
    }
}
