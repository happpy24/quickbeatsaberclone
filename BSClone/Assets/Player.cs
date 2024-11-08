using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int notesHit;
    public int notesMissed;

    private void Start()
    {
        notesHit = 0;
        notesMissed = 0;
    }
}
