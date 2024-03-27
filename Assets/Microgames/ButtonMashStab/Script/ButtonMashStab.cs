using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VInspector;

public class ButtonMashStab : Microgame
{
    [SerializeField] KnifeMovement knife;
    int timesStabbed = 0;

    // Start is called before the first frame update
    override protected void Start()
    {
        base.Start();
        InputManager.current.onLeftClick += Stab;
        EventManager.current.onGuardStab += GuardStabbed;
    }

    protected override void PlayMicrogame()
    {
        base.PlayMicrogame();
    }

    protected override void StopMicrogame()
    {
        base.StopMicrogame();
    }
    void Stab()
    {
        if (!knife.GetReturning())
        {
            knife.SetStabbing(true);
        }         
    }

    void GuardStabbed()
    {
        timesStabbed++;
        Debug.Log(timesStabbed);
        knife.SetReturning(true);
    }
}
