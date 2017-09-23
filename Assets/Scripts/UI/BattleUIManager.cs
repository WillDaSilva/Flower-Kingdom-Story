using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUIManager : MonoBehaviour {
    [SerializeField]
    int selectedIndex = 0;
    int selectionLength = 0;
    public int maxVisible;
    float v = 0;
    float t = 0;
    float waitTime = 0.25f;
    [SerializeField]
    Transform selector, scrollBar, selectionParent;
    List<Transform> selection = new List<Transform>();
    ScrollRect sr;
    //Scrollbar sb;
    [SerializeField]
    float maxY, minY;

    bool wasPressedLastFrame = false;//, gotButtonDown = false;
    void Start()
    {
        sr = transform.GetChild(0).GetComponent<ScrollRect>();
        //sb = transform.GetChild(1).GetComponent<Scrollbar>();
        foreach (Transform t in selectionParent)
        {
            selection.Add(t.GetChild(0));
            selectionLength++;
        }
        selectionLength = selection.Count - 1;

        maxY = selection[0].position.y;
        minY = selection[maxVisible-1].position.y;
    }
    
    void Update()
    {
        v = -Input.GetAxisRaw("Vertical");
        if (v != 0)
        {
            if (t >= waitTime)
                Iterate();
            t -= Time.deltaTime;
            if (t <= 0)
            {
                Iterate();
                t = waitTime / 3;
            }
        }
        else t = waitTime;
        //float distanceBetween = Mathf.Abs( selector.position.y - selection[selectedIndex].position.y);

        //float d = Mathf.Abs(selector.position.y - selection[selectedIndex].position.y);
        float selectorY = Mathf.Lerp(selector.position.y, Mathf.Clamp(selection[selectedIndex].position.y, minY, maxY), 10 * Time.deltaTime);
        selector.position = new Vector3(selector.position.x, selectorY);
        //sb.value = Mathf.Lerp(sb.value,(float)selectedIndex / selectionLength, 10 * Time.deltaTime);
        sr.verticalNormalizedPosition = Mathf.Lerp(sr.verticalNormalizedPosition, 1 - (float)selectedIndex / selectionLength, 10 * Time.deltaTime);
        //float scrollY = Mathf.Lerp(sr.verticalNormalizedPosition, 1 - (float)selectedIndex / selectionLength, 10 * Time.deltaTime * maxVisible);
        //sr.verticalNormalizedPosition = scrollY;
    }
    void Iterate()
    {
        selectedIndex = Math.Wrap(selectedIndex + (int)Mathf.Sign(v), 0, selectionLength);
    }
}



/*if (Input.GetButton("Vertical"))
{
    if (!wasPressedLastFrame)
    {
        gotButtonDown = true;
        if (v != 0)
        {
            Iterate();
        }
    }
    else
    {
        t -= Time.deltaTime;
        if (Time.deltaTime <= 0)
        {
            Iterate();
            t = 1f;
        }
    }


}*/
