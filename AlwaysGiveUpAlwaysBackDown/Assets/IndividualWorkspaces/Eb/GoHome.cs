using UnityEngine;
using UnityEngine.SceneManagement;

public class GoHome : MonoBehaviour
{
    public void GoBackTOHome()
    {
        SceneManager.LoadScene(0);
    }
}
