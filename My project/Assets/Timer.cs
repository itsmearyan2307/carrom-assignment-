using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Canvas gameovercanvas;
    public float totalTime = 120f; // Total time in seconds
    private float currentTime;
   public  Text timerText;

    private void Start()
    {
        gameovercanvas.enabled = false; 
        currentTime = totalTime;
        timerText = GetComponentInChildren<Text>();
        timerText.text = FormatTime(currentTime);
    }

    private void Update()
    {
        currentTime -= Time.deltaTime;

        if (currentTime <= 0f)
        {
            currentTime = 0f;
            GameOver();
        }

        timerText.text = FormatTime(currentTime);
    }

    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);

        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void GameOver()
    {
        gameovercanvas.enabled = true;
        Time.timeScale = 0; 
    }
}
