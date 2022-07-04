using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public float Timeleft;
    public bool TimerOn = false;

    public TextMeshProUGUI TimerText;
    // Start is called before the first frame update
    void Start()
    {
        TimerOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (TimerOn)
        {
            if (Timeleft > 0)
            {
                Timeleft -= Time.deltaTime;
                updateTimer(Timeleft);
            }
            else
            {
                Debug.Log("your time is op");
                Timeleft = 0;
                TimerOn = false;
            }
        }
    }
    private void updateTimer(float currentTime)
    {
        currentTime += 1;

        float Minutes = Mathf.FloorToInt(currentTime / 60);
        float Seconds = Mathf.FloorToInt(currentTime % 60);

        TimerText.text = string.Format("{0:00} : {1:00}", Minutes, Seconds);
    }
}
