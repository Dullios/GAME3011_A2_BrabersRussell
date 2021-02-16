using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
    [Header("Settings")]
    public Difficulty difficulty;

    [Header("Safe Objects")]
    public GameObject safe;
    public GameObject safeDoor;
    public GameObject[] rings;

    public void SetDifficulty(TMP_Dropdown drop)
    {
        difficulty = (Difficulty)drop.value + 2;
    }

    public void StartGame()
    {
        if (difficulty == Difficulty.DEFAULT)
            difficulty = Difficulty.EASY;

        safe.SetActive(true);

        for(int i = 0; i < (int)difficulty; i++)
        {
            rings[i].SetActive(true);
        }
    }
}