using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TaskManager : MonoBehaviour
{
    public static TaskManager Instance { get; private set; }
    public float distanceDecayPerSecond = 1f;
    public float intensityScale = 1f;
    public float minInterval = 2f;
    public float maxInterval = 60f;
    public int startDistance = 60;
    public float chanceEasy = 0.6f;
    public float chanceMedium = 0.3f;
    public float chanceHard = 0.1f;
    public GameObject UICanvas;
    float timeElapsed;
    int score;
    TMP_Text scoreText;
    float distance;
    Slider distanceSlider;
    int tasksCompleted;
    float nextBreak;
    public Interactable[] easyTasks;
    public Interactable[] mediumTasks;
    public Interactable[] hardTasks;
    // Start is called before the first frame update

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        distanceSlider = UICanvas.GetComponentInChildren<Slider>();
        distanceSlider.maxValue = startDistance;
        distance = startDistance;
        scoreText = UICanvas.GetComponentInChildren<TMP_Text>();
    }
    void Start()
    {
        timeElapsed = 0;
        nextBreak = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        distance -= distanceDecayPerSecond * Time.deltaTime;
        SetDistanceUI(distance);

        if (timeElapsed > nextBreak)
        {
            ActivateTask();
            nextBreak = timeElapsed + Random.Range(minInterval, Mathf.Max(minInterval, maxInterval - timeElapsed * intensityScale));
        }
    }

    void ActivateTask()
    {
        float chance = Random.Range(0, 1);
        if (chance < chanceEasy)
        {
            // Why is Random.Range inclusive that makes zero sense
            int index = Mathf.FloorToInt(Random.Range(0, easyTasks.Length - 0.00001f));
            easyTasks[index].Activate();
        }
        else if (chance < chanceMedium + chanceEasy)
        {
            int index = Mathf.FloorToInt(Random.Range(0, mediumTasks.Length - 0.00001f));
            mediumTasks[index].Activate();
        }
        else if (chance < chanceHard + chanceMedium + chanceEasy)
        {
            int index = Mathf.FloorToInt(Random.Range(0, hardTasks.Length - 0.00001f));
            hardTasks[index].Activate();
        }
    }

    void SetDistanceUI(float distance) {
        distanceSlider.value = distance;
    }

    public void addPoints(int points) {
        score += points;
        scoreText.text = score.ToString();
    }
}
