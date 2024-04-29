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
        [SerializeField] private int iterator = 0;
        [SerializeField] private SparksBehaviour sparks;
        public bool gameDone = false;
        
        protected override void Start()
        {
            base.Start();

            EventManager.current.onCutBar += CutBar;

            for (int i = 0; i < allBars.Length; i++)
            {
                allBars[i] = allBarObjects[i].GetComponent<BarScript>();
            }
            //objText.
        }
        protected void Update()
        {
            IsGameDone();
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
                StartCoroutine(DelayStopMicrogame());
                Debug.Log("MicrogameStopped");
            }

            coroutineRunning = false;
        }
        void IsGameDone()
        {
            if (!gameDone)
            {
                if (iterator == 5)
                {
                    result = true;
                    gameDone = true;
                    StartCoroutine(DelayStopMicrogame());
                }
            }
        }
        private IEnumerator DelayStopMicrogame()
        {
            Destroy(sparks.gameObject);
            yield return new WaitForSeconds(1.2f);
            StopMicrogame();
        }
        public void IterateBarCount()
        {
            iterator++;
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
