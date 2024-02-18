using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform hedef; // Oyuncunun transformu (Player objesinin transformu)

    public float hareketHizi = 0.02f;
    public float atisAraligi = 10f; // Saniye cinsinden ateş etme aralığı
    public float atisGucu = 20f; // Mermi atış gücü
    public float yaklasmaMesafesi = 5f; // Oyuncuya yaklaşma mesafesi

    public GameObject mermiPrefab;
    public Transform atisNoktasi;


    private float zamanlayici = 0f;

    private Animator animator;
    public AudioSource audioEnemyBullet;

    

    void Start()
    {
        animator = GetComponent<Animator>();
        audioEnemyBullet = GetComponent<AudioSource>();
    }
    void Update()
    {
        // hedef değişkeninin null olup olmadığını kontrol edin
        if (hedef != null)
        {
            float mesafe = Vector3.Distance(transform.position, hedef.position);

            // Düşman, oyuncuya belirli bir mesafeden (yaklasmaMesafesi) daha yakınsa hareket et
            if (mesafe <= yaklasmaMesafesi)
            {
                // Koşma animasyonunu oynat
                animator.SetBool("isRunning", true);

                // Oyuncunun konumuna doğru hareket et
                transform.LookAt(hedef);
                transform.Translate(Vector3.forward * hareketHizi * Time.deltaTime);

                // Belirli aralıklarla ateş etme kontrolü
                zamanlayici -= Time.deltaTime;
                if (zamanlayici <= 0f)
                {
                    AtesEt();
                    zamanlayici = atisAraligi * 5;
                }
            }
            else
            {
                // Yürüme animasyonunu oynat
                animator.SetBool("isRunning", false);
            }
        }
    }

    void AtesEt()
    {
        audioEnemyBullet.Play();
        // Mermi oluştur ve atış noktasından ileriye doğru fırlat
        GameObject klon = Instantiate(mermiPrefab, atisNoktasi.position, transform.rotation);
        Rigidbody rb = klon.GetComponent<Rigidbody>();
        rb.velocity = klon.transform.forward * 50f;
    }
}