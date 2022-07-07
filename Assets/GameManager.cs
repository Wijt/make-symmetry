using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI timeText;

    public float elapsedSecond = 0;

    public List<PixelControl> controlList = new();

    // Start is called before the first frame update
    void Start()
    {
        foreach (PixelControl pc in FindObjectsOfType<PixelControl>())
        {
            controlList.Add(pc);
        }
    }

    public void Finish()
    {
        foreach(PixelControl pc in controlList)
            if (pc.isOkey == false) return;

        Debug.Log("FINITO!");

    }

    // Update is called once per frame
    void Update()
    {
        elapsedSecond += Time.deltaTime;
        timeText.text = GetStringTime((int)elapsedSecond);
    }

    public static string Pad(int num)
    {
        string res = null;
        if (num < 10)
            res = "0" + num;
        else
            res = "" + num;

        return res;
    }

    public string GetStringTime(int time)
    {
        string res = "";
        int hour, min, sec;
        if (time >= 0)
        {
            hour = time / 3600;
            time %= 3600;
            min = time / 60;
            sec = time % 60;

            res = Pad(min) + ":" + Pad(sec);
        }
        return res;
    }
}