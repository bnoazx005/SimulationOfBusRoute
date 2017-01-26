using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;


namespace SimulationOfBusRoute.Utils
{
    public static class CControlHelper
    {
        public static List<Control> ToFlatCollection(this Control.ControlCollection collection)
        {
            List<Control> flatCollection = new List<Control>();

            foreach (Control control in collection)
            {
                if (control.HasChildren)
                {
                    flatCollection.AddRange(control.Controls.ToFlatCollection());

                    continue;
                }

                flatCollection.Add(control);
            }

            return flatCollection;
        }

        public static Dictionary<string, T> GetControlsDictionaryOfType<T>(this Control.ControlCollection collection) where T : Control
        {
            IEnumerable<T> controlsOfType = collection.ToFlatCollection().OfType<T>();

            return controlsOfType.ToDictionary(t => t.Name);
        }
    }
}
