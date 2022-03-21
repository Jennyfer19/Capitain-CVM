using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinDeNiveau : MonoBehaviour
{
    [SerializeField]
    private String next_scene;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log(SceneManager.GetActiveScene().name);
            GameManager.Instance.SaveData();
            SceneManager.LoadScene(next_scene);
            GameManager.Instance.PlayerData.AjoutNiveauReussi()

        }
    }
}

