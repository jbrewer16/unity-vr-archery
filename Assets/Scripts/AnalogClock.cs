using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnalogClock : MonoBehaviour
{

    public GameObject hourHand;
    public GameObject minuteHand;
    public GameObject secondHand;

    // Start is called before the first frame update
    void Start()
    {
        DateTime localDate = DateTime.Now;
        int hour = int.Parse(localDate.ToString("HH"));
        if (hour > 12) hour = hour - 12;
        int minute = int.Parse(localDate.ToString("mm"));
        int second = int.Parse(localDate.ToString("ss"));

        hourHand.transform.Rotate(new Vector3(0, ((hour * 30) + (minute * 0.5f)), 0));
        minuteHand.transform.Rotate(new Vector3(0, ((minute * 6) + (second * 0.1f)), 0));
        secondHand.transform.Rotate(new Vector3(0, (second * 6), 0));

        InvokeRepeating("rotateSecondHand", 1.0f, 1.0f);
        InvokeRepeating("rotateMinuteHand", 1.0f, 1.0f);
        InvokeRepeating("rotateHourHand", 60.0f, 60.0f);
    }

    // Update is called once per frame
    void Update()
    {


        
    }

    void rotateSecondHand()
    {
        secondHand.transform.Rotate(new Vector3(0, 6, 0));
    }

    void rotateMinuteHand()
    {
        minuteHand.transform.Rotate(new Vector3(0, 0.1f, 0));
    }

    void rotateHourHand()
    {
        hourHand.transform.Rotate(new Vector3(0, 0.5f, 0));
    }
}
