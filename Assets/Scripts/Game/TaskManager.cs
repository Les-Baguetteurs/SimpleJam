using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TaskManager : MonoBehaviour
{
    public static TaskManager Instance { get; private set; }
    public float distanceDecayPerFailure = 1f;
    public float intensityScale = 1f;
    public float minInterval = 2f;
    public float maxInterval = 60f;
    public int startDistance = 60;
    public float chanceEasy = 0.6f;
    public float chanceMedium = 0.3f;
    public float chanceHard = 0.1f;
    public int distancePerPoint = 10;
    public float timePerTask = 20f;
    public float distanceAnimationLength = 3f;
    public GameObject UICanvas;
    float timeElapsed;
    int score;
    TMP_Text scoreText;
    float distance;
    Slider distanceSlider;
    float timeSinceLastDistanceUpdate = 0;
    int tasksCompleted;
    float nextBreak;
    public Interactable[] tasks;


    int activeTasks;

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
        timeSinceLastDistanceUpdate += Time.deltaTime;

        if (timeElapsed > nextBreak)
        {
            ActivateTask();
            nextBreak = timeElapsed + Random.Range(minInterval, Mathf.Max(minInterval, maxInterval - timeElapsed * intensityScale));
        }
        UpdateDistanceUI();
    }

    void ActivateTask()
    {
        int index = Mathf.FloorToInt(Random.Range(0, tasks.Length - 0.00001f));
        if (!tasks[index].Activate()) return;
        activeTasks++;
        scheduleMusic();
    }

    void UpdateDistanceUI()
    {
        distanceSlider.value = Mathf.Lerp(distance, distanceSlider.value,
                                         (distanceAnimationLength - timeSinceLastDistanceUpdate) / distanceAnimationLength);
    }

    public void addPoints(int points)
    {
        score += points;
        scoreText.text = score.ToString();
    }

    public void CompleteTask(int points)
    {
        addPoints(points);
        distance += distancePerPoint * points;
        distance = Mathf.Clamp(distance, 0, startDistance);
        timeSinceLastDistanceUpdate = 0;
        activeTasks--;
        AudioManager.Instance.Play("Ding");
        scheduleMusic();
    }
    public void FailTask()
    {
        distance -= distanceDecayPerFailure;
        timeSinceLastDistanceUpdate = 0;
        activeTasks--;
        AudioManager.Instance.Play("Fail");
        scheduleMusic();
        CheckIfLost();
    }

    void scheduleMusic()
    {
        string music;
        if (activeTasks <= 1)
            music = "stage1";
        else if (activeTasks <= 2)
            music = "stage2";
        else
            music = "stage3";
        AudioManager.Instance.SetScheduledSound(music);
    }

    void CheckIfLost()
    {
        if (distance <= 0)
        {
            // TODO go to lose screen
        }
    }
}
