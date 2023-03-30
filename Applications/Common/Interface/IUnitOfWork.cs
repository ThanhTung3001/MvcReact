namespace Applications.Common.Interface;

public interface IUnitOfWork
{
    Task CommitAsync();
}