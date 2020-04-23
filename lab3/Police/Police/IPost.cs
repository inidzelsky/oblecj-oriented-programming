namespace Police
{
    // Listener interface
    public interface IPost
    {
        void Notify(int dispatcherId, Alert alert);
    }
}