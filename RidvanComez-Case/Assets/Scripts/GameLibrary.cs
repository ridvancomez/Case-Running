using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace GameLibrary
{

    [Serializable]
    class SoruVerileri
    {
        public string SoruAciklama;
        public List<KapiVerileri> Kapilar;
        //panelin yukarýsýna yazýlacak yazý
    }


    [Serializable]
    class KapiVerileri
    {
        //kapýlarýn içindeki yazý
        public string KapiAdi;
        //kapýlarýn içindeki textler
        public TextMeshPro KapiText;

        public GameObject KapiObject;
        //doðru kapý mý yanlýþ kapý mý
        public bool DogruKapi;
        //doðru veya yanlýþ kapýda yazýlacak text yazýsý

        public string KapiAciklama;
    }

    [Serializable]
    class PlayerPrefsProcess
    {
        public static void PlayerPrefsPowerUp()
        {
            if(!PlayerPrefs.HasKey("Cinsiyet"))
            {
                PlayerPrefs.SetString("Cinsiyet", "Kadin");
            }

            if(!PlayerPrefs.HasKey("KadinLevel"))
            {
                PlayerPrefs.SetInt("KadinLevel", 1);
            }

            if (!PlayerPrefs.HasKey("ErkekLevel"))
            {
                PlayerPrefs.SetInt("ErkekLevel", 1);
            }

            if(!PlayerPrefs.HasKey("Puan"))
            {
                PlayerPrefs.SetInt("Puan", 0);
            }
        }
    }
}
