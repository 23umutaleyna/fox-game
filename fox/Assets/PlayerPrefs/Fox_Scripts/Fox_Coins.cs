using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Fox_Coins : MonoBehaviour
{
    Fox_Logic foxLogic;
    //obje ad�
    public string objectName;
    //obje al�nm�� m�?
    public bool isTaken;

    private void Start()
    {
        foxLogic = FindObjectOfType<Fox_Logic>();
        // E�er bu isimde bir kayd�m�z varsa
        if (PlayerPrefs.HasKey(objectName))
        {
            // Bu kayd�n de�erinin 1 olup olmad���na bakmak, sonucu isTaken de�i�keninde depolamak 
            // E�er b�yle bir kay�t varsa, 1'i 1'le kar��la�t�raca��z yani her zaman True geri d�n��� alaca��z
            isTaken = PlayerPrefs.GetInt(objectName) == 1;
            // isTaken de�i�keninin de�erine g�re objenin durumunu aktive/deaktive etmek 
            gameObject.SetActive(!isTaken);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        //E�er paraya dokunan objenin "Player" etiketi varsa
        if (other.CompareTag("Player"))
        {
            // De�i�keni ayarlamak
            isTaken = true;
            // Objenin ad�n� kullanarak bir kay�t olu�turmak, i�inde "1" bilgisini tutmak
            PlayerPrefs.SetInt(objectName, 1);
            // Objeyi deaktive etmek
            gameObject.SetActive(false);
            // Kay�tl� bilgilerden para miktar�na bakmak ve ge�ici bir de�i�kende depolamak
            // E�er b�yle bir bilgi yoksa de�eri s�f�ra e�itlemek
            var value = PlayerPrefs.GetInt("Coins", 0);
            // "Coins" alan�nda saklanan para miktar�n� g�ncellemek
            // Bunu yapabilmek i�in ge�ici de�i�kendeki de�ere bir eklememiz laz�m
            PlayerPrefs.SetInt("Coins", value + 1);
            // UI g�ncelleme fonksiyonunu �a��ral�m (hatay� g�rmezden gelebilirsiniz; daha fonksiyonu yazmad�k)
            foxLogic.GetCoin();
        }
    }
}
