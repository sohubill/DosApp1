using System.Collections;
using System.Collections.Generic;
using Unity.UIWidgets.engine;
using Unity.UIWidgets.ui;
using Unity.UIWidgets.widgets;
using UnityEngine;

public class DosApp : UIWidgetsPanel
{
    protected override void OnEnable()
    {
        base.OnEnable();
        Window.onFrameRateCoolDown = null;
        Window.onFrameRateSpeedUp = null;
        Application.targetFrameRate = 60;
    }

    protected override Widget createWidget()
    {

        FontManager.instance.addFont(Resources.Load<Font>("MaterialIcons-Regular"), familyName: "Material Icons");
        return new DesignPage();
    }
}
