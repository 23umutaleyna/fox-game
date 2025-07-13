using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Fox_Coins : MonoBehaviour
{
    Fox_Logic foxLogic;
    //obje adý
    public string objectName;
    //obje alýnmýþ mý?
    public bool isTaken;

    private void Start()
    {
        foxLogic = FindObjectOfType<Fox_Logic>();
        // Eðer bu isimde bir kaydýmýz varsa
        if (PlayerPrefs.HasKey(objectName))
        {
            // Bu kaydýn deðerinin 1 olup olmadýðýna bakmak, sonucu isTaken deðiþkeninde depolamak 
            // Eðer böyle bir kayýt varsa, 1'i 1'le karþýlaþtýracaðýz yani her zaman True geri dönüþü alacaðýz
            isTaken = PlayerPrefs.GetInt(objectName) == 1;
            // isTaken deðiþkeninin deðerine göre objenin durumunu aktive/deaktive etmek 
            gameObject.SetActive(!isTaken);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        //Eðer paraya dokunan objenin "Player" etiketi varsa
        if (other.CompareTag("Player"))
        {
            // Deðiþkeni ayarlamak
            isTaken = true;
            // Objenin adýný kullanarak bir kayýt oluþturmak, içinde "1" bilgisini tutmak
            PlayerPrefs.SetInt(objectName, 1);
            // Objeyi deaktive etmek
            gameObject.SetActive(false);
            // Kayýtlý bilgilerden para miktarýna bakmak ve geçici bir deðiþkende depolamak
            // Eðer böyle bir bilgi yoksa deðeri sýfýra eþitlemek
            var value = PlayerPrefs.GetInt("Coins", 0);
            // "Coins" alanýnda saklanan para miktarýný güncellemek
            // Bunu yapabilmek için geçici deðiþkendeki deðere bir eklememiz lazým
            PlayerPrefs.SetInt("Coins", value + 1);
            // UI güncelleme fonksiyonunu çaðýralým (hatayý görmezden gelebilirsiniz; daha fonksiyonu yazmadýk)
            foxLogic.GetCoin();
        }
    }
}
