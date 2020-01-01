using System.Collections;
using UnityEngine;

[RequireComponent(typeof(HealthSystem))]
public class Player : BaseShip
{

    [SerializeField] float moveSpeed = 10.0f;
    [SerializeField] float fireSpeed = 0.1f;
    [SerializeField] GameManager gameManager = null;

    private float minX;
    private float maxX;
    private float minY;
    private float maxY;

    private bool isShooting = false;
    private Coroutine fireCoroutineHandle = null;

    public override void Start()
    {
        base.Start();
        SetupMoveCamera();
    }

    private void SetupMoveCamera()
    {
        var gameCamera = Camera.main;

        minX = gameCamera.ViewportToWorldPoint(Vector3.zero).x;
        maxX = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
        minY = gameCamera.ViewportToWorldPoint(Vector3.zero).y;
        maxY = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;

        var scale = gameObject.transform.localScale;

        var horizontalPadding = scale.x / 2;
        minX += horizontalPadding;
        maxX -= horizontalPadding;

        var verticalPadding = scale.y / 2;
        minY += verticalPadding;
        maxY -= verticalPadding;
    }

    void Update()
    {
        Move();
        CheckForUserInput();
    }

    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        var newXPos = (transform.position.x + deltaX);
        var newYPos = (transform.position.y + deltaY);

        newXPos = Mathf.Clamp(newXPos, minX, maxX);
        newYPos = Mathf.Clamp(newYPos, minY, maxY);

        transform.position = new Vector3(newXPos, newYPos);
    }

    private void CheckForUserInput()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            isShooting = true;
            fireCoroutineHandle = StartCoroutine(FireLaser());
        }
        else if(Input.GetButtonUp("Fire1"))
        {
            isShooting = false;
            if (fireCoroutineHandle != null)
            {
                StopCoroutine(fireCoroutineHandle);
                fireCoroutineHandle = null;
            }
        }
    }

    private IEnumerator FireLaser()
    {
        while (isShooting)
        {
            SpawnLaser();
            yield return new WaitForSeconds(fireSpeed);
        }
    }

    protected override void OnDeath()
    {
        gameManager.PlayerHasDied();
        base.OnDeath();
    }
}
