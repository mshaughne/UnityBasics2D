using System;
using UnityEngine;

namespace _Scripts
{
    public class ParallaxEffect : MonoBehaviour
    {
        private float startingPos; //This is the starting position of the sprites.
        private float lengthOfSprite; //This is the length of the sprites.
        public float AmountOfParallax; //This is amount of parallax scroll. 
        public Camera MainCamera; //Reference of the camera.



        private void Start()
        {
            //Getting the starting X position of sprite.
            startingPos = transform.position.x;
            //Getting the length of the sprites.
            lengthOfSprite = GetComponent<SpriteRenderer>().bounds.size.x;
        }



        private void Update()
        {
            Vector3 Position = MainCamera.transform.position;
            float Temp = Position.x * (1 - AmountOfParallax);
            float Distance = Position.x * AmountOfParallax;

            Vector3 NewPosition = new Vector3(startingPos + Distance, transform.position.y, transform.position.z);

            transform.position = NewPosition;

            if (Temp > startingPos + (lengthOfSprite / 2))
            {
                startingPos += lengthOfSprite;
            }
            else if (Temp < startingPos - (lengthOfSprite / 2))
            {
                startingPos -= lengthOfSprite;
            }
        }
    }
}