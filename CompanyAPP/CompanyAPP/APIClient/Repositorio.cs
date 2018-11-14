using CompanyAPP.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyAPP.APIClient
{
    class Repositorio
    {
        private FuncionariosClient funcionariosClient = new FuncionariosClient();
        public async void GetAll()
        {
            await funcionariosClient.GetAsync();
        }
    }
}
