using UnityEngine;

public class Grabber : MonoBehaviour {

    public GameObject selectedObject;

    public Vector3 basePos = Vector3.zero;

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            if(selectedObject == null) {
                RaycastHit hit = CastRay();

                if(hit.collider != null) {
                    if (hit.collider.GetComponent<GameBlock>() == null || hit.collider.transform.parent.name == "CanvasCreator") {
                        return;
                    }

                    selectedObject = hit.collider.transform.parent.gameObject;
                    
                    if(selectedObject.transform.parent.name.Contains("Base")) selectedObject.transform.localScale /= 1.5f;
                    
                    basePos = selectedObject.transform.position;
                    Cursor.visible = false;
                }
            } else {
                Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(selectedObject.transform.position).z);
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
                //selectedObject.transform.position = new Vector3(worldPosition.x, 0f, worldPosition.z);

                if (selectedObject.GetComponent<Cluster>().canBePlaced)
                {
                    selectedObject.transform.position = selectedObject.GetComponent<Cluster>().GetSnapPosition() ?? Vector3.zero;
                    selectedObject.transform.SetParent(GameObject.Find("GameBlocks").transform);
                }
                else
                {
                    selectedObject.transform.position = basePos;
                }

                selectedObject = null;
                Cursor.visible = true;

            }
        }

        if(selectedObject != null) {
            Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(selectedObject.transform.position).z);
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
            selectedObject.transform.position = new Vector3(worldPosition.x, 4, worldPosition.z);
        }
    }

    private RaycastHit CastRay() {
        Vector3 screenMousePosFar = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.farClipPlane);
        Vector3 screenMousePosNear = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.nearClipPlane);
        Vector3 worldMousePosFar = Camera.main.ScreenToWorldPoint(screenMousePosFar);
        Vector3 worldMousePosNear = Camera.main.ScreenToWorldPoint(screenMousePosNear);
        RaycastHit hit;
        Physics.Raycast(worldMousePosNear, worldMousePosFar - worldMousePosNear, out hit);

        return hit;
    }
}
