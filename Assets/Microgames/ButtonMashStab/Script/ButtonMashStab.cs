using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VInspector;

public class ButtonMashStab : Microgame
{
    [SerializeField] KnifeMovement knife;
    [SerializeField] int stabQuota;
    int timesStabbed = 0;

    override protected void Start()
    {
        base.Start();
        InputManager.current.onLeftClick += Stab;
        EventManager.current.onGuardStab += GuardStabbed;
    }

    override protected void PlayMicrogame()
    {
        base.PlayMicrogame();
    }

    override protected void StopMicrogame()
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
        
        if (timesStabbed >= stabQuota)
        {
            result = true;
            Debug.Log("You Won!");
        }
    }
}
