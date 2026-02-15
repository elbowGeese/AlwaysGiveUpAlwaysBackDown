using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public enum MenuMode { NONE, HOWTO, SETTINGS, CREDITS }
    public MenuMode mode;

    public GameObject howToPanel, settingsPanel, creditsPanel;

    void Start()
    {
        mode = MenuMode.NONE;
    }

    public void Play()
    {

    }

    public void HowTo()
    {

    }

    public void Settings()
    {

    }

    public void Credits()
    {

    }
}
