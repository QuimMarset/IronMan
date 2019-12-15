using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigg : MonoBehaviour
{
    public Collider playerColl;
    public float distanceMoveHorizontal = 5f;
    public float distanceMoveVertical;
    public float rotationAngle = 45f;
    private float enemySpeed = 5f;
    private bool activateEnemy = false;
    private Vector3 enemyIniPos = Vector3.zero;
    private Quaternion enemyIniRot = Quaternion.identity;
    private Quaternion enemyFinRot = Quaternion.identity;
    private Vector3 enemyFinPos = Vector3.zero;


    // Start is called before the first frame update
    void Start()
    {
        enemyIniPos = this.transform.position;
        enemyIniRot = this.transform.rotation;
        enemyFinPos = enemyIniPos + new Vector3(0f, distanceMoveVertical, distanceMoveHorizontal);
        enemyFinRot = Quaternion.Euler(rotationAngle, 0f, 0f);

    }

    // Update is called once per frame
    void Update()
    {
        if (activateEnemy == true)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, enemyFinPos, Time.time * 0.01f);
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, enemyFinRot, Time.time * 0.01f);
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        activateEnemy = true;
    }
}