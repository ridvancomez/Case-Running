using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;

    [Header("KARAKTER VERÝLERÝ"), SerializeField]
    private float speed;
    [SerializeField]
    private float soldanKisitlama;
    [SerializeField]
    private float sagdanKisitlama;


    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && Time.timeScale != 0)
        {
            if (Input.GetAxis("Mouse X") > 0)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x - .1f,
                                                                                    transform.position.y,
                                                                                    transform.position.z), .3f);
            }
            if (Input.GetAxis("Mouse X") < 0)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x + .1f,
                                                                    transform.position.y,
                                                                    transform.position.z), .3f);
            }
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, sagdanKisitlama, soldanKisitlama), transform.position.y, transform.position.z);
        }

        transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "KapiTrue":

                gameManager.OnTouchGate(true);
                break;
            case "KapiFalse":
                gameManager.OnTouchGate(false);
                break;
            case "ÝyiPuan":
                other.gameObject.SetActive(false);
                PlayerPrefs.SetInt("Puan", PlayerPrefs.GetInt("Puan") + 1);
                break;
            case "KotuPuan":
                other.gameObject.SetActive(false);
                PlayerPrefs.SetInt("Puan", PlayerPrefs.GetInt("Puan") - 1);
                break;
        }
    }


}
