using UnityEngine;
using System.Collections;

public class Launcher3D : MonoBehaviour
{
    [SerializeField] private GameObject proyectilePrefab;
    [SerializeField] private float launchModifier;
    [SerializeField] private Transform launchPoint;
    [SerializeField] private AudioClip shootSound; 
    [SerializeField] private GameObject point;
    private GameObject[] pointsList;
    [SerializeField] private int pointsCount;
    [SerializeField] private float spaceBetween;
    private bool canShoot;
    private Vector3 direction;
    private AudioSource audioSource;

    private void Start()
    {
        pointsList = new GameObject[pointsCount];
        for (int i = 0; i < pointsCount; i = i + 1)
        {
            pointsList[i] = Instantiate(point, launchPoint.position, Quaternion.identity);
        }

        audioSource = GetComponent<AudioSource>();
        canShoot = true;
    }


    private void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = transform.position.z - Camera.main.transform.position.z;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector3 launchPosition = transform.position;

        direction = (mousePosition - launchPosition);

        transform.right = -direction;

        if (Input.GetMouseButtonDown(0) && Time.deltaTime != 0)
        {
            Shoot();
        }

        for (int i = 0; i < pointsCount; i = i + 1)
        {
            pointsList[i].transform.position = CurrentPosition(i * spaceBetween);
        }
    }

    private void Shoot()
    {
        if (canShoot)
        {
            GameObject proyectile = Instantiate(proyectilePrefab, launchPoint.position, Quaternion.identity);
            proyectile.GetComponent<Rigidbody>().AddForce(-direction.normalized * launchModifier, ForceMode.Impulse);
            audioSource.PlayOneShot(shootSound);
            StartCoroutine(TimeShoot());
        }
    }

    IEnumerator TimeShoot()
    {
        canShoot = false;
        yield return new WaitForSeconds (1.5f);
        canShoot = true;
    }

    private Vector3 CurrentPosition(float t)
    {
        return (Vector3)launchPoint.position + (-direction.normalized * launchModifier * t) + (0.5f * Physics.gravity * (t * t));
    }
}