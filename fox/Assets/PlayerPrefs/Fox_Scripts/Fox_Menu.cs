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
        // Kay�tl� bilgi var m� kontrol�. E�er varsa Load butonunu aktifle�tiriyoruz
        if (PlayerPrefs.HasKey("posX"))
        {
            loadButton.interactable = true;
        }
    }
    // Yeni oyun fonksiyonu
    public void StartNewGame()
    {
        // Kay�tl� bilgi var m� kontrol�. E�er varsa b�t�n kay�tl� bilgileri siliyoruz ve yeni bir oyun ba�lat�yoruz
        if (PlayerPrefs.HasKey("posX"))
        {
            PlayerPrefs.DeleteAll();
            SceneManager.LoadScene("Game");
        }
        // Yoksa direkt oyunu ba�lat�yoruz
        else
        {
            SceneManager.LoadScene("Game");
        }
    }
    // Oyunu b�t�n kay�tl� bilgilerle ba�latan bir fonksiyon 
    public void LoadGame()
    {
        // E�er kay�tl� bilgi varsa oyunu ba�latma
        if (PlayerPrefs.HasKey("posX"))
        {
            SceneManager.LoadScene("Game");
        }
    }
}
