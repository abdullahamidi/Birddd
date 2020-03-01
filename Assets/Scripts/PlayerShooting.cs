using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Projectile projectilePrefab;
    public LayerMask mask;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // 1
    void raycastOnMouseClick()
    {
        RaycastHit hit;
        Ray rayToFloor = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(rayToFloor, out hit, 100.0f, mask, QueryTriggerInteraction.Collide))
        {
            shoot(hit);
        }
    }

    // 2
    void Update()
    {
        bool mouseButtonDown = Input.GetMouseButtonDown(0);
        if (mouseButtonDown)
        {
            raycastOnMouseClick();
        }
    }



    void shoot(RaycastHit hit)
    {
        var projectile = Instantiate(projectilePrefab).GetComponent<Projectile>();
        var pointabovefloor = hit.point + new Vector3(0, this.transform.position.y, 0);
        var direction = pointabovefloor - transform.position;
        var shootRay = new Ray(this.transform.position, direction);
        //Player ve Projectile ın collisionları ignorelanıyor.
        Physics.IgnoreCollision(GetComponent<Collider>(), projectile.GetComponent<Collider>());

        projectile.fireProjectile(shootRay);
    }

}
