using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Reactietestbutten : MonoBehaviour
{
    public Button startbut;
    public Button stopbut;
    public GameObject startbutObject;
    public GameObject stopbutObject;
    public Text gametimer;

    private float startTime;
    private bool isTiming = false;
    private System.Random random = new System.Random();

    private void Start()
    {
        startbut.onClick.AddListener(StartTimerButton);
        stopbut.onClick.AddListener(StopTimerButton);
    }

    public void StartTimerButton()
    {
        startbutObject.SetActive(false);
        gametimer.text = "Get ready";
        StartCoroutine(WaitAndStartTimer());
    }

    private IEnumerator WaitAndStartTimer()
    {
        int delay = random.Next(1, 6);
        yield return new WaitForSeconds(delay);
        startTime = Time.time;
        isTiming = true;
        stopbutObject.SetActive(true);
        gametimer.text = "Click now!";
    }

    public void StopTimerButton()
    {
        if (isTiming)
        {
            float reactionTime = Time.time - startTime;
            gametimer.text = "Your time: " + reactionTime.ToString("F3") + "s";
            isTiming = false;
            startbutObject.SetActive(true);
            stopbutObject.SetActive(false);
        }
    }
}