using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float MoveSpeed;     // 미사일이 날아가는 속도


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime);
    }
}
