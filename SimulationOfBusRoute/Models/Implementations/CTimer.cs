using SimulationOfBusRoute.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimulationOfBusRoute.Models.Implementations
{
    public class CTimer : CBaseModel
    {
        private List<IUpdatable> mUpdatableObjects;

        private uint mCurrTime;

        private uint mDeltaTime;

        public CTimer(uint initialTime = 0, uint deltaTime = 1):
            base(0, "DefaultTimer")
        {
            mUpdatableObjects = new List<IUpdatable>();

            mCurrTime = initialTime;
            mDeltaTime = deltaTime;
        }

        #region Methods

        /// <summary>
        /// Method subscribe a specified object. A subscriber should implement IUpdatable interface.
        /// </summary>
        /// <param name="updatableObject">An object, which will get notifications of the timer</param>

        public void Subscribe(IUpdatable updatableObject)
        {
            if (updatableObject == null)
            {
                return;
            }

            mUpdatableObjects.Add(updatableObject);
        }

        /// <summary>
        /// Method removes a specified object from subscribers' list.
        /// </summary>
        /// <param name="updatableObject">Current subscriber of the timer, which will remove from the list.</param>

        public void Unsubscribe(IUpdatable updatableObject)
        {
            if (updatableObject == null)
            {
                return;
            }

            mUpdatableObjects.Remove(updatableObject);
        }

        /// <summary>
        /// Method updates inner values of the timer. It should get called every frame or a logic's iteration.
        /// </summary>

        public void Tick()
        {
            _notify();

            mCurrTime += mDeltaTime;
        }

        public void Reset()
        {
            mCurrTime = 0;
        }
        
        /// <summary>
        /// Methods tries to notify all subscribers of the class.
        /// A subscriber can get a notification if its reaction time equals to current inner time of the timer.
        /// </summary>

        private void _notify()
        {
            uint currTime = mCurrTime;
            uint dt = mDeltaTime;
            
            List<IUpdatable> objectsShouldBeUpdated = mUpdatableObjects.FindAll(entity => entity.ReactionTime == currTime);
            objectsShouldBeUpdated.ForEach(_updateObject);
        }

        private void _updateObject(IUpdatable updatableObject)
        {
            updatableObject.Update(mCurrTime, mDeltaTime);
        }

        #endregion

        /// <summary>
        /// The property returns inner time of the timer.
        /// </summary>

        public uint CurrTime
        {
            get
            {
                return mCurrTime;
            }
        }
    }
}
