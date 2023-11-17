using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Score Object", menuName = "Game/Score Object")]
public class ScoreObject : ScriptableObject
{
    public int score = 0;
}
