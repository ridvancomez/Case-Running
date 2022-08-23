using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamera : MonoBehaviour
{
    [SerializeField]
    private Vector3 fark;

    private Transform hedef;

    [SerializeField]
    List<GameObject> karakterler;
    void Start()
    {
        foreach (var karakter in karakterler)
        {
            if (karakter.activeSelf)
            {
                hedef = karakter.transform;
                break;
            }
        }
    }

    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, hedef.position - fark, .015f);
    }
}
