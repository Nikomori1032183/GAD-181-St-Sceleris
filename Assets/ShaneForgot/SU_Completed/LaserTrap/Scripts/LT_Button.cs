using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LT_Button : Button
{
    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        LT_Player_SU player = FindObjectOfType<LT_Player_SU>();
        if (this.name == "Left")
        {
            player.onLeft(true);
        }
        if (this.name == "Right")
        {
            player.onRight(true);
        }
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        LT_Player_SU player = FindObjectOfType<LT_Player_SU>();
        if (this.name == "Left")
        {
            player.onLeft(false);
        }
        if (this.name == "Right")
        {
            player.onRight(false);
        }
    }
}
