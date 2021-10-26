using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //all of these variables have to deal with the camera movemnt
    public GameObject player;
    bool playerView = true;
    bool moveCam = false;
    int speed = 2;
    float scale = .25f;
    public float mouseChange;
    float mX;
    float mZ;
    float mChangeX;
    float mChangeZ;
    float cX;
    float cZ;
    float pX;
    float pZ;
    Vector3 savePlayer;
    Vector3 saveCamera;
//================================
    //these are the object which are used in building and thier previews
    GameObject ClearConveyor;
    GameObject Conveyor;
    GameObject ClearMine;
    GameObject Mine;
    GameObject ClearJumpPad;
    GameObject JumpPad;
    GameObject ClearColorCombiner;
    GameObject ColorCombiner;
    GameObject QuantumCompressor;
    GameObject ClearQuantumCompressor;
    //holders for the buildings and previews to manipulate them
    GameObject currentObject;
    GameObject clearPlacing;
    GameObject placing;
    GameObject objectPlacedDown;

    Vector3 prePoint;
    float height;
    public float orientation;
    float holder;
    public int rotate;
    bool building = false;
    Collider[] colliders;
//===============================
    GameObject selectionScreen;
    GameObject screen;
    GameObject whatIsSelected;
    GameObject upButton;
    GameObject upScreen;
    GameObject delButton;
    GameObject delScreen;
    GameObject upDownKeyPad;
    GameObject UpDownKeyPadScreen;
    bool screenActive;
    SimpleHelvetica screenName;
    SimpleHelvetica textName;
    SimpleHelvetica textCost;
    SimpleHelvetica textJumpPad;
    GameObject holderForText;
    GameObject textHolder;
//=================================
    public GameObject core;
    GameObject childNumber;
    string gamer;
    bool tryingToBuild;
    bool canBuild;
    bool canUpgrade;
    GameObject buildingTextHolder;
    //these are for changing the colors which are put into 2 array solid and clear
    public Material[] colorsSolid;
        public Material black;
        public Material red;
        public Material orange;
        public Material yellow;
        public Material green;
        public Material blue;
        public Material purple;
        public Material white;
    Material[] colorsClear;
        public Material blackClear;
        public Material redClear;
        public Material orangeClear;
        public Material yellowClear;
        public Material greenClear;
        public Material blueClear;
        public Material purpleClear;
        public Material whiteClear;
    
    public GameObject[] cubes;
        public GameObject blackCube;
        public GameObject redCube;
        public GameObject orangeCube;
        public GameObject yellowCube;
        public GameObject greenCube;
        public GameObject blueCube;
        public GameObject purpleCube;
        public GameObject whiteCube;
    GameObject[] cubeHolders;

    GameObject[] cubeResources;
        public GameObject redCubeResource;
        public GameObject blueCubeResource;
        public GameObject yellowCubeResource;

    SimpleHelvetica[] cubeCostText;

    int[] buildingCosts;
    int[] upgradingCosts;
    CoreController coreScript;

    bool quickCheckHolder;
    public int universalArrayLength = 8;
    int offsetForCubeCostText;
    //=================================
    GameObject cubeCountTrackerHolder;
    GameObject cubeCountTrackerHolderExtra;
    float[] cubeCountTrackerArray;
    SimpleHelvetica[] cubeCountTrackerText;
    GameObject[] cubeCountTrackerCube;
    public int[] textOffset;
    //================================
    public bool stackable;
    GameObject SmallScaffold;
    GameObject ClearSmallScaffold;
    GameObject LargeScaffold;
    GameObject ClearLargeScaffold;

    // Start is called before the first frame update
    void Start()
    {
        ClearConveyor = Resources.Load("ClearConveyor", typeof(GameObject)) as GameObject;
        Conveyor = Resources.Load("Conveyor", typeof(GameObject)) as GameObject;
        ClearMine = Resources.Load("ClearMine", typeof(GameObject)) as GameObject;
        Mine = Resources.Load("Mine", typeof(GameObject)) as GameObject;
        ClearJumpPad = Resources.Load("ClearJumpPad", typeof(GameObject)) as GameObject;
        JumpPad = Resources.Load("JumpPad", typeof(GameObject)) as GameObject;
        ClearColorCombiner = Resources.Load("ClearColorCombiner", typeof(GameObject)) as GameObject;
        ColorCombiner = Resources.Load("ColorCombiner", typeof(GameObject)) as GameObject;
        ClearQuantumCompressor = Resources.Load("ClearQuantumCompressor", typeof(GameObject)) as GameObject;
        QuantumCompressor = Resources.Load("QuantumCompressor", typeof(GameObject)) as GameObject;
        selectionScreen = Resources.Load("Interface", typeof(GameObject)) as GameObject;
        upButton = Resources.Load("UpgradeButton", typeof(GameObject)) as GameObject;
        delButton = Resources.Load("DeleteButton", typeof(GameObject)) as GameObject;
        upDownKeyPad = Resources.Load("upDownKeyPad", typeof(GameObject)) as GameObject;
        screenName = Resources.Load("ScreenName", typeof(SimpleHelvetica)) as SimpleHelvetica;
        holderForText = Resources.Load("TextHolder", typeof(GameObject)) as GameObject;
        SmallScaffold = Resources.Load("SmallScaffold", typeof(GameObject)) as GameObject;
        ClearSmallScaffold = Resources.Load("ClearSmallScaffold", typeof(GameObject)) as GameObject;
        LargeScaffold = Resources.Load("LargeScaffold", typeof(GameObject)) as GameObject;
        ClearLargeScaffold = Resources.Load("ClearLargeScaffold", typeof(GameObject)) as GameObject;

        colorsSolid = new Material[universalArrayLength];
        colorsClear = new Material[universalArrayLength];
        colorsSolid[0] = black;
        colorsSolid[1] = red;
        colorsSolid[2] = orange;
        colorsSolid[3] = yellow;
        colorsSolid[4] = green;
        colorsSolid[5] = blue;
        colorsSolid[6] = purple;
        colorsSolid[7] = white;

        colorsClear[0] = blackClear;
        colorsClear[1] = redClear;
        colorsClear[2] = orangeClear;
        colorsClear[3] = yellowClear;
        colorsClear[4] = greenClear;
        colorsClear[5] = blueClear;
        colorsClear[6] = purpleClear;
        colorsClear[7] = whiteClear;

        cubes = new GameObject[universalArrayLength];
        cubes[0] = blackCube;
        cubes[1] = redCube;
        cubes[2] = orangeCube;
        cubes[3] = yellowCube;
        cubes[4] = greenCube;
        cubes[5] = blueCube;
        cubes[6] = purpleCube;
        cubes[7] = whiteCube;

        cubeHolders = new GameObject[universalArrayLength];

        cubeResources = new GameObject[3];
        cubeResources[0] = redCubeResource;
        cubeResources[1] = blueCubeResource;
        cubeResources[2] = yellowCubeResource;

        cubeCostText = new SimpleHelvetica[universalArrayLength];

        buildingCosts = new int[universalArrayLength];
        upgradingCosts = new int[universalArrayLength];
        cubeCountTrackerArray = new float[universalArrayLength];
        textOffset = new int[universalArrayLength];
        cubeCountTrackerText = new SimpleHelvetica[universalArrayLength];
        cubeCountTrackerCube = new GameObject[universalArrayLength];
        coreScript = core.GetComponent<CoreController>();
    }
    // Update is called once per frame
    void Update()
    {
        mouseMovement();
        keyChecker();
        movement();
    }

    //checks whether the player is in the top down veiw or not
    private void movement()
    {
        if (playerView)
        {
            playerMovement();
        }
        else if (!playerView)
        {
            skyMovement();
        }
    }

    //runs while the player is in first person mode
    private void playerMovement()
    {
        if (moveCam)
        {

        }
        else if(!moveCam)
        {
            objectChooser();
            costWatcher();

            mouseRay();
            player.transform.eulerAngles = new Vector3(0,pZ + (mChangeX * .1f),0);
            transform.eulerAngles = new Vector3(pX - (mChangeZ * .1f), player.transform.eulerAngles.y, player.transform.eulerAngles.z);
            transform.position = player.transform.position;

            screenSeeker();

            cubeCountTracker();
        }
    }

    //runs while the player is in top down mode
    private void skyMovement()
    {
        if (moveCam)
        {

        }
        else if (!moveCam)
        {
            transform.eulerAngles = new Vector3(90,0,0);
            transform.position = new Vector3(cX + (mChangeX *.1f), 50 * (1 + mouseChange), cZ + (mChangeZ*.1f));
        }
    }

    //checks for when a key is pressed currently only q and scroll
    private void keyChecker()
    {
        if (Input.GetKeyDown("q"))
        {
            if (playerView)
            {
                savePlayer = player.transform.eulerAngles;
                saveCamera = transform.eulerAngles;
                playerView = false;
                mChangeX = 0;
                mChangeZ = 0;
                cX = player.transform.position.x;
                cZ = player.transform.position.z;
                player.transform.eulerAngles = new Vector3(0,0,0);
            }
            else if (!playerView)
            {
                playerView = true;
                mChangeX = 0;
                mChangeZ = 0;
                cX = player.transform.eulerAngles.x;
                cZ = player.transform.eulerAngles.y;
                player.transform.eulerAngles = savePlayer;
                transform.eulerAngles = saveCamera;
            }
        }
        if (!playerView)
        {
            mouseChange -= Input.mouseScrollDelta.y * scale;
        }
        else
        {
            holder = orientation;
            orientation -= Input.mouseScrollDelta.y;
            if(holder > orientation)
            {
                if (rotate == 270)
                {
                    rotate = 0;
                }
                else
                {
                    rotate += 90;
                }
            }
            else if (holder < orientation)
            {
                if (rotate == 0)
                {
                    rotate = 270;
                }
                else
                {
                    rotate -= 90;
                }
            }
        }
    }

    //makes the camera and player rotate based on mouse movement
    private void mouseMovement()
    {
        if (Input.GetMouseButtonDown(2))
        {
            mX = Input.mousePosition.x;
            mZ = Input.mousePosition.y;
            mChangeX = 0;
            mChangeZ = 0;
            cX = transform.position.x + (mChangeX * .1f);
            cZ = transform.position.z + (mChangeZ * .1f);
            pX = transform.eulerAngles.x + (mChangeX * .1f);
            pZ = transform.eulerAngles.y + (mChangeZ * .1f);
        }
        if (Input.GetMouseButton(2))
        {
            mChangeX = mX - Input.mousePosition.x;
            mChangeZ = mZ - Input.mousePosition.y;
        }
        if (Input.GetMouseButtonUp(2))
        {
            cX = transform.position.x - (mChangeX * .1f);
            cZ = transform.position.z - (mChangeZ * .1f);
        }
    }

    //the main function which runs all of the building, building previews, the pop-up screen, and manages updateing all of it
    private void mouseRay()
    {
        //Raycasts from the mouse out 100 units
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100.0f))
        {
            //manages the build previews and building
            if (building)
            {
                //destroyes left over screens
                if (screen != null)
                {
                    Destroy(screen.gameObject);
                    Destroy(upScreen.gameObject);
                    Destroy(delScreen.gameObject);
                    Destroy(textName.gameObject);
                    Destroy(textCost.gameObject);
                    Destroy(textHolder.gameObject);
                    if (UpDownKeyPadScreen != null)
                    {
                        Destroy(UpDownKeyPadScreen.gameObject);
                    }
                    Colorater(whatIsSelected,white,colorsSolid);
                    whatIsSelected = (null);
                    screenActive = false;
                }
                //creates the preview
                if (currentObject == (null))
                {
                    if (hit.transform.tag == placing.tag && !stackable)
                    {
                        currentObject = Instantiate(clearPlacing, new Vector3(Mathf.Round(hit.point.x), hit.point.y + (height / 2) - height, Mathf.Round(hit.point.z)), Quaternion.Euler(0, rotate, 0));
                        buildingTextHolder = Instantiate(holderForText, new Vector3(currentObject.transform.position.x, currentObject.transform.position.y + (height / 2) - height, currentObject.transform.position.z), Quaternion.Euler(0, 0, 0));
                        offsetForCubeCostText = 0;
                        for(int j = 0; j < universalArrayLength; j++)
                        {
                            if(buildingCosts[j] != 0)
                            {
                                cubeCostText[j] = Instantiate(screenName, new Vector3(buildingTextHolder.transform.position.x, buildingTextHolder.transform.position.y + (height / 2) + .1f + (offsetForCubeCostText*.5f), buildingTextHolder.transform.position.z), Quaternion.Euler(0, 0, 0));
                                cubeCostText[j].Text = buildingCosts[j].ToString();
                                cubeCostText[j].GenerateText();
                                cubeCostText[j].transform.SetParent(buildingTextHolder.transform);
                                cubeHolders[j] = Instantiate(cubes[j], new Vector3(buildingTextHolder.transform.position.x - .25f, buildingTextHolder.transform.position.y + .3f + (height / 2) + (offsetForCubeCostText*.5f), buildingTextHolder.transform.position.z), Quaternion.Euler(0, 0, 0));
                                cubeHolders[j].transform.SetParent(buildingTextHolder.transform);
                                Destroy(cubeHolders[j].GetComponent<Rigidbody>());
                                Destroy(cubeHolders[j].GetComponent<Collider>());
                                Destroy(cubeHolders[j].GetComponent<BallController>());
                                offsetForCubeCostText += 1;
                            }
                        }
                    }
                    else
                    {
                        currentObject = Instantiate(clearPlacing, new Vector3(Mathf.Round(hit.point.x), hit.point.y + (height / 2), Mathf.Round(hit.point.z)), Quaternion.Euler(0, rotate, 0));
                        buildingTextHolder = Instantiate(holderForText, new Vector3(currentObject.transform.position.x, currentObject.transform.position.y + (height / 2), currentObject.transform.position.z), Quaternion.Euler(0, 0, 0));
                        offsetForCubeCostText = 0;
                        for (int j = 0; j < universalArrayLength; j++)
                        {
                            if (buildingCosts[j] != 0)
                            {
                                cubeCostText[j] = Instantiate(screenName, new Vector3(buildingTextHolder.transform.position.x, buildingTextHolder.transform.position.y + (height / 2) + .1f + (offsetForCubeCostText * .5f), buildingTextHolder.transform.position.z), Quaternion.Euler(0, 0, 0));
                                cubeCostText[j].Text = buildingCosts[j].ToString();
                                cubeCostText[j].GenerateText();
                                cubeCostText[j].transform.SetParent(buildingTextHolder.transform);
                                cubeHolders[j] = Instantiate(cubes[j], new Vector3(buildingTextHolder.transform.position.x - .25f, buildingTextHolder.transform.position.y + .3f + (height / 2) + (offsetForCubeCostText * .5f), buildingTextHolder.transform.position.z), Quaternion.Euler(0, 0, 0));
                                cubeHolders[j].transform.SetParent(buildingTextHolder.transform);
                                Destroy(cubeHolders[j].GetComponent<Rigidbody>());
                                Destroy(cubeHolders[j].GetComponent<Collider>());
                                Destroy(cubeHolders[j].GetComponent<BallController>());
                                offsetForCubeCostText += 1;
                            }
                        }
                    }
                    if (!canBuild)
                    {
                        SimpleColorater(currentObject, redClear);
                        tryingToBuild = false;
                    }
                    else
                    {
                        Colorater(currentObject, whiteClear,colorsClear);
                    }
                }
                //moves the preview
                else if (currentObject != (null))
                {
                    if (prePoint != new Vector3(Mathf.Round(hit.point.x), hit.point.y, Mathf.Round(hit.point.z)) || (rotate) != currentObject.transform.eulerAngles.y || (!tryingToBuild && canBuild))
                    {
                        if (hit.transform.tag == placing.tag && !stackable)
                        {
                            currentObject.transform.position = new Vector3(Mathf.Round(hit.point.x), hit.point.y + (height / 2) - height, Mathf.Round(hit.point.z));
                            currentObject.transform.eulerAngles = new Vector3(0, rotate, 0);
                            buildingTextHolder.transform.position = new Vector3(Mathf.Round(hit.point.x), hit.point.y + (height / 2) - height, Mathf.Round(hit.point.z));
                            currentObject.transform.eulerAngles = new Vector3(0, rotate, 0);
                        }
                        else
                        {
                            currentObject.transform.position = new Vector3(Mathf.Round(hit.point.x), hit.point.y + (height / 2), Mathf.Round(hit.point.z));
                            currentObject.transform.eulerAngles = new Vector3(0, rotate, 0);
                            buildingTextHolder.transform.position = new Vector3(Mathf.Round(hit.point.x), hit.point.y + (height / 2), Mathf.Round(hit.point.z));
                            currentObject.transform.eulerAngles = new Vector3(0, rotate, 0);
                        }

                        if (!canBuild)
                        {
                            SimpleColorater(currentObject, redClear);
                            tryingToBuild = false;
                        }
                        else
                        {
                            Colorater(currentObject, whiteClear,colorsClear);
                        }
                    }
                }
                //builds the preview
                if (Input.GetMouseButtonUp(0))
                {
                    if (canBuild)
                    {
                        if (hit.transform.tag == placing.tag && !stackable)
                        {
                            Destroy(hit.transform.gameObject);
                            objectPlacedDown = Instantiate(placing, new Vector3(Mathf.Round(hit.point.x), hit.point.y + (height / 2) - (height), Mathf.Round(hit.point.z)), Quaternion.Euler(0, rotate, 0));
                        }
                        else
                        {
                            objectPlacedDown = Instantiate(placing, new Vector3(Mathf.Round(hit.point.x), hit.point.y + (height / 2), Mathf.Round(hit.point.z)), Quaternion.Euler(0, rotate, 0));
                        }
                        if (placing == Conveyor)
                        {
                            objectPlacedDown.name = "new";
                        }
                        objectPlacedDown.name = gamer;
                        costCost();
                    }
                }
            }
            //destroys left over build previews
            if (!building)
            {
                Destroy(currentObject);
                Destroy(buildingTextHolder);
            }
            //destroys object and associated screens
            if (Input.GetMouseButtonDown(1))
            {
                //chackes if it is a valid target
                if(hit.transform.tag != "floor" && hit.transform.tag != "ball" && hit.transform.tag != "core" && hit.transform.tag != "screen")
                {
                    //checks if it was a conveyor and destroys its walls
                    if(hit.transform.tag == "conveyor")
                    {
                        if((colliders = Physics.OverlapSphere(hit.transform.position,.5f)).Length > 1)
                        {
                            foreach(var collider in colliders)
                            {
                                var go = collider.gameObject;
                                if(go.tag == "wall")
                                {
                                    Destroy(go.gameObject);
                                }
                            }
                        }
                    }
                    //destroys the screen
                    if (screen != null && whatIsSelected == hit.transform.gameObject)
                    {
                        Destroy(screen.gameObject);
                        Destroy(upScreen.gameObject);
                        Destroy(delScreen.gameObject);
                        Destroy(textName.gameObject);
                        Destroy(textHolder.gameObject);
                        if(UpDownKeyPadScreen != null)
                        {
                            Destroy(UpDownKeyPadScreen.gameObject);
                        }
                        screenActive = false;
                    }
                    //destroys the object
                    Destroy(hit.transform.gameObject);
                }
            }
            //manages the screens
            if (!building)
            {
                //builds screens and manages buttons
                if (Input.GetMouseButtonDown(0))
                {
                    //checks if what you are clicking on is valid
                    if (hit.transform.tag != "floor" && hit.transform.tag != "ball" && hit.transform.tag != "wall" && hit.transform.tag != "screen" && hit.transform.tag != "button" && hit.transform.tag != "core" && hit.transform.tag != "slider" && hit.transform.tag != "sliderBar")
                    {
                        //destroys pre-existing screens
                        if (screen != null)
                        {
                            Destroy(screen.gameObject);
                            Destroy(upScreen.gameObject);
                            Destroy(delScreen.gameObject);
                            Destroy(textName.gameObject);
                            Destroy(textCost.gameObject);
                            Destroy(textHolder.gameObject);
                            if(UpDownKeyPadScreen != null)
                            {
                                Destroy(UpDownKeyPadScreen.gameObject);
                            }
                            Colorater(whatIsSelected, white, colorsSolid);
                        }
                        //creates the screen
                        whatIsSelected = hit.transform.gameObject;
                        SimpleColorater(whatIsSelected, greenClear);
                        screen = Instantiate(selectionScreen, new Vector3(whatIsSelected.transform.position.x, whatIsSelected.transform.position.y + 2.5f, whatIsSelected.transform.position.z), Quaternion.Euler(0, player.transform.eulerAngles.y, 0));
                        upScreen = Instantiate(upButton, new Vector3(whatIsSelected.transform.position.x, whatIsSelected.transform.position.y + 2.5f, whatIsSelected.transform.position.z), Quaternion.Euler(0, player.transform.eulerAngles.y, 0));
                        upScreen.name = "upgrade";
                        delScreen = Instantiate(delButton, new Vector3(whatIsSelected.transform.position.x, whatIsSelected.transform.position.y + 2.5f, whatIsSelected.transform.position.z), Quaternion.Euler(0, player.transform.eulerAngles.y, 0));
                        delScreen.name = "delete";
                        textHolder = Instantiate(holderForText, new Vector3(whatIsSelected.transform.position.x, whatIsSelected.transform.position.y + 2.5f, whatIsSelected.transform.position.z), Quaternion.Euler(0, 0, 0));
                        textName = Instantiate(screenName, new Vector3(textHolder.transform.position.x-2, textHolder.transform.position.y, textHolder.transform.position.z-.25f), Quaternion.Euler(0, 0, 0));
                        textName.Text = whatIsSelected.name;
                        textName.GenerateText();
                        textName.transform.SetParent(textHolder.transform);
                        textCost = Instantiate(screenName, new Vector3(textHolder.transform.position.x - 1, textHolder.transform.position.y-1, textHolder.transform.position.z - .25f), Quaternion.Euler(0, 0, 0));
                        textCost.GenerateText();
                        textCost.transform.SetParent(textHolder.transform);
                        if(whatIsSelected.tag == "jumpPad")
                        {
                            UpDownKeyPadScreen = Instantiate(upDownKeyPad, new Vector3(whatIsSelected.transform.position.x, whatIsSelected.transform.position.y + 2.5f, whatIsSelected.transform.position.z), Quaternion.Euler(0, player.transform.eulerAngles.y, 0));
                            textJumpPad = Instantiate(screenName, new Vector3(textHolder.transform.position.x + 1, textHolder.transform.position.y - 1.22f, textHolder.transform.position.z - .25f), Quaternion.Euler(0, 0, 0));
                            textJumpPad.Text = whatIsSelected.GetComponent<JumpPad>().JumpPadPower.ToString();
                            textJumpPad.GenerateText();
                            textJumpPad.transform.SetParent(textHolder.transform);
                            whatIsSelected.GetComponent<JumpPad>().trail();
                        }
                        screenActive = true;
                    }
                    //checks if you clicked on a button
                    else if(hit.transform.tag == "button")
                    {
                        if (hit.transform.name == "delete")
                        {
                            Destroy(screen.gameObject);
                            Destroy(upScreen.gameObject);
                            Destroy(delScreen.gameObject);
                            Destroy(textName.gameObject);
                            Destroy(textHolder.gameObject);
                            Colorater(whatIsSelected, white,colorsSolid);
                            if(UpDownKeyPadScreen != null)
                            {
                                Destroy(UpDownKeyPadScreen.gameObject);
                            }
                            whatIsSelected = (null);
                            screenActive = false;
                        }
                        else if(hit.transform.name == "Up")
                        {
                            if (whatIsSelected.GetComponent<JumpPad>().JumpPadPower < 9)
                            {
                                whatIsSelected.GetComponent<JumpPad>().JumpPadPower += 1;
                                textJumpPad.Text = whatIsSelected.GetComponent<JumpPad>().JumpPadPower.ToString();
                                textJumpPad.GenerateText();
                            }
                        }
                        else if (hit.transform.name == "Down")
                        {
                            if (whatIsSelected.GetComponent<JumpPad>().JumpPadPower > 1)
                            {
                                whatIsSelected.GetComponent<JumpPad>().JumpPadPower -= 1;
                                textJumpPad.Text = whatIsSelected.GetComponent<JumpPad>().JumpPadPower.ToString();
                                textJumpPad.GenerateText();
                            }
                        }
                        else if(hit.transform.name == "Eject")
                        {
                            if (coreScript.deleteExtra)
                            {
                                hit.transform.GetComponent<Renderer>().sharedMaterial = colorsSolid[4];
                                coreScript.deleteExtra = false;
                            }
                            else
                            {
                                hit.transform.GetComponent<Renderer>().sharedMaterial = colorsSolid[1];
                                coreScript.deleteExtra = true;
                            }
                        }
                    }
                }
            }
            //used to check if locatian has changed [might not be used?]
            prePoint = new Vector3(Mathf.Round(hit.point.x), hit.point.y, Mathf.Round(hit.point.z));
        }
    }

    //sets variables based on what # is selected
    private void objectChooser()
    {
        //nothing just selecting
        if (Input.GetKeyDown("1"))
        {
            IntArrayClearer(buildingCosts);
            building = false;
        }
        //conveyor belts
        if (Input.GetKeyDown("2"))
        {
            clearPlacing = ClearConveyor;
            placing = Conveyor;
            height = 0.1f;
            IntArrayClearer(buildingCosts);
            buildingCosts[1] = 2;
            building = true;
            stackable = false;
            gamer = "Conveyor t1";
            Destroyer();
        }
        //mines
        else if (Input.GetKeyDown("3"))
        {
            clearPlacing = ClearMine;
            placing = Mine;
            height = 3f;
            IntArrayClearer(buildingCosts);
            buildingCosts[1] = 20;
            building = true;
            stackable = false;
            gamer = "Mine t1";
            Destroyer();
        }
        //jumppads
        else if (Input.GetKeyDown("4"))
        {
            clearPlacing = ClearJumpPad;
            placing = JumpPad;
            height = 0.1f;
            IntArrayClearer(buildingCosts);
            buildingCosts[1] = 25;
            buildingCosts[5] = 25;
            building = true;
            stackable = false;
            gamer = "JumpPad t1";
            Destroyer();
        }
        //color Combiner
        else if (Input.GetKeyDown("5"))
        {
            clearPlacing = ClearColorCombiner;
            placing = ColorCombiner;
            height = 3f;
            IntArrayClearer(buildingCosts);
            buildingCosts[1] = 50;
            buildingCosts[4] = 50;
            buildingCosts[5] = 50;
            building = true;
            stackable = false;
            gamer = "ColorCombiner t1";
            Destroyer();
        }
        //Quantum Compressor
        else if (Input.GetKeyDown("6"))
        {
            clearPlacing = ClearQuantumCompressor;
            placing = QuantumCompressor;
            height = 7f;
            IntArrayClearer(buildingCosts);
            for(int i = 1; i < 7; i++)
            {
                buildingCosts[i] = 100;
            }
            building = true;
            stackable = false;
            gamer = "Quantum Compressor t1";
            Destroyer();
        }
        //smallScaffold
        else if (Input.GetKeyDown("7"))
        {
            clearPlacing = ClearSmallScaffold;
            placing = SmallScaffold;
            height = 1f;
            IntArrayClearer(buildingCosts);
            buildingCosts[4] = 3;
            building = true;
            stackable = true;
            gamer = "Small Scaffold";
            Destroyer();
        }
        //largeScaffold
        else if (Input.GetKeyDown("8"))
        {
            clearPlacing = ClearLargeScaffold;
            placing = LargeScaffold;
            height = 3f;
            IntArrayClearer(buildingCosts);
            buildingCosts[4] = 10;
            building = true;
            stackable = true;
            gamer = "Small Scaffold";
            Destroyer();
        }
    }

    //roates the pop-up window and other object towards the players view
    private void screenSeeker()
    {
        if (screenActive)
        {
            screen.transform.eulerAngles = new Vector3(transform.eulerAngles.x,player.transform.eulerAngles.y,transform.eulerAngles.z);
            upScreen.transform.eulerAngles = new Vector3(transform.eulerAngles.x,player.transform.eulerAngles.y,transform.eulerAngles.z);
            delScreen.transform.eulerAngles = new Vector3(transform.eulerAngles.x,player.transform.eulerAngles.y,transform.eulerAngles.z);
            textHolder.transform.eulerAngles = new Vector3(transform.eulerAngles.x,player.transform.eulerAngles.y,transform.eulerAngles.z);
            if(UpDownKeyPadScreen != null)
            {
                UpDownKeyPadScreen.transform.eulerAngles = new Vector3(transform.eulerAngles.x, player.transform.eulerAngles.y, transform.eulerAngles.z);
            }
        }
        if (building && buildingTextHolder != (null))
        {
            buildingTextHolder.transform.eulerAngles = new Vector3(transform.eulerAngles.x, player.transform.eulerAngles.y, transform.eulerAngles.z);
        }
        if(cubeCountTrackerHolder != null)
        {
            cubeCountTrackerHolder.transform.eulerAngles = new Vector3(transform.eulerAngles.x, player.transform.eulerAngles.y, transform.eulerAngles.z);
        }
    }

    //checks if you are able to build or upgrade based on cost and collision
    private void costWatcher()
    {
        //checks if you have enough to build
        if (currentObject != null)
        {
            quickCheckHolder = true;
            for (int j = 0;j < universalArrayLength; j++)
            {
                if(buildingCosts[j] > coreScript.cubeCounts[j])
                {
                    quickCheckHolder = false;
                }
            }
            if (quickCheckHolder)
            {
                canBuild = true;
            }
            else
            {
                canBuild = false;
            }
        }
        //checks if you have enough to upgrade
        if (whatIsSelected != null)
        {
            quickCheckHolder = true;
            for (int j = 0; j < universalArrayLength; j++)
            {
                if (upgradingCosts[j] > coreScript.cubeCounts[j])
                {
                    quickCheckHolder = false;
                }
            }
            if (quickCheckHolder)
            {
                canUpgrade = true;
            }
            else
            {
                canUpgrade = false;
            }
        }
    }

    //pays the cost to build or upgrade
    private void costCost()
    {
        if (building)
        {
            for (int j = 0; j < universalArrayLength; j++)
            {
                coreScript.cubeCounts[j] -= buildingCosts[j];
            }
        }
        else
        {
            for (int j = 0; j < universalArrayLength; j++)
            {
                coreScript.cubeCounts[j] -= upgradingCosts[j];
            }
        }
    }

    //destroyes the preview when building
    private void Destroyer()
    {
        if(currentObject != null)
        {
            Destroy(currentObject);
            Destroy(buildingTextHolder);
        }
    }

    //changes the color of objects and thier children based on thier original color
    private void Colorater(GameObject colorer,Material mainColor,Material[] arrayOfColor)
    {
        if(colorer.tag == "jumpPad" && whatIsSelected != null)
        {
            whatIsSelected.GetComponent<JumpPad>().destroyBall();
        }
        for (int j = 0; j < colorer.transform.childCount; j++)
        {
            childNumber = colorer.transform.GetChild(j).gameObject;
            childNumber.GetComponentInChildren<Renderer>().material = arrayOfColor[int.Parse(childNumber.name)];
        }
        if (colorer.GetComponent<Renderer>() != (null))
        {
            colorer.GetComponent<Renderer>().material = mainColor;
        }
    }

    //changes the color of objects and thier children based on the color given
    private void SimpleColorater(GameObject colorer, Material mainColor)
    {
        if (colorer.tag == "jumpPad" && whatIsSelected != null)
        {
            whatIsSelected.GetComponent<JumpPad>().destroyBall();
        }
        for (int j = 0; j < colorer.transform.childCount; j++)
        {
            childNumber = colorer.transform.GetChild(j).gameObject;
            childNumber.GetComponentInChildren<Renderer>().material = mainColor;
        }
        if (colorer.GetComponent<Renderer>() != (null))
        {
            colorer.GetComponent<Renderer>().material = mainColor;
        }
    }

    //wipes the given int array
    private void IntArrayClearer(int[] arrayToBeCleared)
    {
        for(int j = 0; j<arrayToBeCleared.Length; j++)
        {
            arrayToBeCleared[j] = 0;
        }
    }


    private void cubeCountTracker()
    {
        if(cubeCountTrackerHolder == null)
        {
            cubeCountTrackerHolder = Instantiate(holderForText, new Vector3(transform.position.x, transform.position.y, transform.position.z),Quaternion.Euler(0,0,0));
            cubeCountTrackerHolder.transform.SetParent(player.transform);
        }
        else if(cubeCountTrackerHolder != null)
        {
            intArraySorter(coreScript.cubeCounts, textOffset);
            for (int i = 0; i < universalArrayLength; i++)
            {
                if(true)//meaningless
                {
                    if (coreScript.cubeCounts[i] != 0)
                    {
                        if (cubeCountTrackerCube[i] == null)
                        {
                            cubeCountTrackerHolderExtra = Instantiate(holderForText, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler(0, 0, 0));
                            cubeCountTrackerText[i] = Instantiate(screenName, new Vector3(transform.position.x-1, transform.position.y + .5f, transform.position.z+2),Quaternion.Euler(0,0,0));
                            cubeCountTrackerText[i].Text = coreScript.cubeCounts[i].ToString();
                            cubeCountTrackerText[i].GenerateText();
                            cubeCountTrackerText[i].transform.localScale = new Vector3(cubeCountTrackerText[i].transform.localScale.x/4, cubeCountTrackerText[i].transform.localScale.y/4, cubeCountTrackerText[i].transform.localScale.z/4);
                            cubeCountTrackerText[i].transform.SetParent(cubeCountTrackerHolderExtra.transform);
                            cubeCountTrackerCube[i] = Instantiate(cubes[i], new Vector3(transform.position.x - (.25f/4)-1, transform.position.y + .5f+(.2f/4), transform.position.z+2), Quaternion.Euler(0,0, 0));
                            cubeCountTrackerCube[i].transform.SetParent(cubeCountTrackerHolderExtra.transform);
                            cubeCountTrackerCube[i].transform.localScale = new Vector3(cubeCountTrackerCube[i].transform.localScale.x/4, cubeCountTrackerCube[i].transform.localScale.y/4, cubeCountTrackerCube[i].transform.localScale.z/4);
                            Destroy(cubeCountTrackerCube[i].GetComponent<Rigidbody>());
                            Destroy(cubeCountTrackerCube[i].GetComponent<Collider>());
                            Destroy(cubeCountTrackerCube[i].GetComponent<BallController>());
                            cubeCountTrackerHolderExtra.transform.eulerAngles = new Vector3(transform.eulerAngles.x, player.transform.eulerAngles.y, transform.eulerAngles.z);
                            cubeCountTrackerText[i].transform.SetParent(cubeCountTrackerHolder.transform);
                            cubeCountTrackerCube[i].transform.SetParent(cubeCountTrackerHolder.transform);
                            Destroy(cubeCountTrackerHolderExtra.gameObject);
                            cubeCountTrackerArray[i] = cubeCountTrackerText[i].transform.localPosition.y;
                        }
                        else if(cubeCountTrackerCube[i] != null)
                        {
                            cubeCountTrackerText[i].transform.localPosition = new Vector3(cubeCountTrackerText[i].transform.localPosition.x, cubeCountTrackerArray[i] - (textOffset[i] * .15f), cubeCountTrackerText[i].transform.localPosition.z);
                            cubeCountTrackerText[i].Text = coreScript.cubeCounts[i].ToString();
                            cubeCountTrackerText[i].GenerateText();
                            cubeCountTrackerCube[i].transform.localPosition = new Vector3(cubeCountTrackerCube[i].transform.localPosition.x, cubeCountTrackerArray[i] + (.2f / 4) - (textOffset[i]*.15f), cubeCountTrackerCube[i].transform.localPosition.z);
                        }
                    }
                    else if(coreScript.cubeCounts[i] == 0)
                    {
                        if (cubeCountTrackerCube[i] != null)
                        {
                            Destroy(cubeCountTrackerCube[i].gameObject);
                            Destroy(cubeCountTrackerText[i].gameObject);
                        }
                    }
                }
            }
        }
    }

    private void intArraySorter(int[] arrayToBeSorted,int[]sortedArray)
    {
        int[] copyArray = new int[arrayToBeSorted.Length];
        for(int i = 0; i < arrayToBeSorted.Length; i++)
        {
            copyArray[i] = arrayToBeSorted[i];
        }
        for(int i = 0; i < copyArray.Length; i++)
        {
            int lowestPoint = i;
            for(int j = i + 1; j< copyArray.Length; j++)
            {
                if (copyArray[j] > copyArray[lowestPoint])
                {
                    lowestPoint = j;
                }
            }
            int max = copyArray[lowestPoint];
            copyArray[lowestPoint] = copyArray[i];
            copyArray[i] = max;
        }
        for(int i = 0; i < copyArray.Length; i++)
        {
            for(int j = 0; j < copyArray.Length; j++)
            {
                if(arrayToBeSorted[i] == copyArray[j])
                {
                    sortedArray[i] = j;
                }
            }
        }
    }
}
