using SimulationOfBusRoute.Models.Interfaces;
using System;
using System.Collections.Generic;


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

        /// <summary>
        /// Method does nothing for CTimer class.
        /// In debug mode method checks up a state of mCurrState member. 
        /// </summary>

        public override void Verify()
        {
            #if DEBUG

            if (mCurrTime >= uint.MaxValue)
            {
                throw new ArgumentOutOfRangeException("mCurrTime", "A value has reached its maximum. The next step will destroy valid logic of the timer");
            }

            #endif
        }

        /// <summary>
        /// Methods tries to notify all subscribers of the class.
        /// A subscriber can get a notification if its reaction time equals to current inner time of the timer.
        /// </summary>

        private void _notify()
        {
            uint currTime = mCurrTime;
            uint dt = mDeltaTime;

            foreach (IUpdatable currObject in mUpdatableObjects)
            {
                if (currObject.ReactionTime == mCurrTime)
                {
                    currObject.Update(currTime, dt);
                }
            }
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
