using System;
using UnityEngine;
using UnityEngine.UI;

public class FPSDisplay : MonoBehaviour {
    Text text;
    [SerializeField]
    float FPS, maxFPS, minFPS, avgFPS;
    [SerializeField]
    int maxIterations;
    [SerializeField]
    float updateInterval;
    [SerializeField]
    int x;
    [SerializeField]
    int[] fpsList;
	void Start () {
        fpsList = new int[maxIterations];
        text = transform.GetChild(0).GetComponent<Text>();
        InvokeRepeating("UpdateFPS", 0, updateInterval);
        x = 0;
	}
    void UpdateFPS()
    {
        int iterations = 0;
        FPS = 1 / Time.smoothDeltaTime;

        fpsList[x] = (int)FPS;
        x = Math.Wrap(x + 1, 0, maxIterations-1);
        int fpsSum = 0;
        minFPS = 999;
        maxFPS = 0;
        foreach (int i in fpsList)
        {
            if (i > maxFPS)
                maxFPS = i;
            if (i < minFPS)
                minFPS = i;
            if (i != 0)
            {
                fpsSum += i;
                iterations++;
            }
        }
        avgFPS = fpsSum / iterations;

        UpdateText();

    }
	void UpdateText() {
        text.text = FPS.ToString("F0") + " FPS";
	}
}
