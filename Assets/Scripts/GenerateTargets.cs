using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;


public class GenerateTargets : MonoBehaviour
{
    public GameObject targetSpawner;
    public GameObject target;
    public GameObject movingTarget;
    public GameObject decreasingTarget;
    public GameObject precisionTarget;

    public Text scoreText, shotsHitText, shotsMissedText, accuracyText;

    public GameSettings GameSettings;

    void Start()
    {
        GameSettings = GameObject.Find("GameSettings").GetComponent<GameSettings>();
        if (GameSettings.isMoving == false && GameSettings.isDecreasing == false && GameSettings.isPrecision == false)
        {
            GenerateStaticTargets(GameSettings.noOfTargets);
        }
        else if (GameSettings.isMoving)
        {
            GenerateMovingTarget(GameSettings.noOfTargets);
        }
        else if(GameSettings.isDecreasing)
        {
            GenerateDecreasingTargets(GameSettings.noOfTargets);
        }
        else if(GameSettings.isPrecision)
        {
            GeneratePrecisionTargets(GameSettings.noOfTargets);
        };
        scoreText.text = string.Format("Score: {0}", GameSettings.score);
        accuracyText.text = string.Format("Accuracy: {0:0.00}%", GameSettings.accuracy);

    }

    public void GenerateStaticTargets(int numberOfTargets)
    {
        while (numberOfTargets > 0)
        {
            float dimX = Random.Range(targetSpawner.transform.position.x - (targetSpawner.transform.localScale.x / 2), 
                                        targetSpawner.transform.position.x + (targetSpawner.transform.localScale.x / 2));
            float dimY = Random.Range(targetSpawner.transform.position.y - (targetSpawner.transform.localScale.y / 2), 
                                        targetSpawner.transform.position.y + (targetSpawner.transform.localScale.y / 2));
            Vector3 targetPosition = new Vector3(dimX, dimY, targetSpawner.transform.position.z);
            Collider[] coliders = Physics.OverlapSphere(targetPosition, 0.5f);

            if (coliders.Length == 0)
            {
                Instantiate(target, targetPosition, Quaternion.identity);
                target.tag = "Target";
                numberOfTargets--;
            }
        }
    }

    public void GenerateMovingTarget(int numberOfTargets)
    {
        int retryCounter = 0;
        while (numberOfTargets > 0)
        {
            float dimX = Random.Range(targetSpawner.transform.position.x - (targetSpawner.transform.localScale.x / 2), 
                targetSpawner.transform.position.x + (targetSpawner.transform.localScale.x / 2));
            float dimY = Random.Range(targetSpawner.transform.position.y - (targetSpawner.transform.localScale.y / 2), 
                targetSpawner.transform.position.y + (targetSpawner.transform.localScale.y / 2));
            Vector3 targetPosition = new Vector3(dimX, dimY, targetSpawner.transform.position.z);
            Collider[] coliders = Physics.OverlapBox(new Vector3(targetSpawner.transform.position.x, dimY, targetSpawner.transform.position.z),
                new Vector3(targetSpawner.transform.localScale.x / 2, 0.5f, targetSpawner.transform.localScale.z / 2)
                );
            if (coliders.Length == 0)
            {
                Instantiate(movingTarget, targetPosition, Quaternion.identity);
                target.tag = "MovingTarget";
                numberOfTargets--;
            }
            else
            {
                retryCounter++;
            };

            if (retryCounter == 100)
            {
                numberOfTargets--;
                retryCounter = 0;
            };
        }
    }

    public void GenerateDecreasingTargets(int numberOfTargets)
    {
        while (numberOfTargets > 0)
        {
            float dimX = Random.Range(targetSpawner.transform.position.x - (targetSpawner.transform.localScale.x / 2), 
                                      targetSpawner.transform.position.x + (targetSpawner.transform.localScale.x / 2));
            float dimY = Random.Range(targetSpawner.transform.position.y - (targetSpawner.transform.localScale.y / 2), 
                                      targetSpawner.transform.position.y + (targetSpawner.transform.localScale.y / 2));
            Vector3 targetPosition = new Vector3(dimX, dimY, targetSpawner.transform.position.z);
            Collider[] coliders = Physics.OverlapSphere(targetPosition, 1.5f);

            if (coliders.Length == 0)
            {
                Instantiate(decreasingTarget, targetPosition, Quaternion.identity);
                target.tag = "DecreasingTarget";
                numberOfTargets--;
            }
        }
    }

    public void GeneratePrecisionTargets(int numberOfTargets) 
    {
        while (numberOfTargets > 0)
        {
            float dimX = Random.Range(targetSpawner.transform.position.x - (targetSpawner.transform.localScale.x / 2), 
                                      targetSpawner.transform.position.x + (targetSpawner.transform.localScale.x / 2));
            float dimY = Random.Range(targetSpawner.transform.position.y - (targetSpawner.transform.localScale.y / 2), 
                                      targetSpawner.transform.position.y + (targetSpawner.transform.localScale.y / 2));
            Vector3 targetPosition = new Vector3(dimX, dimY, targetSpawner.transform.position.z);
            Collider[] coliders = Physics.OverlapSphere(targetPosition, 0.3f);

            if (coliders.Length == 0)
            {
                Instantiate(precisionTarget, targetPosition, Quaternion.identity);
                target.tag = "PrecisionTarget";
                numberOfTargets--;
            }
        }
    }

    void Update()
    {
        scoreText.text = string.Format("Score: {0}", GameSettings.score);
        if(GameSettings.targetsHit > 0) 
        {
            GameSettings.accuracy = (GameSettings.targetsHit / (GameSettings.targetsHit + GameSettings.missedShots)) * 100;
        }
        else if(GameSettings.missedShots > 0 && GameSettings.targetsHit == 0)
        {
            GameSettings.accuracy = 0;
        };
        accuracyText.text = string.Format("Accuracy: {0:0.00}%", GameSettings.accuracy);
    }
}
