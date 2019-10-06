using UnityEngine;

public class lever : MonoBehaviour
{
    public bool activated;
    public Vector3 pivot; //the pivot which the level will rotate with regards to 
    public Vector3 direction; //the direction in which the level will rotate. This will be a plane
    public float maxAngle; //the maximium angle the level should rotate to before going back 
    public float speed; //the speed at which the level will move

    protected float currentTime;
    protected float waitTime; //how long the animation of the lever is
    protected bool cycle; //boolean used to check if the level should return to its original position
    protected Vector3 startPos; //the initial position of the lever

    protected int currentIndex; //the puzzle block the lever will move when it is pulled

    public AudioSource audioSource;
    
    //initalize all variables 
    protected void Start()
    {
        waitTime = 1.0f / speed;
        currentTime = 0.0f;
        activated = false;
        cycle = true;
        startPos = transform.position;
        pivot = this.transform.position;
        transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 1.0f);

        currentIndex = 0;

        audioSource = GetComponent<AudioSource>();
    }

    //move the lever every update
    protected void Update()
    {
        move();
    }

    //method used to reset the state of the level to one in which it is ready to be pulled again
    public virtual void toggle()
    {
        activated = activated ? false : true;
        cycle = true;
        currentTime = 0.0f;
        transform.position = startPos;

    }

    //method used to animate the lever when it is being pulled
    protected void move()
    {
        if (activated)
        {
            currentTime += Time.deltaTime;
            //move the lever towards the player
            if (cycle)
            {
                var rotation = transform.rotation;
                transform.RotateAround(pivot, direction, maxAngle * speed * Time.deltaTime);  
                transform.rotation = rotation;
                transform.Rotate(direction * maxAngle * speed * Time.deltaTime);
                if (currentTime>=waitTime) { cycle = false; currentTime = 0.0f; }
            }
            //move the lever back to its original position
            else
            {
                var rotation = transform.rotation;
                transform.RotateAround(pivot, direction, -maxAngle * speed * Time.deltaTime);
                transform.rotation = rotation;
                transform.Rotate(direction * -maxAngle * speed * Time.deltaTime);
                if (currentTime>=waitTime) {  toggle(); }
            }
            
            if (audioSource != null && !audioSource.isPlaying)
            {
                audioSource.Play();
            }
            
        }
    }
}
