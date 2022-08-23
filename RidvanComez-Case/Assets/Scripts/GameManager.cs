using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLibrary;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public delegate void Delegate(bool dogruKapi);
    public Delegate OnTouchGate;
    [Header("LEVEL VERÝLERÝ"), SerializeField]
    private List<SoruVerileri> sorular = new();
    private Scene scene;

    [Header("KARAKTER VERÝLERÝ"), SerializeField]
    private List<GameObject> karakterler;

    [Header("OYUN VERÝLERÝ"), SerializeField]
    private TextMeshProUGUI aciklama;

    [SerializeField]
    private List<GameObject> paneller;

    [SerializeField]
    private List<TextMeshProUGUI> panelTextleri;

    private int soruSayisi;

    private void Awake()
    {
        if (PlayerPrefs.GetString("Cinsiyet") == "Kadin")
        {
            karakterler[0].SetActive(true);
        }
        else
        {
            karakterler[1].SetActive(true);
        }
    }
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        OnTouchGate = TouchGate;
        soruSayisi = 0;
        GameLibraryDescription();
    }

    private void GameLibraryDescription()
    {
        if (soruSayisi < sorular.Count)
        {
            for (int i = 0; i < sorular[soruSayisi].Kapilar.Count; i++)
            {
                sorular[soruSayisi].Kapilar[i].KapiText.text = sorular[soruSayisi].Kapilar[i].KapiAdi;
                sorular[soruSayisi].Kapilar[i].KapiObject.tag = "Kapi" + sorular[soruSayisi].Kapilar[i].DogruKapi.ToString();
                if (sorular[soruSayisi].Kapilar[i].DogruKapi)
                {
                    panelTextleri[0].text = sorular[soruSayisi].Kapilar[i].KapiAciklama;
                }
                else
                {
                    panelTextleri[1].text = sorular[soruSayisi].Kapilar[i].KapiAciklama;
                }
            }


            aciklama.text = sorular[soruSayisi].SoruAciklama;
        }
        else
        {
            //oyun sonu
            paneller[2].SetActive(true);
            Time.timeScale = 0;
            if (PlayerPrefs.GetString("Cinsiyet") == "Erkek")
            {
                //yeni level eklerken aþaðýdaki if komutundaki -3 ü deðiþtirmeyi unutma
                if (PlayerPrefs.GetInt("ErkekLevel") == scene.buildIndex - 3)
                {
                    PlayerPrefs.SetInt("ErkekLevel", PlayerPrefs.GetInt("ErkekLevel") + 1);
                }
            }
            else
            {
                if (PlayerPrefs.GetInt("KadinLevel") == scene.buildIndex)
                {
                    PlayerPrefs.SetInt("KadinLevel", PlayerPrefs.GetInt("KadinLevel") + 1);
                }
            }
        }
    }


    private void TouchGate(bool trueGate)
    {
        if (trueGate)
        {
            paneller[0].SetActive(true);
            paneller[1].SetActive(false);
        }
        else
        {
            paneller[0].SetActive(false);
            paneller[1].SetActive(true);
        }

        Time.timeScale = 0;
    }

    public void PaneliKapat()
    {
        paneller[0].SetActive(false);
        soruSayisi++;
        Time.timeScale = 1;
        GameLibraryDescription();
    }

    public void OyunuDurdur()
    {
        if (!paneller[0].activeSelf && !paneller[1].activeSelf && !paneller[2].activeSelf)
        {
            if (Time.timeScale == 0)
                Time.timeScale = 1;
            else if (Time.timeScale == 1)
                Time.timeScale = 0;
        }
    }

    public void Butonlar(string butonTipi)
    {
        Time.timeScale = 1;
        switch (butonTipi)
        {
            case "AnaMenu":
                SceneManager.LoadScene(0);
                break;
            case "YenidenBaslat":
                SceneManager.LoadScene(scene.buildIndex);
                break;
            case "SonrakiLevel":
                //burada yebi level eklersen if olan yerdeki eþitlikteki sabit sayýyý güncellemeyi unutma
                if ((scene.buildIndex + 1 <= 3 && PlayerPrefs.GetString("Cinsiyet") == "Kadin") || (scene.buildIndex + 1 <= 6 && PlayerPrefs.GetString("Cinsiyet") == "Erkek"))
                {
                    SceneManager.LoadScene(scene.buildIndex + 1);
                }
                else
                {
                    Butonlar("YenidenBaslat");
                }
                break;
        }
    }
}
