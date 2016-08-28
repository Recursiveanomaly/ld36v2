using UnityEngine;
using System.Collections.Generic;

public class Tablet : MonoBehaviour
{
    public List<Pictograph> pictographList = new List<Pictograph>();
    [TextArea(10, 100)]
    public string documentText;
    public string archeologistName;
    public string carbonDate;
}
