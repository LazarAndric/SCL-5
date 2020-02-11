using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class timer : MonoBehaviour
{
    public HighscoreTable highscore;
    public Button btn;
    public InputField input;
    public Text timerText;
    int minute;
    int second;
    static float startTime;
    static string n;
    static float t;

    private void Update()
    {
        t = Time.time - startTime;//razlika vremena za duzinu trke
        minute= (int)t / 60;
        string minutes = minute.ToString("00");
        second = (int)t % 60;
        string seconds = second.ToString("00");
        timerText.text = minutes + " : " + seconds;
        if (btn.transform.GetChild(0).GetComponent<Text>().text == "Finish")
        {
            t = Time.time - startTime;
            btn.onClick.AddListener(Promena);
        }
        if (btn.transform.GetChild(0).GetComponent<Text>().text == "Play")
        {
            startTime = Time.time;
            n = input.text;
        }
    }
    public void Promena() 
    {
        highscore.Change();
    }
   public string VratiIme()
    {
        return n;
    }
    public int VratiSkor()
    {
        return (int)t;
    }
}
