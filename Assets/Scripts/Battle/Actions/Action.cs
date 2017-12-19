using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action: ICloneable
{
    public ActionAnimation animation { get; protected set; }

    public void Start()
    {

    }

    public object Clone()
    {
        return MemberwiseClone();
    }

}
