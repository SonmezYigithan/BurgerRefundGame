using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CountdownScript : MonoBehaviour
{
    public int timeEnded = 0;

    float totalTime = 120f; //2 minutes

    public Text countDownText;

    // Update is called once per frame
    void Update()
    {
        totalTime -= Time.deltaTime;
        UpdateLevelTimer(totalTime);

        if(totalTime <= 0.01f)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    public void UpdateLevelTimer(float totalSeconds)
    {
        int minutes = Mathf.FloorToInt(totalSeconds / 60f);
        int seconds = Mathf.RoundToInt(totalSeconds % 60f);

        string formatedSeconds = seconds.ToString();

        if (seconds == 60)
        {
            seconds = 0;
            minutes += 1;
        }

        countDownText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }
}
