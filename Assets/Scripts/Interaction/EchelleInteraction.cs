using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EchelleInteraction : BaseInteraction
{
    [SerializeField]
    private BoxCollider2D _colliderPlateform;

    public override void ExitAction() { QuitterEchelle(); }

    public override void DoAction() // appeler seulement si on est en collison avec joueur
    {

        // Placer le code pour l'action ici
        Debug.Log("Monter à l'échelle");

        PlayerMouvement pm = GameObject.FindGameObjectWithTag("Player")
            .GetComponent<PlayerMouvement>(); // chercher player
        pm.SetEnMonte(true);
        Rigidbody2D rb = pm.gameObject.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0; // dire gravite a zero pour que player puisse monter
        rb.velocity = new Vector2(rb.velocity.x, 0); // eviter ca arrete un coup et va continuer de marhcer

        _colliderPlateform.enabled = false; 

        pm.gameObject.GetComponent<Animator>().SetBool("EnMonte", true);
        
        InteractionUI.Instance.ActiveMessage("Quitter l'échelle");  // mtn affiche quitter echelle
        pm.InteractionAction -= DoAction;
        pm.InteractionAction += QuitterEchelle;
    }   

    public void QuitterEchelle()
    {
        Debug.Log("Quitte l'échelle");

        PlayerMouvement pm = GameObject.FindGameObjectWithTag("Player")
            .GetComponent<PlayerMouvement>();
        pm.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
        pm.SetDirectionToZero();
        pm.SetEnMonte(false);

        _colliderPlateform.enabled = true;

        pm.gameObject.GetComponent<Animator>().SetBool("EnMonte", false);

        InteractionUI.Instance.ActiveMessage(this._messageInteraction);
        pm.InteractionAction -= QuitterEchelle;
        pm.InteractionAction += DoAction;
    }
}
