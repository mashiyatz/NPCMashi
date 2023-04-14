using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateJunk : MonoBehaviour
{
    public GameObject[] junkPrefabs;
    public int junkMin;
    public int junkMax;
    private int junkAmount;

    void Start()
    {
        StartCoroutine(Generate());
    }

    IEnumerator Generate()
    {
        junkAmount = Random.Range(junkMin, junkMax);

        for (int i = 0; i <= junkAmount; i++)
        {
            Instantiate(
                junkPrefabs[Random.Range(0, junkPrefabs.Length)],
                new Vector3(transform.position.x, transform.position.y + 0.01f, transform.position.z),
                Quaternion.identity
            );
            yield return new WaitForSeconds(0.1f);
        }
    }
}
