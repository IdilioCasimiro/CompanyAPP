using FuncionariosRestAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FuncionariosRestAPI.Data
{
    public class AccessLayer : IAccessLayer
    {
        private readonly DataContext context;

        public AccessLayer(DataContext dataContext)
        {
            this.context = dataContext;
        }

        public async Task<IEnumerable<Funcionario>> ReadAsync()
        {
            return await context.Funcionarios.ToListAsync();
        }

        public async Task<Funcionario> GetByIdAsync(int id)
        {
            var funcionario = await context.Funcionarios.FindAsync(id);
            return funcionario;
        }

        public async Task CreateAsync(Funcionario funcionario)
        {
            await context.Funcionarios.AddAsync(funcionario);
            await context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(Funcionario funcionario)
        {
            var f = await GetByIdAsync(funcionario.ID);
            if (funcionario == null)
                return false;

            f.Nome = funcionario.Nome;
            f.Funcao = funcionario.Funcao;
            f.Departamento = funcionario.Departamento;
            f.Salario = funcionario.Salario;
            
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var funcionario = await GetByIdAsync(id);
            if (funcionario == null)
                return false;

            context.Funcionarios.Remove(funcionario);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
