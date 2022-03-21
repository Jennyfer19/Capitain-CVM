using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AfficherNiveauDisponible : MonoBehaviour
{
    [SerializeField]
    private Button _lvl1;
    [SerializeField]
    private Button _lvl2;
    [SerializeField]
    private Button _lvl3;

    List<Button> _buttonList;

    // Start is called before the first frame update
    void Start()
    {
        _buttonList = new List<Button>();
        InsererButtonDansList();
        ActiverButtonJouable();
    }

    private void InsererButtonDansList()
    {
        _buttonList.Add(_lvl1);
        _buttonList.Add(_lvl2);
        _buttonList.Add(_lvl3);
    }

    private void ActiverButtonJouable()
    {
        int _nbNiveauComplete = GameManager.Instance.PlayerData.ListeNiveau.Count;

        /// <summary>
        ///  permettre de ne pas depasser la liste de button. Exemple: User fini 3 niveaux, il y aura 
        ///  donc 4 button de niveau qui vont deveni interactable
        /// </summary>
        /// 
        if (_nbNiveauComplete >= _buttonList.Count)
            _nbNiveauComplete--; 

        for (int i = 0; i <= _nbNiveauComplete; i++)
        {
            _buttonList[i].interactable = true;
        }

    }
}
