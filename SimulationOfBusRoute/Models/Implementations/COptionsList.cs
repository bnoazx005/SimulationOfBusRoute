using System;
using System.Collections.Generic;


namespace SimulationOfBusRoute.Models.Implementations
{
    public class COptionsList : CBaseModel
    {
        private Dictionary<string, int> mIntParams;

        private Dictionary<string, double> mDoubleParams;

        private Dictionary<string, string> mStringParams;

        private Dictionary<string, bool> mBoolParams;

        public COptionsList():
            base(0, "DefaultOptions")
        {
            mIntParams = new Dictionary<string, int>();

            mDoubleParams = new Dictionary<string, double>();

            mStringParams = new Dictionary<string, string>();

            mBoolParams = new Dictionary<string, bool>();
        }

        #region Methods
        

        /// <summary>
        /// Method stores parameter with specified name and integer value. If that parameter already exists,
        /// it replaces an old value with new one.
        /// </summary>
        /// <param name="name">Name of a parameter</param>
        /// <param name="value">Parameter's value</param>

        public void AddIntParam(string name, int value)
        {
            if (mIntParams.ContainsKey(name))
            {
                mIntParams[name] = value;

                return;
            }

            mIntParams.Add(name, value);
        }

        /// <summary>
        /// Method stores parameter with specified name and double value. If that parameter already exists,
        /// it replaces an old value with new one.
        /// </summary>
        /// <param name="name">Name of a parameter</param>
        /// <param name="value">Parameter's value</param>

        public void AddDoubleParam(string name, double value)
        {
            if (mDoubleParams.ContainsKey(name))
            {
                mDoubleParams[name] = value;

                return;
            }

            mDoubleParams.Add(name, value);
        }

        /// <summary>
        /// Method stores parameter with specified name and string value. If that parameter already exists,
        /// it replaces an old value with new one.
        /// </summary>
        /// <param name="name">Name of a parameter</param>
        /// <param name="value">Parameter's value</param>

        public void AddStringParam(string name, string value)
        {
            if (mStringParams.ContainsKey(name))
            {
                mStringParams[name] = value;

                return;
            }

            mStringParams.Add(name, value);
        }

        /// <summary>
        /// Method stores parameter with specified name and boolean value. If that parameter already exists,
        /// it replaces an old value with new one.
        /// </summary>
        /// <param name="name">Name of a parameter</param>
        /// <param name="value">Parameter's value</param>

        public void AddBoolParam(string name, bool value)
        {
            if (mBoolParams.ContainsKey(name))
            {
                mBoolParams[name] = value;

                return;
            }

            mBoolParams.Add(name, value);
        }

        /// <summary>
        /// Method returns a value of specified parameter.
        /// </summary>
        /// <param name="name">Name of a parameter</param>
        /// <returns>Parameter's value</returns>

        public int GetIntParam(string name)
        {
            if (!mIntParams.ContainsKey(name))
            {
                throw new ArgumentOutOfRangeException("name", name, "There is no param with the same value");
            }

            return mIntParams[name];
        }

        /// <summary>
        /// Method returns a value of specified parameter.
        /// </summary>
        /// <param name="name">Name of a parameter</param>
        /// <returns>Parameter's value</returns>

        public double GetDoubleParam(string name)
        {
            if (!mDoubleParams.ContainsKey(name))
            {
                throw new ArgumentOutOfRangeException("name", name, "There is no param with the same value");
            }

            return mDoubleParams[name];
        }

        /// <summary>
        /// Method returns a value of specified parameter.
        /// </summary>
        /// <param name="name">Name of a parameter</param>
        /// <returns>Parameter's value</returns>

        public string GetStringParam(string name)
        {
            if (!mStringParams.ContainsKey(name))
            {
                throw new ArgumentOutOfRangeException("name", name, "There is no param with the same value");
            }

            return mStringParams[name];
        }

        /// <summary>
        /// Method returns a value of specified parameter.
        /// </summary>
        /// <param name="name">Name of a parameter</param>
        /// <returns>Parameter's value</returns>

        public bool GetBoolParam(string name)
        {
            if (!mBoolParams.ContainsKey(name))
            {
                throw new ArgumentOutOfRangeException("name", name, "There is no param with the same value");
            }

            return mBoolParams[name];
        }

        #endregion

        public Dictionary<string, int> IntParams
        {
            get
            {
                return mIntParams;
            }
        }

        public Dictionary<string, double> DoubleParams
        {
            get
            {
                return mDoubleParams;
            }
        }

        public Dictionary<string, string> StringParams
        {
            get
            {
                return mStringParams;
            }
        }

        public Dictionary<string, bool> BoolParams
        {
            get
            {
                return mBoolParams;
            }
        }
    }
}
