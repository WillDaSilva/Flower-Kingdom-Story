using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class MirrorSymmetry : MonoBehaviour {
    public List<RectTransform> uiElements;

    void Update()
    {

        uiElements[1].transform.localPosition = new Vector2(-uiElements[0].transform.localPosition.x, uiElements[0].transform.localPosition.y);
        uiElements[2].transform.localPosition = new Vector2(uiElements[0].transform.localPosition.x, -uiElements[0].transform.localPosition.y);
        uiElements[3].transform.localPosition = new Vector2(-uiElements[0].transform.localPosition.x, -uiElements[0].transform.localPosition.y);

    }

}
