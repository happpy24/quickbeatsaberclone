using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Saber : MonoBehaviour
{
    public LayerMask layer;
    private Vector3 previousPos;
    public Player player;

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1, layer))
        {
            if (hit.transform.gameObject.layer != LayerMask.NameToLayer("StartGame"))
            {
                if (Vector3.Angle(transform.position - previousPos, hit.transform.up) > 130)
                {
                    player.notesHit++;
                    Destroy(hit.transform.parent.gameObject);
                }
                else
                {
                    Destroy(hit.transform.parent.gameObject);
                    player.notesMissed++;
                }
            }
            else
            {
                Destroy(hit.transform.parent.gameObject);
                SceneManager.LoadScene("Gameplay");
            }

        }

        previousPos = transform.position;
    }
}