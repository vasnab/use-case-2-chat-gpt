using System.Runtime.Serialization;

namespace StripeIntegration;

[Serializable]
public class StripeServiceException : Exception, ISerializable
{
    public StripeServiceException(string message)
        : base(message)
    {
    }

    public StripeServiceException(string message, Exception inner)
        : base(message, inner)
    {
    }

    protected StripeServiceException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }

    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        if (info == null)
        {
            throw new ArgumentNullException(nameof(info));
        }

        base.GetObjectData(info, context);
    }
}
