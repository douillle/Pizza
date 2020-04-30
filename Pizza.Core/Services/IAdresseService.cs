using Pizza.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.Core.Services
{
    public interface IAdresseService
    {
        Task<Adresses> GetAdresseByText(string adresse);
        Task CreateAddress(Adresses adresse);
    }
}
