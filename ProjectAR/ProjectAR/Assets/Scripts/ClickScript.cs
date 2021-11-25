using UnityEngine;

public class ClickScript : MonoBehaviour
{
    #region Serialize Variables

    [SerializeField] private VostokController vostokController = null;
    [SerializeField] private TapCanvasController tapCanvasController = null;

    #endregion

    #region Private Variables

    private bool isWork = false;
    public bool IsWork => isWork;
    private float currentTime = 0f;
    private bool vector = true;
    private float cooldownTime = 1f;
    private Color defaultColor = Color.black;
    private Color currentColor = new Color32(135, 126, 68, 255);

    #endregion

    #region Public Methods

    public void Active(bool state)
    {
        if (state)
        {
            isWork = true;
            currentTime = 0f;
            gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", currentColor);
            //tapCanvasController.InfoWorkStart();
        }
        else
        {
            isWork = false;
            gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", defaultColor);
            //tapCanvasController.InfoWorkEnd();
        }
    }

    public void ActiveInfo(bool state)
    {
        if (state)
        {
            tapCanvasController.InfoWorkStart();
        }
        else
        {
            tapCanvasController.InfoWorkEnd();
        }
    }

    #endregion

    #region Private Methods

    private void Awake()
    {
        tapCanvasController.InfoWorkEnd();
    }

    private void Update()
    {
        if (isWork)
        {
            if (currentTime > cooldownTime || currentTime < 0)
            {
                if (vector)
                {
                    vector = false;
                    currentTime = 1f;
                }
                else
                {
                    vector = true;
                    currentTime = 0f;
                }
            }
            else
            {
                if (vector)
                {
                    currentTime += Time.deltaTime;
                }
                else
                {
                    currentTime -= Time.deltaTime;
                }
                gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.Lerp(defaultColor, currentColor, currentTime));
            }
        }
    }

    private void OnMouseDown()
    {
        vostokController.ClickElement(this);
    }

    #endregion
}
