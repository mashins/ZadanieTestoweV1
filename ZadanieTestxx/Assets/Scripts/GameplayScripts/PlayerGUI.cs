using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerGUI : MonoBehaviour
{
    public GUISkin guiskin;
    public Texture texture;
    public Texture cross;
    public Vector2 crossSize;

    public float time;
    void Start()
    {
        EventManager.GetDamageEvent += GetDamageEvent;
        EventManager.ChangeSceneEvent += ChangeSceneEvent;
    }

    public int lives = 3;

    private void GetDamageEvent()
    {
        lives--;
        if (lives <= 0)
        {
            EventManager.StartChangeSceneEvent(2);
        }
    }
    private void ChangeSceneEvent(int sceneID)
    {
        EventManager.StartEndingCalcEvent(0, 0, 0, 0, 0, 0, 0, 0, 0, DisplayTime(time));
        
        Debug.Log(DisplayTime(time));
        SceneManager.LoadScene(sceneID);
    }
    private void OnGUI()
    {
        Rect statsRect = new Rect(0, 0, 230, 130);
        GUI.Window(0, statsRect, DoMyWindow," ", guiskin.box);

        
        Rect centerRect = new Rect((Screen.width - crossSize.x)*0.5f,(Screen.height - crossSize.y) * 0.5f, crossSize.x, crossSize.y);
        GUI.Label(centerRect, cross);
    }

    private void Update()
    {
        time += Time.deltaTime;
    }

    void DoMyWindow(int windowID)
    {
        for (int i = 0; i < lives; i++)
        {
            Rect lifeRect = new Rect(5 + 75 * i, 5, 70, 70);
            GUI.Label(lifeRect, texture);
        }

        Rect timeRect = new Rect(5, 80, 220, 40);
        GUI.Label(timeRect, DisplayTime(time), guiskin.box);
    }
    string DisplayTime(float timeToDisplay)
    {
        float hours = Mathf.FloorToInt(timeToDisplay / 3600);
        float minutes = Mathf.FloorToInt(timeToDisplay % 3600/60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        return string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
    }
    private void OnDisable()
    {
        EventManager.GetDamageEvent -= GetDamageEvent;
        EventManager.ChangeSceneEvent -= ChangeSceneEvent;
    }
}
