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
        // PlayerPrefs'in farklý alanlarýna karakterin pozisyonunun eksenlerini kaydetmek
        PlayerPrefs.SetFloat("posX", playerPos.x);
        PlayerPrefs.SetFloat("posY", playerPos.y);
        PlayerPrefs.SetFloat("posZ", playerPos.z);
        // Verileri kaydetmek
        PlayerPrefs.Save();
        saveWarning.text = "Kayýt Baþarýlý";
        Invoke("DeleteText", 1);
    }
    void DeleteText()
    {
        saveWarning.text = "  ";
    }

    private void OnTriggerEnter(Collider other)
    {
        // Eðer portaldan Player etiketli bir objenin geçiþi tetiklenirse
        if (other.CompareTag("Player"))
        {
            // Objenin pozisyonuna bakýp bu bilgiyi SavePosition fonksiyonuna iletelim
            Vector3 pos = other.transform.position;
            SavePosition(pos);
        }
    }

}
