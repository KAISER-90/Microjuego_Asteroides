using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject asteroidePrefab;

    [Header("Generación de asteroides")]
    public float spawnRatePerMinute = 30f;
    public float spawnIncrement = 1f;
    public float xLimit = 8f;
    public float alturaSpawn = 8f;
    public float maxTimeLife = 10f;
    private float spawnNext = 0f;

    private void Update()
    {
        if (Time.time>=spawnNext)
        {
            CrearAsteroide();
            spawnRatePerMinute += spawnIncrement;
            spawnNext = Time.time + 60f/spawnRatePerMinute;
        }
    }

    private void CrearAsteroide()
    {
        float posicionAleatoriaX = Random.Range(-xLimit, xLimit);

        Vector3 posicionSpawn = new Vector3(posicionAleatoriaX, alturaSpawn,-5f);
        GameObject asteroide = Instantiate( asteroidePrefab, posicionSpawn,Quaternion.identity);

        Destroy(asteroide, maxTimeLife);
    }
}
