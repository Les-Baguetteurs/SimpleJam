using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskSlider : Task
{

    public Slider[] sliders;
    public float[] targetHeights;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        targetHeights = new float[3];
        for (int i = 0; i < 3; i++) {
            targetHeights[i] = Random.Range(0, 10);
            RectTransform arrow = System.Array.Find(sliders[i].GetComponentsInChildren<RectTransform>(), item => item.name == "Arrow");
            arrow.localPosition += new Vector3(targetHeights[i] * 42.2f, 0, 0);
            sliders[i].value = Random.Range(0, 10);
        }
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        if (IsAllCorrect()) {
            CompleteTask();
        }
    }

    bool IsAllCorrect() {
        for (int i = 0; i < 3; i++) {
            if (sliders[i].value != targetHeights[i])
                return false;
        }
        return true;
    }
}
