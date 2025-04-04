using UnityEngine;
using UnityEngine.SceneManagement;          // We need this when we wann manage scenes in our project.
public class MainMenu : MonoBehaviour
{

    // Now we just write functionality for our buttons:
    // We dont need start and update,  we just need function to call specific scenes when specific buttons are pressed.

    public void PlayGame()      
    {
        
        // Here we load our next scene in the scene queue in the build menu.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
