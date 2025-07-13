using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Fox_Save : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] TMP_Text saveWarning;
 
    public void SavePosition(Vector3 playerPos)
    {
        // PlayerPrefs'in farkl� alanlar�na karakterin pozisyonunun eksenlerini kaydetmek
        PlayerPrefs.SetFloat("posX", playerPos.x);
        PlayerPrefs.SetFloat("posY", playerPos.y);
        PlayerPrefs.SetFloat("posZ", playerPos.z);
        // Verileri kaydetmek
        PlayerPrefs.Save();
        saveWarning.text = "Kay�t Ba�ar�l�";
        Invoke("DeleteText", 1);
    }
    void DeleteText()
    {
        saveWarning.text = "  ";
    }

    private void OnTriggerEnter(Collider other)
    {
        // E�er portaldan Player etiketli bir objenin ge�i�i tetiklenirse
        if (other.CompareTag("Player"))
        {
            // Objenin pozisyonuna bak�p bu bilgiyi SavePosition fonksiyonuna iletelim
            Vector3 pos = other.transform.position;
            SavePosition(pos);
        }
    }

}
