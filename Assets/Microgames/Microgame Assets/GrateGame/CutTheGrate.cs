using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
namespace Bars
{
    public class CutTheGrate : Microgame
    {
        [SerializeField] private GameObject[] allBarObjects = new GameObject[5];
        [SerializeField] private BarScript[] allBars = new BarScript[5];
        //[SerializeField] private bool[] barsDone = new bool[5];
        // Start is called before the first frame update
        protected override void Start()
        {
            base.Start();

            EventManager.current.onCutBar += CutBar;

            for (int i = 0; i < allBars.Length; i++)
            {
                allBars[i] = allBarObjects[i].GetComponent<BarScript>();
            }
        }
        protected void Update()
        {

        }

        bool coroutineRunning = false;

        private void CutBar()
        {
            if (!coroutineRunning)
            {
                StartCoroutine(CheckBars());
            }
        }

        private IEnumerator CheckBars()
        {
            coroutineRunning = true;
            yield return new WaitForSeconds(0.5f);

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
                StopMicrogame();
            }

            coroutineRunning = false;
        }

        protected override void PlayMicrogame()
        {
            base.PlayMicrogame();
        }

        protected override void StopMicrogame()
        {

            Debug.Log("StopMicrogame");
            base.StopMicrogame();
        }
    }
}
