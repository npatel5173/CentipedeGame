using UnityEngine;

public class CentipedeSegment : MonoBehaviour
{
    //you have access to the variable, but cannot assign this variable from another script
    public SpriteRenderer spriteRenderer{ get; private set;}
    public Centipede centipede {get; set;}
    public CentipedeSegment ahead { get; set;}
    public CentipedeSegment behind {get; set;}
    //to keep track of the ahead segment
    public bool isHead => ahead == null;

    private void Awake(){
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
