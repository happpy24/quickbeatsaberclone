using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;
using Meta.WitAi;

public class ScoreSystem : MonoBehaviour
{
    public GameObject textElement;
    public Player player;
    public int miss = 0;
    public int hit = 0;
    public int score = 0;
    public int combo = 0;
    public float scorecombo = 300;
    public TMP_InputField inputField;
    public GameObject spawner;

    private void Start()
    {
        inputField.gameObject.SetActive(false);
    }

    public void Update()
    {
        if (player.notesMissed > miss)
        {
            miss++;
            scorecombo = 300;
            combo = 0;
            UpdateBoard();
        }
        if (player.notesHit > hit)
        {
            hit++;
            combo++;
            scorecombo *= 1 + (combo / 25f);
            score += Mathf.FloorToInt(scorecombo);
            UpdateBoard();
        }
    }

    public void UpdateBoard()
    {
        var tmp = textElement.GetComponent<TextMeshPro>();
        tmp.text = "Score\n" + score + "\nCombo\n" + (combo) + "x";
    }

    public void EndGame()
    {
        Destroy(spawner);
        inputField.gameObject.SetActive(true);
        inputField.Select();
        inputField.ActivateInputField();
        StartCoroutine(WaitForEnterKey());
    }

    private IEnumerator WaitForEnterKey()
    {
        while (!Input.GetKeyDown(KeyCode.Return))
        {
            yield return null;
        }

        SaveScore(inputField.text);
        miss = 0;
        hit = 0;
        score = 0;
        combo = 0;
        SceneManager.LoadScene("Homescreen");
    }

    private void SaveScore(string name)
    {
        string filePath = Application.dataPath + "/scores.txt";
        string scoreEntry = $"{name}: {score}";
        File.AppendAllText(filePath, scoreEntry + "\n");
    }
}
