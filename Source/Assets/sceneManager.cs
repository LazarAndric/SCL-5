using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
    public AudioManager audioManager;
    public GameObject prevMenu;
    public GameObject writeName;
    public GameObject leaderBoard;
    public InputField input;

    // Start is called before the first frame update
    public void Start()
    {
        prevMenu.SetActive(true);
        writeName.SetActive(false);
        leaderBoard.SetActive(false);
        audioManager.mainMenuSound.Play();
    }
    public void Play()
    {
        prevMenu.SetActive(false);
        writeName.SetActive(true);
        audioManager.mainMenuClick.Play();
    }
    public void Quit()
    {
        Application.Quit();
        audioManager.mainMenuClick.Play();
    }
    public void LeaderBoard()
    {
        prevMenu.SetActive(false);
        leaderBoard.SetActive(true);
        audioManager.mainMenuClick.Play();
    }
    public void Back()
    {
        leaderBoard.SetActive(false);
        prevMenu.SetActive(true);
        audioManager.mainMenuClick.Play();
    }
    public void afterNamePlay()
    {
        audioManager.mainMenuClick.Play();
        if (input.text != "")
        {
            SceneManager.LoadScene("Level01");
        }
        else Debug.Log("Type name first!");

    }
}
