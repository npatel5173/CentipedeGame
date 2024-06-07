using System.Collections.Generic;
using UnityEngine;

public class Centipede : MonoBehaviour
{
    // import System.Collections.Generic for Lists
    private List<CentipedeSegment> segments = new List<CentipedeSegment>();
    public CentipedeSegment segmentPrefab;
    public Sprite headSprite;
    public Sprite bodySprite;
    public int size = 12;
    
    private void Start(){
        Respawn();   
    }

    private void Respawn(){
        //clear out list and destroy all existing segments
        foreach(CentipedeSegment segment in segments){
            Destroy(segment.gameObject);
        }
        //clear out segment
        segments.Clear();
        //create new segment
        for(int i = 0; i < size; i++){
            Vector2 position = GridPosition(transform.position) + (Vector2.left * i);
            //Instantiate(Object original, Vector3 position, Quaternion rotation)
            //Instantiate clones the object original and returns the clone
            CentipedeSegment segment = Instantiate(segmentPrefab, position, Quaternion.identity);
            //ternary statement: if i == 0, then headSprite, else bodySprite
            //used to ensure the correct image for headSprite appears
            segment.spriteRenderer.sprite = i == 0 ? headSprite : bodySprite;
            segments.Add(segment);
        }
    }

    private Vector2 GridPosition(Vector2 position){
        //align the transform.position to the grid by rounding the position
        position.x = Mathf.Round(position.x);
        position.y = Mathf.Round(position.y);
        return position;
    }
}
