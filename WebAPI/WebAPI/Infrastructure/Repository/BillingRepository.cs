using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using WebAPI.Domain.Model;

namespace WebAPI.Infrastructure.Repository
{
    public class BillingRepository : IBillingRepository
    {
        private readonly ConnectionContext _connectionContext;
        public BillingRepository(ConnectionContext connectionContext)
        {
            _connectionContext = connectionContext;
        }

        public bool Delete(Guid id)
        {
            _connectionContext.Billings.RemoveRange(new Billing { Id = id });
            _connectionContext.SaveChanges();
            return true;
        }

        public Task<Billing> Get(Guid id)
        {
            return _connectionContext.Billings.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<List<Billing>> GetBillings()
        {
            return _connectionContext.Billings.ToListAsync();
        }

        public bool Insert(Billing billing)
        {
            //_connectionContext.Billings.Add(billing);
            InsertBilling(billing);
            InsertLines(billing);
            return true;
        }

        private void InsertBilling(Billing billing)
        {
            _connectionContext.Database.ExecuteSqlRaw($"INSERT INTO Billings (Id,InvoiceNumber,CustomerId,Date,DueDate,TotalAmount,Currency) VALUES ('{billing.Id}','{billing.InvoiceNumber}','{billing.Customer.Id}','{billing.Date}','{billing.DueDate}',{billing.TotalAmount},'{billing.Currency}')");
            _connectionContext.SaveChanges();
        }

        public void InsertLines(Billing billing)
        {
            billing.Lines.ForEach(l => l.BillingId = billing.Id);
            for (int i = 0; i < billing.Lines.Count; i++)
            {
                BillingLine line = billing.Lines[i];
                _connectionContext.Database.ExecuteSqlRaw($"INSERT INTO BillingLines (Id,ProductId,Description,Quantity,UnitPrice,Subtotal,BillingId) VALUES ('{line.Id}','{line.Product.Id}','{line.Description}',{line.Quantity},{line.UnitPrice},{line.Subtotal},'{line.BillingId}')");
            }
            _connectionContext.SaveChanges();
        }

        public bool Update(Billing billing)
        {
            _connectionContext.Billings.Update(billing);
            _connectionContext.SaveChanges();
            return true;
        }
    }
}
