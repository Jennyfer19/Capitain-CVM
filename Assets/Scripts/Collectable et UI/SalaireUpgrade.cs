using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalaireUpgrade : MonoBehaviour
{
    [SerializeField]
    private int _addAugmentationSalaire = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            GameManager.Instance.PlayerData.IncrSalaire(this._addAugmentationSalaire);
            GameObject.Destroy(this.gameObject);
        }
    }
}
