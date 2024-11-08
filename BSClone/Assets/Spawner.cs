using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
    public GameObject[] cubes;
    public Transform[] points;
    public ScoreSystem scoreSystem;
    public float beat = (60 / 105) * 2;
    private float timer;
    private float deathtimer;
    private bool death = false;

    void Update()
    {
        if (timer > beat)
        {
            GameObject cube = Instantiate(cubes[Random.Range(0, 2)], points[Random.Range(0, 4)]);
            cube.transform.localPosition = Vector3.zero;
            cube.transform.Rotate(transform.forward, 90 * Random.Range(0, 4));
            timer -= beat;
        }

        if (deathtimer >= 82.5f && death == false)
        {
            death = true;
            scoreSystem.EndGame();
        }

        timer += Time.deltaTime;
        deathtimer += Time.deltaTime;
    }
}
