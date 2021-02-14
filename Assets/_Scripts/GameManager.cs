using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum Difficulty
{
    NONE = 0,
    DEFAULT = 1,
    EASY = 2,
    MEDIUM = 3,
    HARD = 4
}

public class GameManager : MonoBehaviour
{
    public Difficulty difficulty;
}
