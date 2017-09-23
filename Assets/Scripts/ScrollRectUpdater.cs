using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollRectUpdater : MonoBehaviour {

    void Start()
    {
        ReEvaluate();
    }

    public void ReEvaluate()
    {
        float f = 0;
        f = (transform.childCount - 1) * 10 + transform.childCount*60 + 24;
        RectTransform rt = GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(rt.sizeDelta.x,f);
    }
}
