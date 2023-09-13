using UnityEngine;
using Utilities;

namespace Core
{
    public class Core : MonoBehaviour 
    {
        public Movement Movement
        {
            get => GenericNotImplementedError<Movement>.TryGet(movement, transform.parent.name);
            private set => movement = value;
        }

        public CollisionSenses CollisionSenses
        {
            get => GenericNotImplementedError<CollisionSenses>.TryGet(collisionSenses, transform.parent.name);
            private set => collisionSenses = value;
        }   

        // public Combat Combat
        // {

        // } 

        private Movement movement;
        private CollisionSenses collisionSenses;
        // private Combat combat;

        private void Awake() 
        {
            movement = GetComponentInChildren<Movement>();
            collisionSenses = GetComponentInChildren<CollisionSenses>();
            // combat = GetComponentInChildren<Combat>();
        }

        public void LogicUpdate()
        {
            Movement.LogicUpdate();
            // Combat.LogicUpdate();
        }
    }
}