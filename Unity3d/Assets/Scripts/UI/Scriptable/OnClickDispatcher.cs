﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using GameFramework.Story;

public class OnClickDispatcher : MonoBehaviour
{
    public readonly string MessageId = "OnClick";
    public string WindowName = "";
    public string EventTag = "";
    public InputField[] InputLabels = null;
    public Toggle[] InputToggles = null;
    public Slider[] InputSliders = null;

    public void OnClickHandler()
    {
        int strCt = 0;
        int boolCt = 0;
        int floatCt = 0;
        string[] strVals = null;
        int[] boolVals = null;
        float[] floatVals = null;
        if (null != InputLabels) {
            strCt = InputLabels.Length;
            strVals = new string[strCt];
            for (int i = 0; i < strCt; ++i) {
                strVals[i] = InputLabels[i].text;
            }
        }
        if (null != InputToggles) {
            boolCt = InputToggles.Length;
            boolVals = new int[boolCt];
            for (int i = 0; i < boolCt; ++i) {
                boolVals[i] = InputToggles[i].isOn ? 1 : 0;
            }
        }
        if (null != InputSliders) {
            floatCt = InputSliders.Length;
            floatVals = new float[floatCt];
            for (int i = 0; i < floatCt; ++i) {
                floatVals[i] = InputSliders[i].value;
            }
        }
        string tag;
        if (string.IsNullOrEmpty(EventTag)) {
            Text label = gameObject.GetComponent<Text>();
            if (null != label) {
                tag = label.text;
            } else {
                tag = "";
            }
        } else {
            tag = EventTag;
        }
        GfxStorySystem.Instance.SendMessage(string.Format("{0}:{1}", WindowName, MessageId), tag, strCt, strVals, boolCt, boolVals, floatCt, floatVals);
    }
}
