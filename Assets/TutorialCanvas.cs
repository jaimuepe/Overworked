﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialCanvas : MonoBehaviour
{
    public Text tutorialText;
    public Text commandtext;

    public Image tutorialPanel;
    public Image commandPanel;

    public float textFadeTime;

    public IEnumerator DisplayCommand(string text)
    {
        return Coroutines.Chain(
         Coroutines.Join(
             Coroutines.Wrap(() => commandtext.text = text),
             Coroutines.FadeAlpha01(commandtext, textFadeTime),
             Coroutines.FadeAlpha01(commandPanel, textFadeTime)));
    }

    public IEnumerator HideCommand()
    {
        return Coroutines.Join(
                Coroutines.FadeAlpha10(commandtext, textFadeTime),
                Coroutines.FadeAlpha10(commandPanel, textFadeTime));
    }

    public IEnumerator DisplayText(string text, float length)
    {
        return Coroutines.Chain(
            Coroutines.Join(
                Coroutines.Wrap(() => tutorialText.text = text),
                Coroutines.FadeAlpha01(tutorialText, textFadeTime),
                Coroutines.FadeAlpha01(tutorialPanel, textFadeTime)),
            Coroutines.Wait(length),
            Coroutines.Join(
                Coroutines.FadeAlpha10(tutorialText, textFadeTime),
                Coroutines.FadeAlpha10(tutorialPanel, textFadeTime))
        );
    }
}