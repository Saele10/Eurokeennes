using System.Collections.Generic;
using UnityEngine;

public class PublicController : MonoBehaviour
{
    public enum TYPE
    {
        Valide,
        Fauteuil,
        Gilet,
        Casque
    }
    [field: SerializeField] public TYPE Type { get; private set; }
    [SerializeField] private List<GameObject> _perso = new List<GameObject>();

    private SpriteRenderer _sprite;
    public bool bought = false;


    [SerializeField] private Vector2 zoneMin; // Coin inférieur gauche de la zone
    [SerializeField] private Vector2 zoneMax; // Coin supérieur droit de la zone
    [SerializeField] private float moveSpeed = 2f; // Vitesse de déplacement
    private Vector2 targetPosition;

    private void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>();
        SetRandomTargetPosition();

    }
    private void Update()
    {
        if (Type == TYPE.Valide)
            _sprite.enabled = true;
    

        if (bought)
            _sprite.enabled = true;

    }
    private void FixedUpdate()
    {
        MoveTowardsTarget();
    }

    private void SetRandomTargetPosition()
    {
        targetPosition = new Vector2(
            Random.Range(zoneMin.x, zoneMax.x),
            Random.Range(zoneMin.y, zoneMax.y)
        );
    }

    private void MoveTowardsTarget()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
        {
            SetRandomTargetPosition();
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Vector3 bottomLeft = new Vector3(zoneMin.x, zoneMin.y, 0);
        Vector3 bottomRight = new Vector3(zoneMax.x, zoneMin.y, 0);
        Vector3 topLeft = new Vector3(zoneMin.x, zoneMax.y, 0);
        Vector3 topRight = new Vector3(zoneMax.x, zoneMax.y, 0);

        Gizmos.DrawLine(bottomLeft, bottomRight);
        Gizmos.DrawLine(bottomRight, topRight);
        Gizmos.DrawLine(topRight, topLeft);
        Gizmos.DrawLine(topLeft, bottomLeft);
    }


}