using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipEngine : MonoBehaviour,
    IMovementController, IGunController
{
    public Projectile projectilePrefab;
    public Spaceship spaceship;
    private bool paused; 

    public void OnEnable()
    {
        spaceship.SetMovementController(this);
        spaceship.SetGunController(this);
        paused = false;
    }

    public void Update()
    {
        if (paused) {
            if (Input.GetButtonUp("Pause")) {
                Time.timeScale = 1;
                paused = false;
            }

            return;
        }
        //spaceship.Reload();
        //Time.timeScale = 0;
        //paused = true;
        //spaceship.Reload();
        //Time.timeScale = 1;
        //paused = true;
        //spaceship.Reload();
        //Application.Quit();
        if (Input.GetButton("Horizontal")) {
            spaceship.MoveHorizontally(Input.GetAxis("Horizontal"));
        }

        if (Input.GetButton("Vertical")) {
            spaceship.MoveVertically(Input.GetAxis("Vertical"));
        }

        if (Input.GetButtonDown("Fire1")) {
            spaceship.ApplyFire();
        }

	if (Input.GetButtonDown("Fire2")) {
            spaceship.Reload();
        }

	if (Input.GetButtonDown("Fire3")) {
            spaceship.SwitchBurstFireOn();
        }

	if (Input.GetButtonUp("Fire3")) {
            spaceship.SwitchBurstFireOff();
        }

    if (Input.GetButtonUp("Pause")) {
        Time.timeScale = 0;
            paused = true;
        }
    }

    public void MoveHorizontally(float x)
    {
        var horizontal = Time.deltaTime * x;
        transform.Translate(new Vector3(horizontal, 0));
    }

    public void MoveVertically(float y)
    {
        var vertical = Time.deltaTime * y;
        transform.Translate(new Vector3(0, vertical));
    }

    public void Fire()
    {
        Instantiate(projectilePrefab,
            transform.position, Quaternion.identity);
    }
}