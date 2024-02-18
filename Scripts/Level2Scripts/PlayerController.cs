using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float sprintSpeedMultiplier = 5f; // Koşma hızı artışı
    public float rotationSpeed = 300f;

    private Animator animator;
    private Transform playerCamera;
    public Transform mermi, atisNoktasi;
    Transform klon;

    public AudioSource audioSource;


    
    private bool isSprinting = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        playerCamera = transform.GetChild(0); // Oyuncunun içindeki kamerayı al
        audioSource = GetComponent<AudioSource>();
    }



    void Update()
    {

        Hareket();

    }




    public void Hareket()
    {

        // Mouse'un yatay pozisyonunu alarak kameranın yönünde dönüş yap
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up, mouseX * rotationSpeed * 50 * Time.deltaTime);

        // İleri hareket etme vektörünü oluştur
        Vector3 moveDirection = transform.forward.normalized;

        // Eğer "W" veya "Up Arrow" tuşuna basıldıysa
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            // Koşma animasyonunu oynat
            animator.SetBool("isRunning", true);

            // Hızı belirle (koşma durumuna göre)
            float speed = moveSpeed;
            if (isSprinting)
            {
                speed *= sprintSpeedMultiplier;
            }

            // Hareket et
            transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);
        }
        else
        {
            // Durma animasyonunu oynat
            animator.SetBool("isRunning", false);
        }

        // "Q" tuşuna basıldığında
        if (Input.GetKeyDown(KeyCode.Q))
        {
            isSprinting = true;
        }
        // "Q" tuşu bırakıldığında
        else if (Input.GetKeyUp(KeyCode.Q))
        {
            isSprinting = false;
        }

        // Kullanıcı fare sol tıklamasını yaptığında
        if (Input.GetMouseButtonDown(0))
        {
            audioSource.Play();
            klon = Instantiate(mermi, atisNoktasi.position, playerCamera.rotation);

            klon.GetComponent<Rigidbody>().velocity = -klon.right * 50f;
        }
    }

}