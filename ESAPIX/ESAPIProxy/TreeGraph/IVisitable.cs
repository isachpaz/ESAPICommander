namespace ESAPIProxy
{
    public interface IVisitable
    {
        void Accept(ITreeVisitor visitor);
    }
}