namespace OutcoldSolutions.ObjectReleaseVerification.Sample
{
    using System.Collections.Generic;
    using System.Diagnostics;

    public class CustomVerificationHandler : IVerificationHandler
    {
        public void VerificationSucceeded(IEnumerable<ITrackingObject> releasedObjects)
        {
        }

        public void VerificationFailed(IEnumerable<ITrackingObject> releasedObjects, IEnumerable<ITrackingObject> aliveObjects)
        {
            Debug.Fail("Application has memory leaks! See output window for details.");
        }
    }
}