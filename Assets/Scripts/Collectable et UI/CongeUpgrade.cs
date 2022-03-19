using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CongeUpgrade : MonoBehaviour
{
    /// <summary>
    /// Valeur de l'énergie regagner au contact
    /// </summary>
    [SerializeField]
    private int _addConge = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            GameManager.Instance.PlayerData.IncrConge(this._addConge);
            GameObject.Destroy(this.gameObject);
        }
    }


}
