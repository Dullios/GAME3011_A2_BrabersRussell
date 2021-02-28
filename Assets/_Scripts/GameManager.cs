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

[System.Serializable]
public enum Skill
{
    BASIC,
    ADEPT,
    SKILLED,
    MASTER
}

public class GameManager : MonoBehaviour
{
    [Header("Settings")]
    public Difficulty difficulty;

    [Header("Safe Objects")]
    public GameObject safe;
    public GameObject safeDoor;
    public GameObject[] rings;

    [Header("Player Skill")]
    [SerializeField]
    private Skill playerSkill;
    [SerializeField]
    private TextMeshProUGUI skillText;

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

    public void SkillSlider(Slider slider)
    {
        switch(slider.value)
        {
            case 1:
                playerSkill = Skill.BASIC;
                skillText.text = "Basic";
                break;
            case 2:
                playerSkill = Skill.ADEPT;
                skillText.text = "Adept";
                break;
            case 3:
                playerSkill = Skill.SKILLED;
                skillText.text = "Skilled";
                break;
            case 4:
                playerSkill = Skill.MASTER;
                skillText.text = "Master";
                break;
        }
    }
}