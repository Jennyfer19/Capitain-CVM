using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatBehaviour : MonoBehaviour
{
  
    [SerializeField]
    public const float _delaisDestruction = 1f;
    public float _debutTempsDestruction;
    private bool _batMort = false;

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
            }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
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
            Debug.Log("hit");
            _batMort = true;
        }
    }
}
