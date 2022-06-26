using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskOrder : Task
{

    public Button[] buttons;
    public Sprite[] textures;
    public Image successImg;
    public Color successColor;
    public Color failColor;
    int pos;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        pos = 0;
        for (int i = 0; i < buttons.Length; i++) {
            int swap = Random.Range(0, buttons.Length);
            Button tmp = buttons[swap];
            buttons[swap] = buttons[i];
            buttons[i] = tmp;
        }


        for (int i = 0; i < buttons.Length; i++) {
            buttons[i].image.sprite = textures[i];
        }
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    public void OnClick(Button button) {
        if (button == buttons[pos]) {
            pos++;
            successImg.color = successColor;
            Debug.Log(successColor);
            Debug.Log("Yes");
            if (pos == 10) {
                CompleteTask();
            }
        }
        else {
            pos = 0;
            successImg.color = failColor;
            Debug.Log("No");
        }
    }
}
