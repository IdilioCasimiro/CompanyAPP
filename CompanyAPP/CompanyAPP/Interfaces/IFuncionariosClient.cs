using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;

namespace CompanyAPP.Client
{
    public interface IFuncionariosClient
    {
        string BaseUrl { get; set; }

        Task DeleteAsync(int id);
        Task DeleteAsync(int id, CancellationToken cancellationToken);
        Task<ObservableCollection<Funcionario>> GetAsync();
        Task<ObservableCollection<Funcionario>> GetAsync(CancellationToken cancellationToken);
        Task<Funcionario> GetByIdAsync(int id);
        Task<Funcionario> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<Funcionario> PostAsync(Funcionario funcionario);
        Task<Funcionario> PostAsync(Funcionario funcionario, CancellationToken cancellationToken);
        Task PutAsync(int id, Funcionario funcionario);
        Task PutAsync(int id, Funcionario funcionario, CancellationToken cancellationToken);
    }
}