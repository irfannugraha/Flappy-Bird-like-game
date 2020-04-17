using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb2d;

    void Update() {
        // Nilai x dikali 100 per detik, sehingga objek akan selalu bergerak di sumbu x
        rb2d.velocity = new Vector2((100 * Time.deltaTime) * 1, 0);
        DestroySelf();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        // Jika bersentuhan dengan Pipe-down atau pipe-up maka akan delete objek diri sendiri
        if (other.collider.name == "pipe-down(Clone)" || other.collider.name == "pipe-up(Clone)")
        {
            Destroy(gameObject);
        }
    }

    void DestroySelf(){
        // Cooldown akan berkurang 1 per detik, jika cooldown habis, maka hapus objek diri sendiri
        float cooldown = 5f;
        if (cooldown > 0)
        {
            cooldown-=Time.deltaTime;
        }else{
            Destroy(gameObject);
            cooldown = 5f;
        }
    }
}
