using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;


/*
 * VARIABLES *
 *      DNALength -> This denotes how many genes we need.
 *      timeAlive -> This is the amount of time an organism has been alive for. We can use it for determining the fittest organism.
 *      distanceTravelled -> This is the amount of distance an organism has travelled before dying for defore a new generation occurs. We can use it for determining the fittest organism.
 *      startPosition -> This stores the starting position of an organism. It will help in calculating distanceTravelled.
 *      dna -> This is the instance of the dna class.
 *      m_Character -> This is the instance of the ThirdPersonCharacter class from UnityStandardAssets that helps us control Ethans.  
 *      alive -> true if character is on the strip and false if character hits the dead ground.
 *      move -> a vector3 to be used in Move( ) method.
 *      crouch, jump -> booleans for Move( ) method.
 */

/*
 * METHODS *
 *       OnCollisionEnter2D(Collision collision) -> Sets alive to false if the player hits dead ground.
 *       Init() -> Used to initialize. Initiates DNA, ThirdPersonCharacter, timeAlive, startPosition and alive. Whenever a brain is called Init must be called no matter what else it will give a NullPointerException.
 */
[RequireComponent(typeof (ThirdPersonCharacter))]
public class Brain : MonoBehaviour
{
	public int DNALength = 1;
	public float timeAlive;
	public float distanceTravelled;
	Vector3 startPosition;
	public DNA dna;

    private ThirdPersonCharacter m_Character;  
    bool alive = true;                     

    void OnCollisionEnter(Collision obj)
    {
    	if(obj.gameObject.tag == "dead")
    	{
    		alive = false;
    	}
    }
    
	public void Init()
	{
		//initialise DNA
        
        dna = new DNA(DNALength,6);
		m_Character = GetComponent<ThirdPersonCharacter>();
        timeAlive = 0;
        alive = true;
        startPosition = this.transform.position;
	}

    private void FixedUpdate()
    {
        Vector3 move;
        bool jump=false;
        bool crouch = false;
        float h = 0;
        float v = 0;

        // read DNA
        //0 forward
        //1 back
        //2 left
        //3 right
        //4 jump
        //5 crouch
        if (dna.GetGene(0) == 0) v = 1;
        else if(dna.GetGene(0) == 1) v = -1;
        else if(dna.GetGene(0) == 2) h = -1;
        else if(dna.GetGene(0) == 3) h = 1;
        else if(dna.GetGene(0) == 4) jump = true;
        else if(dna.GetGene(0) == 5) crouch = true;

        move = v*Vector3.forward + h*Vector3.right;
        m_Character.Move(move, crouch, jump);
        jump = false;
        if(alive)
        {
        	timeAlive += Time.deltaTime;
        	distanceTravelled = Vector3.Distance(this.transform.position,startPosition);
        }
    }
}
