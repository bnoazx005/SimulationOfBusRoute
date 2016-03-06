using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SimulationOfBusRoute.Utils
{
    public static class CControlHelper
    {
        public static IEnumerable<Control> FindControlsByType<T>(Control.ControlCollection collection)
        {
            List<Control> resultCollection = new List<Control>();
            
            foreach (Control currControl in collection)
            {
                if (currControl.HasChildren)
                {
                    resultCollection.AddRange(FindControlsByType<T>(currControl.Controls));
                }

                if (currControl.GetType() == typeof(T))
                {                 
                    resultCollection.Add(currControl);
                }
            }

            return resultCollection;
        }
    }
}
