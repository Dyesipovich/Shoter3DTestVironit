using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtonController : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("CharacterSelection");
    }
    public void ExitButton()
    {
        Application.Quit();
    }
}
