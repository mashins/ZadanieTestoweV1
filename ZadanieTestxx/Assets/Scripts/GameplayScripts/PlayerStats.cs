using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    //main
    public List<Stats> stats = new List<Stats>();
    string time;

    //Additional
    int completedRooms;
    public int allRooms = 4;

    //for script
    public GUISkin guiskin;

    public Vector2 sizeEndWindow;
    public Vector2 offset;
    public Vector2 offsetBox;

    void Start()
    {
        EventManager.EndingCalcEvent += EndingCalcEvent;
        DontDestroyOnLoad(this);
    }

    private void EndingCalcEvent(int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8, int arg9, string arg10)
    {
        stats[0].value += arg1;

        stats[1].value += arg2;

        stats[2].value += arg3;

        stats[3].value += arg4;

        stats[4].value += arg5;

        stats[5].value += arg6;

        stats[6].value += arg7;

        stats[7].value += arg8;

        completedRooms += arg9;

        time = arg10;
    }

    private void Update()
    {
        if (completedRooms == 4)
        {
            EventManager.StartChangeSceneEvent(2);
            completedRooms = 0;
        }
    }
    private void OnGUI()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            Rect endWindowRect = new Rect((Screen.width - sizeEndWindow.x) / 2, (Screen.height - sizeEndWindow.y) / 2, sizeEndWindow.x, sizeEndWindow.y);
            GUI.Window(2, endWindowRect, DoMyWindow, "Podsumowanie rozgrywki", guiskin.window);

        }
    }

    void DoMyWindow(int windowID)
    {
        Rect labelRect = new Rect(10, 60 + 45 * 3, sizeEndWindow.x - 20, 40);
        GUI.Label(labelRect, "Liczba pope³nionych blêdów:", guiskin.label);
        for (int i = 0; i < stats.Count + 1; i++)
        {
            int newI = i - 1;
            if (i == 0)
            {
                int offsetX = 80;
                Rect statsWindowRect = new Rect(10, 60 + 45 * i, sizeEndWindow.x - 70 - offsetX, 40);
                GUI.Label(statsWindowRect, "Czas dzia³ania: ", guiskin.box);
                Rect statsBoxRect = new Rect(sizeEndWindow.x - 50 - offsetX, 60 + 45 * i, 40 + offsetX, 40);
                GUI.Label(statsBoxRect, time, guiskin.box);
            }
            else if (i < 3)
            {
                Rect statsWindowRect = new Rect(10, 60 + 45 * i, sizeEndWindow.x - 70 - offsetBox.x, 40);
                GUI.Label(statsWindowRect, stats[newI].name + ": ", guiskin.box); 
                Rect statsBoxRect = new Rect(sizeEndWindow.x - 50 - offsetBox.x, 60 + 45 * i, 40 + offsetBox.x, 40);
                GUI.Label(statsBoxRect, stats[newI].value.ToString(), guiskin.box);
            }
            else
            {
                Rect statsWindowRect = new Rect(10 + offset.x, 60 + offset.y + 45 * i, sizeEndWindow.x - 70 - offset.x - offsetBox.x, 40);
                GUI.Label(statsWindowRect, stats[newI].name + ": ", guiskin.box);
                Rect statsBoxRect = new Rect(sizeEndWindow.x - 50 - offsetBox.x, 60 + offset.y + 45 * i, 40 + offsetBox.x, 40);
                GUI.Label(statsBoxRect, stats[newI].value.ToString(), guiskin.box);
            }
        }

    }
    private void OnDisable()
    {
        EventManager.EndingCalcEvent -= EndingCalcEvent;
    }

    [System.Serializable]
    public class Stats
    {
        public string name;
        public int value;
    }
}
