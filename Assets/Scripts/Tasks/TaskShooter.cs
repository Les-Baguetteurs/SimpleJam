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
            aliens[i].transform.position = RandPosOnCanvas();
            asteroids[i].transform.position = RandPosOnCanvas();
        }
    }

    private Vector2 RandPosOnCanvas()
    {
        RectTransform img = canvas.GetComponent<RectTransform>();
        return (Vector2) img.transform.position + new Vector2(Random.Range(img.rect.xMin + 175, img.rect.xMax - 175), Random.Range(img.rect.yMin + 125, img.rect.yMax - 125));
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
