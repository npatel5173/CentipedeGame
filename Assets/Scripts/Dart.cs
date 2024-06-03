using UnityEngine;

public class Dart : MonoBehaviour
{
    private new Rigidbody2D rigidbody;
    private new Collider2D collider;
    private Transform parent;
    public float speed = 50f;

    private void Awake(){
        rigidbody = GetComponent<Rigidbody2D>();
        //turn off physics simulation on the rigidbody
        rigidbody.bodyType = RigidbodyType2D.Kinematic;

        collider = GetComponent<Collider2D>();
        collider.enabled = false;

        //detach the dart from the parent and retach it again
        parent = transform.parent;
    }

    private void Update(){
        //prevent new darts when dart is active
        if(rigidbody.isKinematic && Input.GetButton("Fire1")){
            //deparent the dart from the blaster
            transform.SetParent(null);
            //reenabled the rigidbody simulation
            rigidbody.bodyType = RigidbodyType2D.Dynamic;
            //reenabled collider
            collider.enabled = true;
        }
    }

    private void FixedUpdate(){
        if(!rigidbody.isKinematic){
            //get current position from rigidbody
            Vector2 position = rigidbody.position;
            //update position to always move up over time
            position += Vector2.up * speed * Time.fixedDeltaTime;
            rigidbody.MovePosition(position);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        //reset the parent to initial
        transform.SetParent(parent);
        //reset position to where the blaster is
        transform.localPosition = new Vector3(0f, 0.5f, 0f);
        //reset rigidbody
        rigidbody.bodyType = RigidbodyType2D.Kinematic;
        //reset collider
        collider.enabled = false;
    }
}
