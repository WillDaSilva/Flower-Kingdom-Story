using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPairDictonary<Tkey1, Tkey2, Tvalue>: Dictionary<KeyPair<Tkey1, Tkey2>, Tvalue>
{public Tvalue this[Tkey1 key1, Tkey2 key2]
    {
        get
        {
            return this[new KeyPair<Tkey1, Tkey2>(key1, key2)];
        }
        set
        {
            this[new KeyPair<Tkey1, Tkey2>(key1, key2)] = value;
        }
    }
}

public class KeyPair<Tkey1, Tkey2>
{
    public KeyPair(Tkey1 key1,Tkey2 key2)
    {
        Key1 = key1;
        Key2 = key2;
    }

    public Tkey1 Key1 { get; set; }
    public Tkey2 Key2 { get; set; }
}

public class _2Dictionary : MonoBehaviour
{
    

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
