using UnityEngine;
using System.Collections;

public class LightFlicker : Flicker {

    #region implemented abstract members of Flicker

    public override void doAwake()
    {
        return;
    }

    public override void Off()
    {
        light.enabled = false;
    }

    public override void On()
    {
        light.enabled = true;
    }

    #endregion
}
