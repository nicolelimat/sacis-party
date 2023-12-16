using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PortalTeleporterLevel : MonoBehaviour
{
    public TextMeshProUGUI mensagemText;

    void Start()
    {
        mensagemText.gameObject.SetActive(false);
    }

    IEnumerator ShowAndHideMessage(float delay)
    {
        mensagemText.gameObject.SetActive(true);
        yield return new WaitForSeconds(delay);
        mensagemText.gameObject.SetActive(false);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
            if (allEnemies.Length <= 0)
            {
                SceneManager.LoadScene("LevelCabana");
            }
            else
            {
                StartCoroutine(ShowAndHideMessage(2f)); // Exibe a mensagem por 2 segundos
            }
        }
    }
}
