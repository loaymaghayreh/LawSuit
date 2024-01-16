using LawSuit.Application.Service.Interface;
using LawSuit.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawSuit.Domain.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<Complaint> Complaint {  get; }
        IBaseRepository<User> User { get; }
        IBaseRepository<Administrator> Administrator { get; }
        IDemandRepository Demand { get; }
        Task CompleteAsync();
    }
}
