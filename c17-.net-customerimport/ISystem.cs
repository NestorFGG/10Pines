namespace C17_.Net_CustomerImport
{
    public interface ISystem
    {
        void Start();
        void Stop();
        void BeginTransaction();
        void CommitTransaction();
    }
}