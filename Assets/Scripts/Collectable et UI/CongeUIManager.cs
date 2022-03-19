using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]

public class CongeUIManager : MonoBehaviour
{
    private TextMeshProUGUI _textConge;

    // Start is called before the first frame update
    void Start()
    {
        _textConge = this.gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        _textConge.text = GameManager.Instance.PlayerData.Conge.ToString();
    }
}
