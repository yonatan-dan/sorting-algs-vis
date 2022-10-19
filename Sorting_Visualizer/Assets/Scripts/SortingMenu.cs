using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SortingMenu : MonoBehaviour
{
    public Sorter_Script sorterScriptRef;    
    public Slider arraySize, speed;

    private Sorter_Script activeSorter;

    public void StartSort()
    {
        if (activeSorter != null && !activeSorter.IsSorting()) {
            activeSorter.speed = 1.0f / speed.value;
            activeSorter.StartSort();
        }
    }

    public void ResetSort() {
        if (activeSorter != null && !activeSorter.IsSorting()) {
            Destroy(activeSorter.gameObject);
            activeSorter = Instantiate(sorterScriptRef);
            activeSorter.NumberOfBlocks = (int)arraySize.value;
            activeSorter.InitRandomArray();
        }
    }

    public void onSpeedChange() {
        if (activeSorter != null) {
            activeSorter.speed = 1.0f / speed.value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        activeSorter = Instantiate(sorterScriptRef);
        activeSorter.NumberOfBlocks = (int)arraySize.value;
        activeSorter.InitRandomArray();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
