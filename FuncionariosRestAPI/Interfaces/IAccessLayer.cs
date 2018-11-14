using System.Collections.Generic;
using System.Threading.Tasks;
using FuncionariosRestAPI.Models;

namespace FuncionariosRestAPI.Data
{
    public interface IAccessLayer
    {
        Task CreateAsync(Funcionario funcionario);
        Task<IEnumerable<Funcionario>> ReadAsync();
        Task<Funcionario> GetByIdAsync(int id);
        Task<bool> DeleteAsync(int id);
        Task<bool> UpdateAsync(Funcionario funcionario);
    }
}