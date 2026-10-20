using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [Header("Acciones del jugador")]
    [SerializeField] private InputActionReference accionRotar;
    [SerializeField] private InputActionReference accionImpulsar;
    [SerializeField] private InputActionReference accionDisparar;

    [Header("Valores de juego")]
    public float fuerzaThrust = 50f;
    public float velocidadRotacion = 120f;
    public float velocidadMaxima = 8f;

    [Header("Disparo")]
    public GameObject gun;
    public GameObject prefabBullet;

    [Header("Puntuación")]
    public TMP_Text textoPuntos;
    public int puntos = 0;
    public int puntosPorAsteroide = 100;

    private Rigidbody _rigid;
    private float entradaRotacion;
    private Vector2 entradaImpulso;

    public static Player instancia;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody>();
        instancia = this;
    }

    private void Start()
    {
        textoPuntos.text = "Puntos: " + puntos;
    }

    private void OnEnable()
    {
        accionRotar.action.Enable();
        accionImpulsar.action.Enable();
        accionDisparar.action.Enable();
    }

    private void OnDisable()
    {
        accionRotar.action.Disable();
        accionImpulsar.action.Disable();
        accionDisparar.action.Disable();
    }

    private void Update()
    {
        LeerControles();

        if (accionDisparar.action.WasPressedThisFrame())
        {
            GameObject bullet = Instantiate(prefabBullet,gun.transform.position,gun.transform.rotation);
            Bullet balaScript = bullet.GetComponent<Bullet>();
            if (balaScript != null)
            {
                balaScript.targetVector = transform.right;
            }
        }
    }

    private void FixedUpdate()
    {
        GirarNave();
        ImpulsarNave();
        LimitarVelocidad();
    }

    private void LeerControles()
    {
        entradaRotacion =accionRotar.action.ReadValue<float>();
        entradaImpulso =accionImpulsar.action.ReadValue<Vector2>();
    }

    private void GirarNave()
    {
        float cantidadRotacion =-entradaRotacion * velocidadRotacion * Time.fixedDeltaTime;

        Quaternion cambioRotacion =Quaternion.Euler(0f,0f,cantidadRotacion);

        _rigid.MoveRotation(_rigid.rotation * cambioRotacion);
    }

    private void ImpulsarNave()
    {
        Vector3 direccionMovimiento = new Vector3(entradaImpulso.x, entradaImpulso.y, 0f);
        _rigid.AddForce(direccionMovimiento.normalized * fuerzaThrust, ForceMode.Force);
    }

    private void LimitarVelocidad()
    {
        Vector3 velocidadPlana = new Vector3(_rigid.linearVelocity.x, _rigid.linearVelocity.y,0f);

        if (velocidadPlana.sqrMagnitude <= velocidadMaxima * velocidadMaxima)
        {
            return;
        }

        Vector3 velocidadLimitada =velocidadPlana.normalized * velocidadMaxima;

        _rigid.linearVelocity = new Vector3(velocidadLimitada.x, velocidadLimitada.y, 0f);
    }

    public void SumarPuntos()
    {
        puntos += puntosPorAsteroide;
        textoPuntos.text = "Puntos: " + puntos;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}