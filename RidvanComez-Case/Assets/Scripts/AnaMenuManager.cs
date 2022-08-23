using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using GameLibrary;
using UnityEngine.UI;

public class AnaMenuManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> paneller;
    [SerializeField]
    private TextMeshProUGUI puanText;

    [Header("LEVEL SAHNESÝ ÝÇÝN GEREKENLER"), SerializeField]
    private List<Button> kadinLevelButonlar;
    [SerializeField]
    private List<TextMeshProUGUI> kadinButonText;
    [SerializeField]
    private List<Button> erkekLevelButonlar;
    [SerializeField]
    private List<TextMeshProUGUI> erkekButonText;

    private void Awake()
    {
        PlayerPrefsProcess.PlayerPrefsPowerUp();
    }
    private void Start()
    {
        puanText.text = "Puan: " +  PlayerPrefs.GetInt("Puan");
        LevelButonKontrol();
    }


    private void LevelButonKontrol()
    {
        for (int i = 1; i <= kadinButonText.Count; i++)
        {
            kadinButonText[i-1].text = "Kadýn için Level " + i.ToString(); 
        }

        for (int i = 1; i <= erkekButonText.Count; i++)
        {
            erkekButonText[i - 1].text = "Erkek için Level " + i.ToString();
        }

        for (int i = 1; i <= kadinLevelButonlar.Count; i++)
        {
            if(i > PlayerPrefs.GetInt("KadinLevel"))
            {
                kadinLevelButonlar[i - 1].interactable = false;
            }
        }

        for (int i = 1; i <= erkekLevelButonlar.Count; i++)
        {
            if (i > PlayerPrefs.GetInt("ErkekLevel"))
            {
                erkekLevelButonlar[i - 1].interactable = false;
            }
        }
    }

    public void PanellerArasiGecis(string panelIsim)
    {
        foreach (var item in paneller)
        {
            item.SetActive(false);
        }
        switch (panelIsim)
        {
            case "AnaMenu":
                paneller[0].SetActive(true);
                break;
            case "LevelSec":
                paneller[1].SetActive(true);
                break;
            case "CinsiyetSec":
                paneller[2].SetActive(true);
                break;
        }
    }

    public void LevelSahneGecis(int sceneBuildIndex)
    {
        if (sceneBuildIndex > 3)
        {
            PlayerPrefs.SetString("Cinsiyet", "Erkek");
        }
        else
        {
            PlayerPrefs.SetString("Cinsiyet", "Kadin");
        }
        SceneManager.LoadScene(sceneBuildIndex);
    }

    public void cikis()
    {
        Application.Quit();
    }
}
