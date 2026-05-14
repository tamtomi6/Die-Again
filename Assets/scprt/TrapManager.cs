using UnityEngine;
using System.Collections;

public class TrapManager : MonoBehaviour
{
    private Transform[] blocks;

    public float dropDistance = 2f;
    public float speed = 3f;

    bool activated = false;

    void Start()
    {
        blocks = GetComponentsInChildren<Transform>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !activated)
        {
            activated = true;

            GetComponent<BoxCollider>().enabled = false;
            StartCoroutine(FallAll());
        }
    }

    IEnumerator FallAll()
    {
        Vector3[] targets = new Vector3[blocks.Length];

        for (int i = 1; i < blocks.Length; i++)
        {
            targets[i] = blocks[i].position + Vector3.down * dropDistance;
        }

        bool moving = true;

        while (moving)
        {
            moving = false;

            for (int i = 1; i < blocks.Length; i++)
            {
                blocks[i].position = Vector3.MoveTowards(
                    blocks[i].position,
                    targets[i],
                    speed * Time.deltaTime
                );

                if (Vector3.Distance(blocks[i].position, targets[i]) > 0.01f)
                {
                    moving = true;
                }
            }

            yield return null;
        }
    }
}