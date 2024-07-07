using Azure;
using Azure.Core;
using Azure.Messaging;
using Microsoft.Win32;
using System;
using WebAPI.Domain.Model;
using WebAPI.Infrastructure.Repository;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebAPI.Infrastructure.Service
{
    public class BillingService : IBillingService
    {
        private readonly IBillingRepository _billingRepository;
        public BillingService(IBillingRepository billingRepository)
        {
            _billingRepository = billingRepository;
        }

        public bool Delete(Guid id)
        {
            return _billingRepository.Delete(id);
        }

        public Task<Billing> Get(Guid id)
        {
            return _billingRepository.Get(id);
        }

        public Task<List<Billing>> GetBillings()
        {
            return _billingRepository.GetBillings();
        }

        public bool Insert(Billing billing)
        {
            return _billingRepository.Insert(billing);
            //try
            //{
            //    if (!HasCustomer(billing.Customer))
            //        return ;// (false, "esta faltando o registro do customer");
            //    //Se o cliente e o produto existirem, inserir o registro do billing e billingLines no DB local.
            //    //Caso se o cliente existir ou só o produto existir, deve retornar um erro na aplicação informando sobre a criação do registro faltante.
            //    //Criar exceptions tratando mal funcionamento ou interrupção de serviço quando API estiver fora.
            //    return _billingRepository.Insert(billing);
            //}
            //catch(Exception ex) { 
            //}
        }

        //private bool HasCustomer(Customer customer)
        //{

        //}

        public bool Update(Billing billing)
        {
            return _billingRepository.Update(billing);
        }
    }
}
