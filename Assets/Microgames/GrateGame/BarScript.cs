using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

namespace Bars
{
    public class BarScript : MonoBehaviour
    {
        public bool isDone = false;
        //One bool for each bar cut segment (i.e. 2 per bar)
        private bool[] barCut = new bool[2];
        //One gameObject per bool
        [SerializeField] private GameObject[] barPatch = new GameObject[2];
        [SerializeField] private Animator mAnimator;
        [SerializeField] private Animation barAnimation;
        [SerializeField] private CutTheGrate mainScriptRef;
        [SerializeField] private AudioSource sfx;
        [SerializeField] private AudioClip barSegmentCut;
        [SerializeField] private AudioClip barFullCut;
        private bool animationPlayed = false;

        private void Start()
        //Set the bools to false to start with
        {
            InputManager.current.onLeftClick += ClickOnBar;

            for (int i = 0; i < barCut.Length - 1; i++)
            {
                barCut[i] = false;
            }
            if (mAnimator == null)
            {
                mAnimator = GetComponent<Animator>();
            }
        }
        private void Update()
        {
            if (!barCut.Contains(false) && !animationPlayed)
            {
                sfx.clip = barFullCut;
                sfx.pitch = (Random.Range(0.9f, 1.1f));
                sfx.PlayDelayed(0.5f);
                Debug.Log("Bar Cut!");
                mAnimator.SetTrigger("BarBroken");
                animationPlayed = true;
                mainScriptRef.IterateBarCount();
            }
        }

        RaycastHit CastToPoint()
        {
            Ray ray = (Camera.main.ScreenPointToRay(Input.mousePosition));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1000f))
            {

            }
            return hit;
            //Debug.DrawLine(ray.origin, hit.point, Color.red);
        }

        private void ClickOnBar()
        {
            //Play Particle Effect
            if (CastToPoint().collider.gameObject.tag == ("BarPatch"))
            {
                GameObject bar = CastToPoint().collider.gameObject;
                
                if (IndexPos(bar) != -1)
                {
                    sfx.clip = barSegmentCut;
                    sfx.pitch = Random.Range(0.9f, 1.1f);
                    sfx.Play();

                    EventManager.current.CutBar();

                    Destroy(barPatch[IndexPos(bar)]);
                    barCut[IndexPos(bar)] = true;
                }
            }
        }

        private int IndexPos(GameObject bar)
        {
            int x = System.Array.IndexOf(barPatch, bar);
            return x;
            
        }
    }
}