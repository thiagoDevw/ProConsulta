﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MudBlazor;
using ProConsulta.Extensions;
using ProConsulta.Models;
using ProConsulta.Repositories.Especialidades;
using ProConsulta.Repositories.Medicos;
using ProConsulta.Repositories.Pacientes;
using System.ComponentModel.DataAnnotations;

namespace ProConsulta.Components.Pages.Medicos
{
    public class CreateMedicoPage : ComponentBase
    {
        [Inject]
        private IEspecialidadeRepository EspecialidadeRepository {  get; set; } = null!;

        [Inject]
        public IMedicoRepository repository { get; set; } = default!;

        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        public List<Especialidade> Especialidades { get; set; } = new List<Especialidade>();
        public MedicoInputModel InputModel { get; set; } = new MedicoInputModel();

        public async Task OnvalidSubmitAsync(EditContext editContext)
        {
            try
            {
                if(editContext.Model is MedicoInputModel model)
                {
                    var medico = new Medico
                    {
                        Nome = model.Nome,
                        Documento = model.Documento.SomenteCaracteres(),
                        Celular = model.Celular.SomenteCaracteres(),
                        CRM = model.CRM.SomenteCaracteres(),
                        EspecialidadeId = model.EspecialidadeId,
                        DataCadastro = model.DataCadastro
                    };

                    await repository.AddAsync(medico);
                    Snackbar.Add("Médico cadastrado com sucesso!", Severity.Success);
                    NavigationManager.NavigateTo("/medicos");
                }
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
        }

        protected override async Task OnInitializedAsync()
        {
            Especialidades = await EspecialidadeRepository.GetAllAsync();
        }
    }
}
