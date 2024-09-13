using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text timerText;
    public Text lengthText;
    public Transform cat;
    public bool isRunning = true;

    private float timer;
    private float length = 0f;
    private float maxLength = 14f;
    private float catStartPosition;

    void Start()
    {
        timer = 0f;
        catStartPosition = cat.position.x;
    }

    
    void Update()
    {
        if (isRunning)
        {
            timer += Time.deltaTime;
            timerText.text = "Time:\n" + timer.ToString("F1") + " s";
            length = Mathf.Abs(cat.position.x - catStartPosition);
            float percentage = Mathf.Clamp01(length / maxLength) * 100f;
            lengthText.text = "Slide length:\n" + percentage.ToString("F0") + " %";
        }
    }

    public void StopTimer()
    {
        isRunning = false;
        PlayerPrefs.SetFloat("FinalTime", timer);
        PlayerPrefs.Save();
    }
    public void ResetTimer()
    {
        isRunning = true;
    }
}
