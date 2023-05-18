using UnityEngine;

public class Pistol : MonoBehaviour
{

    // variabili per caratteristiche della pistola
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;

    private float nextShoot = 0f;

    // punto dal quale escono i proiettili
    public Transform muzzle;
    public Camera fpsCamera;

    public ParticleSystem muzzleFlash;
    public GameObject impactEffectNoZombies, impactEffectZombies;
    public GameObject Zombies;

    // Update is called once per frame
    void Update(){

        // azione di sparo
        if(Input.GetButtonDown("Fire1") && Time.time >= nextShoot){

            nextShoot = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    void Shoot(){

        muzzleFlash.Play();

        // memorizza l'informazione su cosa ho colpito
        RaycastHit hitInfo;

        // si spara dalla posizione della camera, nella direzione della camera, vengono prese le informazioni necessarie, definito il range
        // il metodo ritorna un booleano, se si è colpito qualcosa o meno
        if(Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hitInfo, range)){
            
            Debug.Log(hitInfo.transform.name);

            Enemy enemyHitted = hitInfo.transform.GetComponent<Enemy>();

            if(enemyHitted != null){

                enemyHitted.TakeDamage(damage);
            }

            // effetto di impatto del proiettile
            if(enemyHitted != Zombies){
                
                GameObject impactedBullet = Instantiate(impactEffectNoZombies, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
                // distruggo i proiettili impattati
                Destroy(impactedBullet, 0.1f);
            }else{
                
                
                GameObject impactedBullet = Instantiate(impactEffectZombies, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
                // distruggo i proiettili impattati
                Destroy(impactedBullet, 0.1f);
            }
        }
    }
}
