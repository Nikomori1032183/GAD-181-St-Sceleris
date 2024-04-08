using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
namespace Bars
{

    public class CutTheGrate : MonoBehaviour
    {
        [SerializeField] private GameObject[] allBarObjects = new GameObject[5];
        [SerializeField] private BarScript[] allBars = new BarScript[5];
        //[SerializeField] private bool[] barsDone = new bool[5];
        // Start is called before the first frame update
        void Start()
        {
            for (int i = 0; i < allBars.Length; i++)
            {
                allBars[i] = allBarObjects[i].GetComponent<BarScript>();
            }
        }
        private void Update()
        {
            bool whatever = false;

            for (int i = 0; i < allBars.Length - 1; i++)
            {
                if (allBars[i] != null)
                {
                    whatever = true;
                }
            }

            if (!whatever)
            {
                //Victory condition
                print("yay");
            }
        }
    }
}
