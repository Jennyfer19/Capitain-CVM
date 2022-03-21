using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PanelCollectable : MonoBehaviour
{
    // Voici le lien youtube pour apprendre a ouvrir un panel
    // https://www.youtube.com/watch?v=LziIlLB2Kt4

    public GameObject Panel;
    private bool _ouvert = false;


    public void OpenPanel()
    {
        if (Panel != null)
        {
            if (_ouvert)
            {
                _ouvert = false;
            }
            else {
                _ouvert = true;
            }

            Panel.SetActive(_ouvert);
        }
    }
}
