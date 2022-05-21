using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    float speed = 4f;

    public Inventory inventory;

    IResource resource;
    IConsumator consumator;
    IController playerController;


    public event System.Action onInteractResource = delegate { };
    public event System.Action onInteractConsumator = delegate { };
    public event System.Action<float> onMovement = delegate { };


    bool OnResourceReach = false;
    Vector3 dir;

    void Start()
    {
        inventory = new Inventory();
        playerController = new PlayerController(this, GetComponent<PlayerView>());
    }


    void Update()
    {
        playerController.OnUpdate();
    }

    public void Movement(float xDir)
    {
        if(xDir != 0)
        {
            dir = new Vector3(xDir, 0, 0).normalized;

            transform.position += dir * speed * Time.deltaTime;
        }
        onMovement?.Invoke(xDir);
    }

    public void Interact()
    {
        if (OnResourceReach)
        {
            if (resource != null)
            {
                GetResource(resource, resource.ID());
                onInteractResource?.Invoke();
            }
            if (consumator != null && inventory.CheckResource(consumator.ID()))
            {
                UseResource(consumator, consumator.ID());
                onInteractConsumator?.Invoke();
            }
        }
    }

    void GetResource(IResource resource, int id)
    {
        resource.Interact();
        inventory.AddResource(resource.ReturnResource(), id);
    }

    void UseResource(IConsumator consumator, int id)
    {
        var resourceToUse = 0;
        if (id == 0)
        {
            resourceToUse = Mathf.Min(inventory.wood, consumator.MaxItemUsage());
        }
        if (id == 1)
        {
            resourceToUse = Mathf.Min(inventory.stone, consumator.MaxItemUsage());
        }
        consumator.Use(resourceToUse);
        inventory.RemoveResource(resourceToUse, id);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        var resource = collision.GetComponent<IResource>();
        var consumator = collision.GetComponent<IConsumator>();
        if (resource != null)
        {
            this.resource = resource;
            OnResourceReach = true;
        }
        if(consumator != null)
        {
            this.consumator = consumator;
            OnResourceReach = true;
            Debug.Log(consumator.ID());
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var resource = collision.GetComponent<IResource>();
        var consumator = collision.GetComponent<IConsumator>();
        if (resource != null)
        {
            this.resource = null;
            OnResourceReach = false;
        }
        if (consumator != null)
        {
            this.consumator = null;
            OnResourceReach = false;
        }
    }


}
