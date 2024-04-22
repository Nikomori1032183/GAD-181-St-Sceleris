using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using VInspector;

public class KeyBehaviour : MonoBehaviour
{
    [SerializeField] int keyCode;
    [SerializeField] char nonNumber;
    [SerializeField] bool isnumber;
    private BombBehaviour bombScript;
    private TextMeshPro keyCodeDisplay;
    [SerializeField] private AudioSource keySound;
    private Animator animator;

    private void Start()
    {
        if (bombScript == null)
        {
            bombScript = GameObject.FindWithTag("bombdefuse_bomb").GetComponent<BombBehaviour>();
        }
        if (keyCodeDisplay == null)
        {
            keyCodeDisplay = GetComponentInChildren<TextMeshPro>();
        }
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }

        if (isnumber)
        {
            keyCodeDisplay.text = keyCode.ToString();
        }
        else if (!isnumber)
        {
            keyCodeDisplay.text = nonNumber.ToString();
        }
    }

    private void OnMouseOver()
    {
        if (!GameObject.FindWithTag("bombdefuse_bomb").GetComponent<BombBehaviour>().SpeaksToTheKeys())
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                SendButton();
            }
        }
    }
    [Button]
    void SendButton()
    {
        animator.SetTrigger("isPressed");
        keySound.Play();
        bombScript.RecieveInput(keyCode);
    }
}
