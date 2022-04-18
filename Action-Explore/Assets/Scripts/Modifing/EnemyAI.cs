using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ForcePage
{
    enum AIState { Idle, Attacking, Patrol };
    enum AIMoveDirection { Up, Down, Right, Left, Stop}
    public class EnemyAI : Movement
    {
        // dont need Ref to movement like NPCBehaviour because im already inheariting from movement
        AIState aiState;
        GameObject _player;
        float playerDistX, playerDistY;
        [SerializeField] float attackRange = 5.0f;

        // checking 
        

        AIMoveDirection aiMoveDir;
        float decisionTimer = 0f;
        float decisionDelay = 0.5f;
        float decisionDelayMax = 0.6f;
        float decisionDelayMin = 0.1f;

        //Ref to enemy weapon 
        EnemyWeapon _enemyWeapon;
        float shootTimer = 0f;
        float shootDelay = 0.2f;
        float shootDelayMax = 0.6f;
        float shootDelayMin = 0.1f;

        //waypoints
        GameObject[] _waypoints;
        bool waypointReached = false;
        int targetWaypoint;
        float waypointReachedRange = 0.2f;
        float waypointDistX;
        float waypointDistY;

        protected override void Start()
        {
            base.Start();
            _enemyWeapon = GetComponent<EnemyWeapon>();
            _player = GameObject.FindGameObjectWithTag("Player");
            _waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
        }

        protected override void Update()
        {
            base.Update();
            print(aiState);
            if(_player != null)
            {
                CheckPlayerRangeAndSetAIState();
                if(aiState == AIState.Idle)
                {
                    StopMoving();
                }
                else if (aiState == AIState.Attacking)
                {
                    MoveTowardsPlayer();
                    ShootAtPlayer();
                }
                else if (aiState == AIState.Patrol)
                {
                    Patrol();
                }
            }
        }

            void Patrol()
            {
                CheckEnemyReachWaypoint();
            // block of codes

            if (!waypointReached)
            {
                //move to the waypoint
                //CheckNPCReachWaypoint();
                MoveToWaypoint();
            }
            else if (waypointReached)
            {
                //move to the next waypoint
                FindNewWaypoint();

            }
        }

            void CheckEnemyReachWaypoint()
            {
            // logic how to check for way points
            waypointDistX = _waypoints[targetWaypoint].transform.position.x - transform.position.x; //current waypoint i.e targetWaypoint position minus the NPC position on the Xaxis 
            waypointDistY = _waypoints[targetWaypoint].transform.position.y - transform.position.y; //current waypoint i.e targetWaypoint position minus the NPC position on the Yaxis 

            if ((Mathf.Abs(waypointDistX) < waypointReachedRange) && Mathf.Abs(waypointDistY) < waypointReachedRange) // checking on both to see if the NPC is close enough to the waypoint, to make a move to next waypoint in the array 
            {
                //print("Waypoint has been reached"); // prints the message as the NPC gets in the range of visiblity of the waypoint 
                waypointReached = true;  // send a flag to tell the AI that the NPC just reached a way point: OR lets the patrol method knows that the NPC as reached the waypoint and ready to move to the next one 
            }
            else
            {
                waypointReached = false; // let the patrol mwethod that NPC is not yet in the range of the current waypoint, its probably still making its way to it. 
            }
        }

            void MoveToWaypoint()
            {
            // logic to move from one way point to another 
            // and the time to make deciaion tpo move
            if (DecisionTimer())
            {
                //making a list of possible moves from the enum created under the namespace JayWeek6Lab
                List<AIMoveDirection> possibleMove = new List<AIMoveDirection>();

                if (waypointDistX <= 0)
                {
                    //if the NPC distance to the waypoint on the Xaxis is less then 0, which means its a negative value add to the list of possible move left 
                    possibleMove.Add(AIMoveDirection.Left);
                }
                else if (waypointDistX > 0)
                {
                    // if the distance on the x is more than 0 which are positive value it add right to list of possible move for the NPC 
                    possibleMove.Add(AIMoveDirection.Right);
                }

                if (waypointDistY <= 0)
                {
                    // if the distance to the waypoint on the y is less which are negative value add  downward direction movement to the list possible movement 
                    possibleMove.Add(AIMoveDirection.Down);
                }
                else if (waypointDistY > 0)
                {
                    //when the distance to the waypoint is greater then 0, making positive value add Up direction to the list of possible movement 
                    possibleMove.Add(AIMoveDirection.Up);
                }

                // after all the logic the AI will have 2 possible movement depending of the relative position of the NPC to waypoint 
                //and one out of the two will be choosen at random 
                int randomMove = Random.Range(0, possibleMove.Count);
                aiMoveDir = possibleMove[randomMove];
            }

            switch (aiMoveDir)
            {
                case AIMoveDirection.Left:
                    MoveLeft();
                    break;
                case AIMoveDirection.Right:
                    MoveRight();
                    break;
                case AIMoveDirection.Up:
                    MoveUp();
                    break;
                case AIMoveDirection.Down:
                    MoveDown();
                    break;
            }
        }

            void FindNewWaypoint()
            {
            // logic to look for new way points
            targetWaypoint = Random.Range(0, _waypoints.Length); // choosing at random 
            waypointReached = false;
        }

            void ShootAtPlayer()
            {
                // logic to shoot at player 

                shootTimer += Time.deltaTime;

                if (shootTimer > shootDelay)
                {
                   switch(aiMoveDir)
                    {
                        case AIMoveDirection.Left:
                            _enemyWeapon.FireShot();
                            break;
                        case AIMoveDirection.Right:
                            _enemyWeapon.FireShot();
                        break;
                        case AIMoveDirection.Up:
                            FireUp();
                            break;
                        case AIMoveDirection.Down:
                            FireDown();
                            break;
                    }
                    shootTimer = 0f;
                    shootDelay = Random.Range(shootDelayMin, shootDelayMax);
                }
                

                // dont know in mind 
            }

            void MoveTowardsPlayer()
            {
                if(DecisionTimer())
                {
                    List<AIMoveDirection> possibleMove = new List<AIMoveDirection>();

                    if(playerDistX <= 0)
                    {
                        possibleMove.Add(AIMoveDirection.Left);
                    }
                    else if (playerDistX > 0)
                    {
                        possibleMove.Add(AIMoveDirection.Right);
                    }

                    if(playerDistY <= 0)
                    {
                        possibleMove.Add(AIMoveDirection.Down);
                    }
                    else if(playerDistY > 0 )
                    {
                        possibleMove.Add(AIMoveDirection.Up);
                    }

                    int randomMove = Random.Range(0, possibleMove.Count);
                    aiMoveDir = possibleMove[randomMove];
                }

                switch(aiMoveDir)
                {
                    case AIMoveDirection.Left:
                        MoveLeft();
                        break;
                    case AIMoveDirection.Right:
                        MoveRight();
                        break;
                    case AIMoveDirection.Up:
                        MoveUp();
                        break;
                    case AIMoveDirection.Down:
                        MoveDown();
                        break;
                }
            }

            bool DecisionTimer()
            {
                decisionTimer += Time.deltaTime;
                if(decisionTimer > decisionDelay)
                {
                    decisionTimer = 0;
                    decisionDelay = Random.Range(decisionDelayMin, decisionDelayMax);
                    return true;
                }
                else
                {
                    return false;
                }
            }


            void CheckPlayerRangeAndSetAIState()
            {
                playerDistX = _player.transform.position.x - transform.position.x;
                playerDistY = _player.transform.position.y - transform.position.y;

                if ((Mathf.Abs(playerDistX) < attackRange) && (Mathf.Abs(playerDistY) < attackRange))// Mathf.Abs gets the absolute value of a given number if value is negative it changes it to positive, if positive it remains positive 
                {
                    // player in range on the Xaxis and yaxis
                    aiState = AIState.Attacking;//set the Ai state to be attack
                                                //print("In range");
                                                //transform.position = Vector2.Lerp(transform.position, player.transform.position, Time.deltaTime);
                }
                else
                {
                    //aiState = AIState.Idle;// player is not in range set AI state to idle
                    aiState = AIState.Patrol;
                }
            }

        void MoveUp()
        {
            MovementInput(Vector2.up);
        }

        void MoveDown()
        {
            MovementInput(Vector2.down);
        }

        void MoveRight()
        {
            MovementInput(Vector2.right);
        }

        void MoveLeft()
        {
            MovementInput(Vector2.left);
        }

        void StopMoving()
        {
            MovementInput(Vector2.zero);
        }

        void FireUp()
        {
            _enemyWeapon.FireShot();
        }

        void FireDown()
        {
            _enemyWeapon.FireShot();
        }

        void FireRight()
        {
            _enemyWeapon.FireShot();
        }

        void FireLeft()
        {
            _enemyWeapon.FireShot();
        }
    }

}
