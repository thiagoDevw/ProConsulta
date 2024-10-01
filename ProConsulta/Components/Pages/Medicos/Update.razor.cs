﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using ProConsulta.Extensions;
using ProConsulta.Models;
using ProConsulta.Repositories.Especialidades;
using ProConsulta.Repositories.Medicos;

namespace ProConsulta.Components.Pages.Medicos
{
    public class UpdateMedicoPage : ComponentBase
    {
        [Parameter]
        public int MedicoId { get; set; }


        [Inject]
        private IEspecialidadeRepository EspecialidadeRepository { get; set; } = null!;

        [Inject]
        public IMedicoRepository repository { get; set; } = default!;

        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        public Medico? CurrentMedico { get; set; }
        public MedicoInputModel InputModel {  get; set; } = new MedicoInputModel();
        public List<Especialidade> Especialidades { get; set; } = new List<Especialidade>();

        public async Task OnValidSubmitAsync(EditContext editContext)
        {
            try
            {
                if(CurrentMedico is null) return;

                if(editContext.Model is MedicoInputModel model)
                {
                    CurrentMedico.Id = MedicoId;
                    CurrentMedico.Nome = model.Nome;
                    CurrentMedico.Documento = model.Documento.SomenteCaracteres();
                    CurrentMedico.CRM = model.CRM.SomenteCaracteres();
                    CurrentMedico.Celular = model.Celular.SomenteCaracteres();
                    CurrentMedico.EspecialidadeId = model.EspecialidadeId;

                    await repository.UpdateAsync(CurrentMedico);
                    Snackbar.Add("Médico atualizado com sucesso!", Severity.Success);
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
            CurrentMedico = await repository.GetByIdAsync(MedicoId);
            Especialidades = await EspecialidadeRepository.GetAllAsync();

            if(CurrentMedico is null) return;

            InputModel = new MedicoInputModel
            {
                Nome = CurrentMedico.Nome,
                Documento = CurrentMedico.Documento,
                CRM = CurrentMedico.CRM,
                Celular = CurrentMedico.Celular,
                EspecialidadeId = CurrentMedico.EspecialidadeId,
            };
        }
    }
}
