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
        //panelin yukar�s�na yaz�lacak yaz�
    }


    [Serializable]
    class KapiVerileri
    {
        //kap�lar�n i�indeki yaz�
        public string KapiAdi;
        //kap�lar�n i�indeki textler
        public TextMeshPro KapiText;

        public GameObject KapiObject;
        //do�ru kap� m� yanl�� kap� m�
        public bool DogruKapi;
        //do�ru veya yanl�� kap�da yaz�lacak text yaz�s�

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
