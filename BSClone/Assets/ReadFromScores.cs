using TMPro;
using UnityEngine;
using System.IO;

public class ScoreLoader : MonoBehaviour
{
    public TMP_Text textField;
    private string filePath = "Assets/scores.txt";

    void Start()
    {
        LoadScore();
    }

    void LoadScore()
    {
        if (File.Exists(filePath))
        {
            string fileContent = File.ReadAllText(filePath);
            textField.text = fileContent;
        }
        else
        {
            Debug.LogWarning("File 'scores.txt' not found in the Assets folder.");
        }
    }
}
