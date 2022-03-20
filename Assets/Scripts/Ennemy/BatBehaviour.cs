using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatBehaviour : MonoBehaviour
{
  
    [SerializeField]
    public const float _delaisDestruction = 1f;
    private float _debutTempsDestruction;
    private bool _batMort = false;
    private bool _surLaTete = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_batMort)
            if (Time.fixedTime > _debutTempsDestruction + _delaisDestruction) // laisse un peu de temps pour pourvoir sauter de la chauve-souris a la plateform
            {
                this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                this.gameObject.GetComponent<BatPatrol>().enabled = false;
                GameObject.Destroy(this.gameObject);
            }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player") == !_surLaTete)  // verifier si ca vient de la tete parce que si oui, on ne fait pas de degat 
        {
            PlayerBehaviour pb = collision.gameObject.GetComponent<PlayerBehaviour>();
            if (pb != null)
                pb.CallEnnemyCollision();
        }
    }

    // seulement un trigger sur le haut de la chauve-souris
    // si player ecrase la tete de la chave-souris, alors ce dernier meurt
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {

            _debutTempsDestruction = Time.fixedTime;
            _surLaTete = true;
            _batMort = true;
        }
    }
}
