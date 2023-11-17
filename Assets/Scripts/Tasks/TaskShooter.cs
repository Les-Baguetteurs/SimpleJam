using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TaskShooter : Task
{
    // Start is called before the first frame update
    public Texture2D crosshair;
    public GameObject canvas;
    public int aliensShotInt = 0;
    public TMP_Text aliens_shot;
    public Button[] aliens = new Button[5];
    public Button[] asteroids = new Button[5];
    public override void Start()
    {
        base.Start();
        Cursor.SetCursor(crosshair, new Vector2(11, 11), CursorMode.Auto);
        aliens_shot.SetText("0/5 Aliens Shot");
        for (int i = 0; i < aliens.Length; i++) {
            aliens[i].transform.position = new Vector2(Random.Range(100f, 700f), Random.Range(100f, 350f));
            asteroids[i].transform.position = new Vector2(Random.Range(100f, 700f), Random.Range(100f, 350f));
        }
    }
    public void onAlienShot(GameObject shot_alien)
    {
        aliensShotInt++;
        aliens_shot.SetText(aliensShotInt + "/5 Aliens Shot");
        Destroy(shot_alien);
        AudioManager.Instance.Play("Shoot");
        if (aliensShotInt >= 5) {
            CompleteTask();
        }
    }

    public void onAsteroidShot(GameObject shot_asteroid) {
        FailTask();
    }

    public override void CloseUI()
    {
        Cursor.SetCursor(null, new Vector2(0, 0), CursorMode.Auto);
        base.CloseUI();
    }
}
