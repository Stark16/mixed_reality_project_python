using UnityEngine.SceneManagement;
using UnityEngine;

public class InGameUI : MonoBehaviour
{    
    private Pose spawnPose;

    [SerializeField]
    private GameObject Play_mode;

    public void BacktoMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

    }

    private void Update()
    {
        if (NewTap2Place.objectinScene == true)
            Play_mode.SetActive(true);
    }

    public void playModeToggle()
    {
        NewTap2Place.playMode = true;
    }

    public void Jump_Once()
    {

    }
    
    
    
}
