using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

[RequireComponent(typeof(TextMeshProUGUI))]
public class PanelCoffreUpgrade : MonoBehaviour
{
    private TextMeshProUGUI _text;

    // Start is called before the first frame update
    void Start()
    {
        _text = this.gameObject.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        _text.text = GameManager.Instance.PlayerData.ListeCoffreOuvert.Count().ToString();
    }
}
