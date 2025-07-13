using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fox_Menu : MonoBehaviour
{
    // Load Game butonuna referans
    [SerializeField] Button loadButton;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        // Kayýtlý bilgi var mý kontrolü. Eðer varsa Load butonunu aktifleþtiriyoruz
        if (PlayerPrefs.HasKey("posX"))
        {
            loadButton.interactable = true;
        }
    }
    // Yeni oyun fonksiyonu
    public void StartNewGame()
    {
        // Kayýtlý bilgi var mý kontrolü. Eðer varsa bütün kayýtlý bilgileri siliyoruz ve yeni bir oyun baþlatýyoruz
        if (PlayerPrefs.HasKey("posX"))
        {
            PlayerPrefs.DeleteAll();
            SceneManager.LoadScene("Game");
        }
        // Yoksa direkt oyunu baþlatýyoruz
        else
        {
            SceneManager.LoadScene("Game");
        }
    }
    // Oyunu bütün kayýtlý bilgilerle baþlatan bir fonksiyon 
    public void LoadGame()
    {
        // Eðer kayýtlý bilgi varsa oyunu baþlatma
        if (PlayerPrefs.HasKey("posX"))
        {
            SceneManager.LoadScene("Game");
        }
    }
}
