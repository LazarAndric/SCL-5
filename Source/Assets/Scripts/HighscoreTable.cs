using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class HighscoreTable : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<Transform> highscoreEntryTransformList;
    public timer tim;
    private static bool pom = false;
    private void Awake()
    {
        /* ZA GENERISANJE LISTE!
        entryContainer = transform.Find("highscoreEntryContainer");
        entryTemplate = entryContainer.Find("highscoreEntryTemplate");
        entryTemplate.gameObject.SetActive(false);
        highscoreEntryList = new List<HighscoreEntry>() {
        new HighscoreEntry { score = 120, name = "P" },
        new HighscoreEntry { score = 180, name = "R" },
        };
        highscoreEntryTransformList = new List<Transform>();
        foreach (HighscoreEntry highscoreEntry in highscoreEntryList)
        {
            CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
        }
        Highscores highscores = new Highscores { highscoreEntryList = highscoreEntryList };
        string json = JsonUtility.ToJson(highscoreEntryList);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
        */
        PlayerPrefs.GetString("highscoreTable");
        entryContainer = transform.Find("highscoreEntryContainer");
        entryTemplate = entryContainer.Find("highscoreEntryTemplate");
        entryTemplate.gameObject.SetActive(false);
        if (pom)
        {
            AddHighscoreEntry(tim.VratiSkor(), tim.VratiIme());
            pom = false;
        }
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        for (int i = 0; i < highscores.highscoreEntryList.Count; i++)
        {
            for (int j = i + 1; j < highscores.highscoreEntryList.Count; j++)
            {
                if (highscores.highscoreEntryList[j].score < highscores.highscoreEntryList[i].score)
                {
                    HighscoreEntry tmp = highscores.highscoreEntryList[i];
                    highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
                    highscores.highscoreEntryList[j] = tmp;
                }
            }
        }
        highscoreEntryTransformList = new List<Transform>();

        foreach (HighscoreEntry highscoreEntry in highscores.highscoreEntryList)
        {
            CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
        }
    }
    public void Change()
    {
        pom = true;
    }
    private void AddHighscoreEntry(int score, string name) 
    {
        HighscoreEntry highscoreEntry = new HighscoreEntry { score=score,name=name};
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        highscores.highscoreEntryList.Add(highscoreEntry);

        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
    }
     private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList) 
    {
      float templateHeight = 20f;
      Transform entryTransform = Instantiate(entryTemplate, container);
     RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
     entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);//jedan ispod drugog
     entryTransform.gameObject.SetActive(true);

        string strPos;
        int pos = transformList.Count + 1;
        switch (pos)
        {
            case 1: strPos = pos + " ST"; break;
            case 2: strPos = pos + " ND"; break;
            case 3: strPos = pos + " RD"; break;
            default: strPos = pos + " TH"; break;
        }
        entryTransform.Find("posText").GetComponent<Text>().text = strPos;
        string minutes = (highscoreEntry.score / 60).ToString("00");
        string seconds = (highscoreEntry.score % 60).ToString("00");
        entryTransform.Find("scoreText").GetComponent<Text>().text = minutes + " : " + seconds;
        entryTransform.Find("nameText").GetComponent<Text>().text = highscoreEntry.name;
        transformList.Add(entryTransform);
    }

    private class Highscores 
    {
        public List<HighscoreEntry> highscoreEntryList;
    }

    [System.Serializable]
    private class HighscoreEntry 
    {
        public int score;
        public string name;
    }

}
