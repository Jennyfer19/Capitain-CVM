using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class BatPatrol : MonoBehaviour
{

    [SerializeField]
    private float _vitesse = 3f;
    [SerializeField]
    private Transform[] _points;

    private Transform _cible = null;
    private SpriteRenderer _sr;
    private float _distanceSeuil = 0.3f;
    private int _indexPoint;

    // Start is called before the first frame update
    void Start()
    {
        _sr = this.GetComponent<SpriteRenderer>();
        _indexPoint = 0;
        _cible = _points[_indexPoint];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = _cible.position - this.transform.position;
        this.transform.Translate(direction.normalized * _vitesse * Time.deltaTime, Space.World);

        if (Vector3.Distance(this.transform.position, _cible.position) < _distanceSeuil)
        {
            _indexPoint = (++_indexPoint) % _points.Length;
            _cible = _points[_indexPoint];
        }
    }


#if UNITY_EDITOR

    private void OnDrawGizmos()
    {
        // Ligne entre les cibles
        for (int i = 0; i < _points.Length - 1; i++)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(_points[i].position,
                _points[i + 1].position);
        }

        // Ligne entre l'ennemi et la cible
        if (_cible != null)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(this.transform.position, _cible.position);
        }
    }

#endif
}
