using UnityEngine;

public class MushroomField : MonoBehaviour
{
    private BoxCollider2D area;
    public Mushroom prefab;
    public int amount = 50;

    private void Awake(){
        area = GetComponent<BoxCollider2D>();
    }

    private void Start(){
        Generate();
    }

    private void Generate(){
        //gets the bounds of the collider
        Bounds bounds = area.bounds;
        //loop for how many mushrooms we want to spawn
        for (int i = 0; i < amount; i++){
            Vector2 position = Vector2.zero;
            //assign random x and y to the nearest whole number
            position.x = Mathf.Round(Random.Range(bounds.min.x, bounds.max.x));
            position.y = Mathf.Round(Random.Range(bounds.min.y, bounds.max.y));

            //create a clone of mushroom
            Instantiate(prefab, position, Quaternion.identity, transform);
        }
    }
}
