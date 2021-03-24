using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f;
    public float deactivate_Timer = 5.0f;

    [HideInInspector]
    public bool is_EnemyBullet = false;

    private void Start() {
        if(is_EnemyBullet)
            speed *= -1f;

        Invoke("DeactivateGameObject", deactivate_Timer);

        
    }
    private void Update() {
        Move();
    }
    void Move(){
        Vector3 temp = transform.position;
        temp.x += speed * Time.deltaTime;
        transform.position = temp;

    }
    void DeactivateGameObject(){
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D target) {
        if(target.tag == "Bullet" || target.tag == "Enemy"){
            gameObject.SetActive(false);
        }
    }
}
