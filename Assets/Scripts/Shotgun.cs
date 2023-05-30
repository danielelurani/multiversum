using UnityEngine;

public class Shotgun : MonoBehaviour
{

    // variabili per caratteristiche della pistola
    public float damage = 5f;
    public float range = 100f;
    public float fireRate = 6f;
    public int magazine = 8;
    public int currentBullets = 8;
    public int maxAmmo = 160;
    public int currentAmmo = 80;
    public float spread = 0.025f;

    // punto dal quale escono i proiettili
    public Transform muzzle;
    public Camera fpsCamera;

    private AudioSource[] shotgunSounds;
    private AudioSource reloadSound;
    private AudioSource shootingSound;
    private Animator animator;
    private float time;
    private int bulletPieces = 8;
    
    public ParticleSystem muzzleFlash;
    public GameObject impactEffectNoZombies, impactEffectZombies;

    void Start(){

        shotgunSounds = GetComponents<AudioSource>();
        shootingSound = shotgunSounds[0];
        reloadSound = shotgunSounds[1];

        // quando starta il gioco disattivo i suoni delle armi, altrimenti si attiverebbero
        shootingSound.enabled = false;
        reloadSound.enabled = false;
        
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update(){

        time += Time.deltaTime;

        float nextTimeToShoot = 1 / fireRate;

        // azione di sparo
        if(time >= nextTimeToShoot && Input.GetButton("Fire1") && currentBullets > 0){
            Shoot();
            time = 0.0f;
        }

        //azione di ricarica
        if(Input.GetKeyDown(KeyCode.R) && currentBullets < magazine && currentAmmo > 0){
            
            Reload();

            // dopo che si preme il tasto "ricarica", bisogna aspettare che sia finita la ricarica prima di sparare ancora
            time = -2.0f;
        }
    }

    void Shoot(){

        // contatore proiettili sparati
        if(currentBullets != 0){
            currentBullets --;
        }
        animator.SetTrigger("isShooting");

        muzzleFlash.Play();

        shootingSound.enabled = true;
        shootingSound.Play();

        // il fucile a pompa spara più colpi contemporaneamente
        for(int i = 0; i < bulletPieces; i++){

            // memorizza l'informazione su cosa ho colpito
            RaycastHit hitInfo;

            Vector3 shootDirection = fpsCamera.transform.forward;
            shootDirection.x += Random.Range(-spread, spread);
            shootDirection.y += Random.Range(-spread, spread);

            // si spara dalla posizione della camera, nella direzione della camera, vengono prese le informazioni necessarie, definito il range
            // il metodo ritorna un booleano, se si è colpito qualcosa o meno
            if(Physics.Raycast(fpsCamera.transform.position, shootDirection, out hitInfo, range)){
                
                Debug.Log(hitInfo.transform.name);

                var hitBox = hitInfo.transform.GetComponent<ZWHitBox>();
                if(hitBox){
                    hitBox.OnRaycastHitS(this);
                }

                // effetto di impatto del proiettile
                if(hitInfo.transform.tag == "ZombieHitbox"){
                    
                    GameObject impactedBullet = Instantiate(impactEffectZombies, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
                    // distruggo i proiettili impattati
                    Destroy(impactedBullet, 0.1f);

                }else{
                    
                    GameObject impactedBullet = Instantiate(impactEffectNoZombies, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
                    // distruggo i proiettili impattati
                    Destroy(impactedBullet, 0.1f);
                    
                }
            }
        }
    }

    void Reload(){

        // suono della ricarica
        reloadSound.enabled = true;
        reloadSound.Play();

        // triggera animazione
        animator.SetTrigger("RPressed");

        if(currentAmmo < magazine){

            currentAmmo = currentAmmo - (magazine - currentBullets);
            currentBullets = currentBullets + (magazine - currentBullets);
        }
        else{

            currentAmmo = currentAmmo - ( magazine - currentBullets);
            currentBullets = currentBullets + (magazine - currentBullets);
        }
    }
}
