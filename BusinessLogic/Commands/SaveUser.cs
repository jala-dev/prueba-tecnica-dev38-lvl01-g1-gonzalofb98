using Data;
using Data.Entities;
using Presentation;
using Presentation.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Commands
{
    class SaveUser
    {
            MemberRepository _repository = new MemberRepository();
        public void Execute()
        {
            SaveUserView view = new SaveUserView();
            InputData data = view.RequestData();
            Member entity = new Member();
            entity.ID = int.Parse(data.fields["CodigoSocio"]);
            entity.FirstName = data.fields["Nombre"];
            entity.SecondName = data.fields["Apellido"];

            if (this.Validacion(entity))
            {
                Member member = _repository.GetMember(entity.ID);
                view.ShowResult(entity.FirstName + " " + entity.SecondName);
            }

        }

        public bool Validacion(Member entity)
        {
            if(entity == null ||
                entity.ID == 0 ||
                entity.FirstName.Equals("") ||
                entity.SecondName.Equals("")) 
            {
                ErrorView errorView = new ErrorView();
                errorView.ShowError($"No se pudo crear el nuevo socio, datos incompletos.");
                return false;
            }else if (entity.ID <5000 || entity.ID > 5999)
            {
                ErrorView errorView = new ErrorView();
                errorView.ShowError($"No se pudo crear el nuevo socio, ID fuera de rango.");
                return false;
            }else if (_repository.GetMember(entity.ID) != null)
            {
                ErrorView errorView = new ErrorView();
                errorView.ShowError($"No se pudo crear el nuevo socio, el ID ya existe.");
                return false;
            }
            return true;
        }
    }
}
