using LawSuit.Application.Service.Interface;
using LawSuit.Domain.Interface;
using LawSuit.Domain.Model;
using LawSuit.Infrastructure.LawSuitDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawSuit.Infrastructure.Repository
{
    public class UnitOfWorkManegar : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IBaseRepository<Complaint> Complaint { get; private set; }
        public IBaseRepository<Administrator> Administrator { get; private set; }
        public IBaseRepository<User> User { get; private set; }
        public IBaseRepository<Attachment> Attachment { get; private set; }
        public IDemandRepository Demand { get; private set; }

        public UnitOfWorkManegar(AppDbContext context)
        {
            _context = context;
            Complaint = new BaseRepository<Complaint>(_context);
            Administrator = new BaseRepository<Administrator>(_context);
            Attachment = new BaseRepository<Attachment>(_context);
            User = new BaseRepository<User>(_context);
            Demand = new DemandRepository(_context);
        }
        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
