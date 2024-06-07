using UnityEngine;

public class CentipedeSegment : MonoBehaviour
{
    //you have access to the variable, but cannot assign this variable from another script
    public SpriteRenderer spriteRenderer{ get; private set;}

    private void Awake(){
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
