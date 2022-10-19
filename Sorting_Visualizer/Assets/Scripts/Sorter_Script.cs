using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sorter_Script : MonoBehaviour
{
    public int NumberOfBlocks = 10;
    public GameObject[] Blocks;
    int MaxBlockHeight;
    public float speed;
    private bool isSorting = false;

    // Start is called before the first frame update
    public void StartSort()
    {
        isSorting = true;
        StartCoroutine(BubbleSort(Blocks));        
    }

    public void InitRandomArray() {
        MaxBlockHeight = NumberOfBlocks / 2;
        Blocks = new GameObject[NumberOfBlocks];
        float blockXScale = 30.0f / NumberOfBlocks;

        for (int i = 0; i < NumberOfBlocks; i++) {
            int randomNumber = Random.Range(1, MaxBlockHeight + 1);
            GameObject block = GameObject.CreatePrimitive(PrimitiveType.Cube);
            block.transform.localScale = new Vector3(0.9f, randomNumber, 1);
            block.transform.position = new Vector3(i, randomNumber / 2.0f, 0);
            block.transform.SetParent(this.transform); // handle parent
            Blocks[i] = block;
        }
        Camera.main.transform.position = new Vector3(NumberOfBlocks / 2.1f - 0.2f, NumberOfBlocks / 3.5f - 0.4f , -NumberOfBlocks / 1.8f); // center camera
    }

     /*****************/
     /*****************/
       // ALGORITHMS //
     /*****************/
     /*****************/

    IEnumerator BubbleSort(GameObject[] arr) {
        for (int i = 0; i < arr.Length; i++) {
            for (int j = 0; j < arr.Length - i - 1; j++) {
                yield return new WaitForSeconds(speed);
                if (j != i) {
                    LeanTween.color(arr[j], Color.magenta, 0.01f);
                }
                LeanTween.color(arr[j + 1], Color.cyan, 0.01f);
                if (arr[j].transform.localScale.y > arr[j + 1].transform.localScale.y) {
                    yield return new WaitForSeconds(speed);
                    // swap //
                    GameObject temp = arr[j];
                    Vector3 tempPos = arr[j].transform.localPosition;

                    LeanTween.moveLocalX(arr[j], arr[j + 1].transform.localPosition.x, speed);
                    LeanTween.moveLocalZ(arr[j], -1.5f, speed).setLoopPingPong(1);
                    arr[j] = arr[j + 1];

                    LeanTween.moveLocalX(arr[j + 1], tempPos.x, speed);
                    LeanTween.moveLocalZ(arr[j + 1], 1.5f, speed).setLoopPingPong(1);
                    arr[j + 1] = temp;
                    yield return new WaitForSeconds(speed);
                }
                yield return new WaitForSeconds(speed);
                LeanTween.color(arr[j], Color.gray, 0.01f);
                LeanTween.color(arr[j + 1], Color.gray, 0.01f);
            }
        }
        StartCoroutine(CompleteAnim(Blocks));
    }

    IEnumerator QuickSort(GameObject[] arr) {




        yield return new WaitForSeconds(1f);
    }

    // UTILS //

    IEnumerator CompleteAnim(GameObject[] arr) {
        for (int i = 0; i < arr.Length; i++) {
            yield return new WaitForSeconds(0.1f);
            LeanTween.color(arr[i], Color.green, 0.1f);
        }
        isSorting = false;
        StopAllCoroutines();
    }

    public bool IsSorting() {
        return isSorting;
    }
}
