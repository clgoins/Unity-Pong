using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{

    public void onePlayerGame()
    {
        Debug.Log("running");
        SceneManager.LoadScene("1player");
    }   
    
    public void twoPlayerGame()
    {
        SceneManager.LoadScene("2player");
    }

    public void quitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }

}
