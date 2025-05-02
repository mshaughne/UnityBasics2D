using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScrolling : MonoBehaviour
{
    private float startingPos; //starting position of backgrounds
    private float lengthOfSprites; //length of backgrounds
    public float AmountOfParallax; //amount of parallax scolling
    public Camera MainCamera; //camera reference
    // Start is called before the first frame update
    void Start()
    {
        //gets start position on x axis of backgrounds
        startingPos = transform.position.x;
        //getting length of sprites
        lengthOfSprites = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Position = MainCamera.transform.position;
        float Temp = Position.x * (1 - AmountOfParallax);
        float Distance = Position.x * AmountOfParallax;

        Vector3 NewPosition = new Vector3(startingPos + Distance, transform.position.y, transform.position.z);

        transform.position = NewPosition;

        if (Temp > startingPos + (lengthOfSprites /2))
        {
            startingPos += lengthOfSprites;
        }
        else if (Temp < startingPos - (lengthOfSprites /2))
        {
            startingPos -= lengthOfSprites;
        }
        
    }
}
