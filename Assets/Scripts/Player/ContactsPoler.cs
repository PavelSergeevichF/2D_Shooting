
using UnityEngine;

public class ContactsPoler 
{
    private const float _collisionTresh = 0.1f;
    private ContactPoint2D[] _contacts = new ContactPoint2D[10];
    private Collider2D _collider2D;

    public bool isGrrounded { get; private set; }
    public bool hasLeftContacts { get; private set; }
    public bool hasRightContacts { get; private set; }

    public ContactsPoler(Collider2D collider2D)
    {
        _collider2D = collider2D;
    }
     
    public void Update()
    {
        isGrrounded = false;
        hasLeftContacts = false;
        hasRightContacts = false;

        var contactsCount = _collider2D.GetContacts(_contacts);
        for (var i= 0; i<contactsCount; i++)
        {
            var normal = _contacts[i].normal;
            var rigitbody = _contacts[i].rigidbody;

            if(normal.y>_collisionTresh)
            {
                isGrrounded = true;
            }
            if(normal.x > _collisionTresh && rigitbody==null)
            {
                hasLeftContacts = true;
            }
            if (normal.x < -_collisionTresh && rigitbody == null)
            {
                hasRightContacts = true;
            }
        }
    }
}
