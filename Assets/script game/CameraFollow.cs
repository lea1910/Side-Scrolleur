using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public static CameraFollow Instance { get; private set; } // Propriété Singleton

    [Header("Cible")]
    [SerializeField] private Transform target; // L'objet que la caméra suit

    [Header("Paramètres de position")]
    [SerializeField] private Vector3 offset = new Vector3(0, 2, -10); // Décalage ajustable
    [SerializeField] private bool useFixedY = true; // Hauteur fixe optionnelle
    [SerializeField] private float fixedY = 2f; // Valeur de hauteur fixe

    [Header("Mouvement")]
    [SerializeField] private float smoothTime = 0.125f; // Temps de lissage du mouvement
    [SerializeField] private float maxSpeed = 10f; // Vitesse maximale de la caméra

    [Header("Paramètres d'affichage")]
    [SerializeField] private bool is2D = true; // Mode 2D ou 3D
    [SerializeField] private float zoom2D = 5f; // Zoom en mode orthographique

    [Header("Tremblement de caméra")]
    [SerializeField] private float shakeDuration = 0.5f; // Durée du tremblement
    [SerializeField] private float shakeMagnitude = 0.1f; // Intensité du tremblement

    private Camera cam; // Référence à la caméra
    private Vector3 velocity = Vector3.zero; // Vitesse actuelle pour SmoothDamp
    private Vector3 originalPosition; // Position originale de la caméra
    private float shakeTimeRemaining = 0f; // Temps restant pour le tremblement
    private Vector3 shakeOffset = Vector3.zero; // Décalage dû au tremblement

    private void Awake()
    {
        // Implémentation du Singleton
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // Détruire les doublons
        }
    }

    private void Start()
    {
        cam = Camera.main; // Récupère la caméra principale
        originalPosition = transform.localPosition; // Sauvegarde la position originale

        if (is2D && cam.orthographic)
        {
            cam.orthographicSize = zoom2D; // Applique le zoom en 2D
        }
    }

    private void LateUpdate()
    {
        if (target == null)
        {
            Debug.LogWarning("🚨 La cible de la caméra n'est pas définie !");
            return;
        }

        // Calculer la position désirée
        Vector3 desiredPosition = target.position + offset;

        // Appliquer la hauteur fixe si activée
        if (useFixedY)
        {
            desiredPosition.y = fixedY;
        }

        // Utiliser SmoothDamp pour un mouvement fluide
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothTime, maxSpeed);

        // Appliquer le tremblement de caméra
        if (shakeTimeRemaining > 0)
        {
            shakeOffset = Random.insideUnitSphere * shakeMagnitude;
            shakeTimeRemaining -= Time.deltaTime;
        }
        else
        {
            shakeTimeRemaining = 0f;
            shakeOffset = Vector3.zero;
        }

        // Combiner la position lissée et le tremblement
        transform.position = smoothedPosition + shakeOffset;

        // Ajuster le zoom en 2D
        if (is2D && cam.orthographic)
        {
            cam.orthographicSize = zoom2D;
        }
    }

    /// <summary>
    /// Déclenche un effet de tremblement de caméra.
    /// </summary>
    public void Shake()
    {
        shakeTimeRemaining = shakeDuration;
    }

    private void OnDrawGizmos()
    {
        if (cam == null)
            cam = Camera.main;

        if (cam == null)
            return;

        Gizmos.color = Color.green; // Couleur du cadre

        float height = 2f * cam.orthographicSize; // Hauteur visible
        float width = height * cam.aspect; // Largeur visible

        Vector3 topLeft = transform.position + new Vector3(-width / 2, height / 2, 0);
        Vector3 topRight = transform.position + new Vector3(width / 2, height / 2, 0);
        Vector3 bottomLeft = transform.position + new Vector3(-width / 2, -height / 2, 0);
        Vector3 bottomRight = transform.position + new Vector3(width / 2, -height / 2, 0);

        // Dessiner le cadre
        Gizmos.DrawLine(topLeft, topRight);
        Gizmos.DrawLine(topRight, bottomRight);
        Gizmos.DrawLine(bottomRight, bottomLeft);
        Gizmos.DrawLine(bottomLeft, topLeft);
    }
}