using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Analogue
{
    public class Analogue_DB : MonoBehaviour
    {
        [SerializeField]
        Analogue_Set tempSet;//, tempSet2;
        public static Analogue_Set selectedSet;
        void Awake()
        {
            
        }
        void OnValidate()
        {
            selectedSet = tempSet;
            //tempSet2 = selectedSet;
        }
    }
}