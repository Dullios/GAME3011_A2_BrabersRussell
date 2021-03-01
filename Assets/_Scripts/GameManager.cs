using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

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
    public bool gameOver { get; private set; }

    [Header("Settings")]
    public Difficulty difficulty;

    [Header("Player Skill")]
    [SerializeField] private Skill playerSkill;
    [SerializeField] private TextMeshProUGUI skillText;

    [Header("Safe Objects")]
    public GameObject safe;
    public GameObject safeDoor;
    public GameObject[] rings;

    [Header("Timer")]
    [SerializeField] private float timer;
    [SerializeField] private TextMeshProUGUI timerUI;

    [Header("UI Objects")]
    public TMP_Dropdown dropDown;
    public Slider slider;
    public Button button;
    public GameObject gameOverPanel;

    [Header("Sounds")]
    [SerializeField] private AudioSource click;
    [SerializeField] private AudioSource modClick;
    [SerializeField] private AudioMixer clickMixer;

    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void SetDifficulty(TMP_Dropdown drop)
    {
        difficulty = (Difficulty)drop.value + 2;
    }

    public void StartGame()
    {
        ToggleUI(false);
        SetMixerValues();

        if (difficulty == Difficulty.DEFAULT)
            difficulty = Difficulty.EASY;

        safe.SetActive(true);

        for(int i = 0; i < (int)difficulty; i++)
        {
            rings[i].SetActive(true);
        }

        timer = 20 * (int)difficulty;
        StartCoroutine(TimerRoutine());
    }

    IEnumerator TimerRoutine()
    {
        while(timer >= 0)
        {
            timer -= Time.deltaTime;
            timerUI.text = timer.ToString("00.00");
            yield return null;
        }

        GameOver(false);
    }

    public void GameOver(bool win)
    {
        gameOver = true;

        StopAllCoroutines();

        if (win)
            StartCoroutine(SafeDoorRoutine());
        else
        {
            gameOverPanel.SetActive(true);
            gameOverPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "You Lost!";
        }
    }

    IEnumerator SafeDoorRoutine()
    {
        float startRotation = safeDoor.transform.eulerAngles.y;
        float endRotation = startRotation + 90.0f;
        float t = 0.0f;

        while (t < 3.0f)
        {
            t += Time.deltaTime;
            float rotation = Mathf.Lerp(startRotation, endRotation, t / 3.0f);
            safeDoor.transform.eulerAngles = new Vector3(0, rotation, 0);
            yield return null;
        }

        gameOverPanel.SetActive(true);
        gameOverPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "You Win!";
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

    public void ResetGame()
    {
        gameOverPanel.SetActive(false);

        safeDoor.transform.eulerAngles = Vector3.zero;
        for(int i = 0; i < rings.Length; i++)
        {
            if (rings[i].activeSelf)
                rings[i].SetActive(false);
            else
                continue;
        }
        safe.SetActive(false);

        timerUI.text = "00.00";

        ToggleUI(true);

        gameOver = false;
    }

    private void ToggleUI(bool enable)
    {
        dropDown.interactable = enable;
        slider.interactable = enable;
        button.interactable = enable;
    }

    public void PlayClick(bool isCorrect)
    {
        if(isCorrect)
        {
            modClick.Play();
        }
        else
        {
            click.Play();
        }
    }

    private void SetMixerValues()
    {
        float dry = (85.0f - (10.0f * (int)playerSkill)) / 100.0f;
        clickMixer.SetFloat("drymix", dry);
        float wet = (15.0f + (10.0f * (int)playerSkill)) / 100.0f;
        clickMixer.SetFloat("wetmix", wet);
    }
}