using System;


namespace SimulationOfBusRoute.Models.Implementations
{
    public class CBusRoute : CBaseModel
    {
        public CBusRoute():
            base(0, "DefaultBusRoute")
        {
        }

        #region Methods

        public override void Verify()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
