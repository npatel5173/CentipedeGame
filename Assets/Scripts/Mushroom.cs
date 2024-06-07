using UnityEngine;

public class Mushroom : MonoBehaviour
{
    public Sprite[] states;
    private SpriteRenderer spriteRenderer;
    private int health;

    private void Awake(){
        spriteRenderer = GetComponent<SpriteRenderer>();
        //health equals number of sprites
        health = states.Length;
    }

    private void Damage(int amount){
        //reduce health
        health-=amount;

        //check if there is still health remaining in the mushroom
        if(health > 0){
            //change the sprite on spriteRenderer with the index of the inverse of health
            spriteRenderer.sprite = states[states.Length - health];
        } else{
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        //check that dart collides with the mushroom
        if(collision.gameObject.layer == LayerMask.NameToLayer("Dart")){
            //
            Damage(1);
        }
    }
}
