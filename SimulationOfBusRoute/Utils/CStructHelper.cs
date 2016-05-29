using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;


namespace SimulationOfBusRoute.Utils
{
    public static class CStructHelper
    {
        public static Dictionary<string, string> ToPropertiesDictonary(this Type structType)
        {
            Dictionary<string, string> descriptionsList = new Dictionary<string, string>();
            
            DisplayNameAttribute currAttribute;

            foreach (PropertyInfo currProperty in structType.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
            {
                currAttribute = Attribute.GetCustomAttribute(currProperty, typeof(DisplayNameAttribute)) as DisplayNameAttribute;
                
                if (currAttribute == null)
                {
                    continue;
                }

                descriptionsList.Add(currProperty.Name, currAttribute.DisplayName);
            }

            return descriptionsList;
        }
    }
}
