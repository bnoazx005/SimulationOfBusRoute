using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;


namespace SimulationOfBusRoute.Utils
{
    public static class CEnumHelper
    {
        public static List<KeyValuePair<string, int>> ToDescriptionsList(this Type enumType)
        {
            List<KeyValuePair<string, int>> descriptionsList = new List<KeyValuePair<string, int>>();

            FieldInfo currFieldInfo;
            DescriptionAttribute currAttribute;

            foreach (Enum value in Enum.GetValues(enumType))
            {
                currFieldInfo = enumType.GetField(value.ToString());
                currAttribute = Attribute.GetCustomAttribute(currFieldInfo, typeof(DescriptionAttribute)) as DescriptionAttribute;

                if (currAttribute == null)
                {
                    continue;
                }

                descriptionsList.Add(new KeyValuePair<string, int>(currAttribute.Description, Convert.ToInt32(value)));
            }

            return descriptionsList;
        }
    }
}
