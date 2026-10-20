using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f;
    public float MaxLifeTime = 3f;
    public Vector3 targetVector;

    private void Start()
    {
        Destroy(gameObject, MaxLifeTime);
    }

    private void Update()
    {
        transform.Translate( speed *targetVector.normalized * Time.deltaTime,Space.World);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (Player.instancia != null)
            {
                Player.instancia.SumarPuntos();
            }
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}