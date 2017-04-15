namespace BusinessLight.Data.DocumentDb
{
    public class DocumentDbUnitOfWorkFactory : IUnitOfWorkFactory
    {
        public IUnitOfWork GetUnitOfWork()
        {
            return new DocumentDbUnitOfWork();
        }
    }
}