using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ClockScript : MonoBehaviour {

    public Transform secondHand, minuteHand, hourHand;
    public float scale, millisecsInSec, secsInMin, minsInHour, hoursInHalfDay;

    [Range(0, 1)]
    public float b;
    [Range(0,1)]
    public float c;
    public float h;
    public float offset;
    [SerializeField] float fracofSec;

    public int BPM, bars;

    public enum TimeType {Game, Real, Music}
    public TimeType timeType;

    [SerializeField]
    public float scaledTime;
    void Start () {
	
	}

    void FixedUpdate() {
        switch (timeType)
        {
            case TimeType.Game:
                scaledTime = Time.time * scale;
                break;
            case TimeType.Real:
                scaledTime = (float)System.DateTime.Now.TimeOfDay.TotalSeconds * scale + offset;
                millisecsInSec = 1000;
                secsInMin = 60;
                minsInHour = 60;
                hoursInHalfDay = 12;
                scale = 1;
                offset = 0.00f;
                break;
            case TimeType.Music:
                scaledTime = BPM/60 * (Time.fixedTime);
                break;
        }
        float y;
        float flooredTime = Mathf.Floor(scaledTime);
        fracofSec = scaledTime - flooredTime;
        if (fracofSec < b)
        {
            y = flooredTime + Mathf.Sin(fracofSec * Mathf.PI / b) * h;
        }
        else if (fracofSec > c)
        {
            float cΔ = (1 - c);
            float w = fracofSec - c;
            y = flooredTime + 1 / (cΔ * cΔ) * (w * w);
        }
        else y = flooredTime;
        secondHand.localEulerAngles = new Vector3(0, 0, -y * 360 / secsInMin); 
        minuteHand.localEulerAngles = new Vector3(0, 0, -Mathf.Floor(scaledTime) * 360 / (secsInMin * minsInHour));
        hourHand.localEulerAngles = new Vector3(0, 0, -Mathf.Floor(scaledTime) * 360 / (secsInMin * hoursInHalfDay * minsInHour));
    }
}
