using Data;
using Data.Entities;
using Presentation;
using Presentation.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Commands
{
    class SavePayment
    {
        MemberRepository _repository = new MemberRepository();
        ConsumptionRepository _consumptionRepository = new ConsumptionRepository();
        public void Execute()
        {
            SavePaymentView view = new SavePaymentView();
            InputData data = view.RequestData();
            Member entity = _repository.GetMember(int.Parse(data.fields["CodigoSocio"]));

            if (entity == null)
            {
                ErrorView errorView = new ErrorView();
                errorView.ShowError($"El código de socio no existe.");
            }
            else
            {
                foreach(var cons in _consumptionRepository.GetConsumptionByMember(entity))
                {
                    cons.Paid = true;
                }
                view.ShowResult(entity.FirstName + " " + entity.SecondName);
            }

        }
    }
}
