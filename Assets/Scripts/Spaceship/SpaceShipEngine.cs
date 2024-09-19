using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpaceShipEngine : MonoBehaviour, IMovementController, IGunController
{
    public Projectile projectilePrefab;
    public Spaceship _spaceship;

    public void OnEnable()
    {
        _spaceship.SetMovementController(this);
        _spaceship.SetGunController(this);
    }

    public void Update()
    {
        if(Input.GetButtonDown("Horizontal"))
        {
            _spaceship.MoveHorizontally(Input.GetAxis("Horizontal"));
        }

        if (Input.GetButtonDown("Vertical"))
        {
            _spaceship.MoveVertically(Input.GetAxis("Vertical"));
        }

        if (Input.GetButtonDown("Fire1"))
        {
            _spaceship.ApplyFire();
        }

    }
    public void MoveHorizontally(float x) {
        var horizontal = Time.deltaTime * x;
        transform.Translate(new Vector3(0, horizontal));
    }
    public void MoveVertically(float y) {
        var vertical = Time.deltaTime * y;
        transform.Translate(new Vector3(0, vertical));
    }

    public void Fire() {
        Instantiate(projectilePrefab, transform.position, Quaternion.identity);
    }
}
